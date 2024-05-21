using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WinStoreWaterSystem.Models;

namespace WinStoreWaterSystem
{
    public partial class FrmStoreWater : Form
    {
        public FrmStoreWater()
        {
            InitializeComponent();
            uStop.IsOn = false;
        }
        Point point;//鼠标按下时点
        bool isMoving = false;//标识是否拖动

        bool isReading = false;//是否正在读
        bool isWriting = false;//是否正在写
        /// <summary>
        /// 存储区列表
        /// </summary>
        List<StoreRegionInfo> regionList = new List<StoreRegionInfo>();
        /// <summary>
        /// 参数列表
        /// </summary>
        List<ParaInfo> paraList = new List<ParaInfo>();
        /// <summary>
        /// 实时数据集合
        /// </summary>
        Dictionary<string, string> currentValues = new Dictionary<string, string>();
        /// <summary>
        /// 报警设置集合
        /// </summary>
        Dictionary<string, string> alarmSets = new Dictionary<string, string>();
        System.Timers.Timer myReadTimer = null;//读定时器
        System.Timers.Timer myLoadTimer = null;//加载的定时器
        int isStarted = 0;//是否开始抽水
        bool isLoadData = false;//是否初次采集完成
        SerialPort serialPort = null;//串口
        IModbusSerialMaster rtuMaster = null;//RTU通信主站

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStoreWater_Load(object sender, EventArgs e)
        {
            InitSetData();
            CreateRtuMaster();
            LoadStoreRegionList();
            LoadParaList();
            InitParaSet();//初始化控件的参数名设置
            InitAlarmSets();//报警条件设置
            InitTimers();//定时器初始化
        }






        private void InitSetData()
        {
            //启动与停止按钮初始化
            uStart.Enabled = true;
            uStart.IsOn = false;
            uStop.Enabled = false;
            uStop.IsOn = false;
            uPump01.ActualState = false;
            uInPumpVoltage.Value = 0;
            //清空水位数据
            ClearWaterData();
            //清空水泵数据重置水管状态
            ClearPumpData();
        }

        //清空水位数据
        private void ClearWaterData()
        {
            foreach (Control c in panelWDatas.Controls)
            {
                if (c is ParaTextBox)
                {
                    ((ParaTextBox)c).DataVal = "0.00";
                }
            }
        }

        private void ClearPumpData()
        {
            foreach (Control c in panelPumpDatas.Controls)
            {
                if (c is ParaTextBox)
                {
                    ((ParaTextBox)c).DataVal = "0";
                }
            }
            //水管处于静止状态
            SetPipesFlow(false);
        }

        /// <summary>
        /// 设置水管是否流动
        /// </summary>
        /// <param name="isFlow"></param>
        private void SetPipesFlow(bool isFlow)
        {
            foreach (Control c in uPanel2.Controls)
            {
                if (c is UCPipe)
                {
                    ((UCPipe)c).IsFlow = isFlow;
                }
            }
        }

        private void CreateRtuMaster()
        {
            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            //创建Rtu主站
            rtuMaster = ModbusSerialMaster.CreateRtu(serialPort);
            serialPort.Open();//打开连接

        }


        /// <summary>
        /// 存储区加载
        /// </summary>
        private void LoadStoreRegionList()
        {
            regionList = new List<StoreRegionInfo>()
            {
                new StoreRegionInfo(){SlaveId=1,FunctionCode=3,StartAddress=0,Length=4},
                new StoreRegionInfo(){SlaveId=2,FunctionCode=3,StartAddress=0,Length=3},
                new StoreRegionInfo(){SlaveId=3,FunctionCode=1,StartAddress=0,Length=3}
            };
        }

        private void LoadParaList()
        {
            paraList = new List<ParaInfo>()
            {
                new ParaInfo(){ParaName="PumpPower",SlaveId=1,Address=0,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="PumpEC",SlaveId=1,Address=1,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="PumpFrequency",SlaveId=1,Address=2,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="PumpVoltage",SlaveId=1,Address=3,DataType="Int",DecimalCount=0},
                new ParaInfo(){ParaName="CurrentWPosition",SlaveId=2,Address=0,DataType="Float",DecimalCount=2},
                new ParaInfo(){ParaName="LowWPosition",SlaveId=2,Address=1,DataType="Float",DecimalCount=2},
                new ParaInfo(){ParaName="HighWPosition",SlaveId=2,Address=2,DataType="Float",DecimalCount=2},
                new ParaInfo(){ParaName="DeviceStart",SlaveId=3,Address=0,DataType="Bool",DecimalCount=0},
                new ParaInfo(){ParaName="Pump01Start",SlaveId=3,Address=1,DataType="Bool",DecimalCount=0},
                new ParaInfo(){ParaName="IsVoltageAlarm",SlaveId=3,Address=2,DataType="Bool",DecimalCount=0}
            };
        }

        /// <summary>
        /// 控件参数名设置
        /// </summary>
        private void InitParaSet()
        {
            ptxtPumpPower.VarName = "PumpPower";
            ptxtPumpEC.VarName = "PumpEC";
            ptxtPumpFrequency.VarName = "PumpFrequency";
            ptxtPumpVoltage.VarName = "PumpVoltage";
            ptxtCurrentWPosition.VarName = "CurrentWPosition";
            ptxtHighWPosition.VarName = "HighWPosition";
            ptxtLowWPosition.VarName = "LowWPosition";
            uPump01.PumpParaState = "Pump01Start";
            uStart.VarName = "DeviceStart";
            alarmVoltage.VarName = "IsVoltageAlarm";
            //初始化一份实时数据
            foreach (ParaInfo p in paraList)
            {
                string val = "0";
                if (p.DataType == "Float")
                    val = "0.00";
                else if (p.DataType == "Bool")
                    val = "False";
                currentValues[p.ParaName] = val;
            }
        }

        /// <summary>
        /// 报警条件设置
        /// </summary>
        private void InitAlarmSets()
        {
            alarmSets.Add("PumpVoltage", "220");//检测水泵电压的正常值
        }

        /// <summary>
        /// 两个定时器初始化
        /// </summary>
        private void InitTimers()
        {
            myReadTimer = new System.Timers.Timer();
            myReadTimer.Interval = 1000;// 1s    ms
            myReadTimer.AutoReset = true;
            myReadTimer.Elapsed += MyReadTimer_Elapsed;

            myLoadTimer = new System.Timers.Timer();
            myLoadTimer.Interval = 1000;// 1s    ms
            myLoadTimer.AutoReset = true;
            myLoadTimer.Elapsed += MyLoadTimer_Elapsed;
        }


        /// <summary>
        /// 读定时器重复事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyReadTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //子线程
            //定时读取数据
            ReadDatas();
        }

        private void ReadDatas()
        {
            while (true)
            {
                if (isReading && !isWriting)
                {
                    //进入读过程
                    foreach (StoreRegionInfo item in regionList)
                    {
                        if (item.SlaveId == 1 && currentValues["Pump01Start"] == "False")
                        {
                            continue;
                        }
                        else
                        {
                            ReadSlaveData(item);//读取指定的Slave中的数据
                        }
                    }
                    if (!isLoadData)
                        isLoadData = true;
                    break;
                }
                else
                    Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 读取指定的Slave中的数据
        /// </summary>
        /// <param name="item"></param>
        private void ReadSlaveData(StoreRegionInfo region)
        {
            //FunctionCode 01  03 
            int code = region.FunctionCode;
            byte slaveId = region.SlaveId;
            ushort startAddr = region.StartAddress;
            ushort length = region.Length;
            //筛选该从站相关的参数列表
            List<ParaInfo> pList = paraList.Where(p => p.SlaveId == slaveId).ToList();
            if (code == 3)//读取的保持型寄存器
            {
                //同步、异步  
                //ushort[] reDatas = rtuMaster.ReadHoldingRegisters(slaveId, startAddr, length);
                Task<ushort[]> t = Task.Run(async () =>
                {
                    ushort[] reDatas = await rtuMaster.ReadHoldingRegistersAsync(slaveId, startAddr, length);
                    return reDatas;
                });
                ushort[] reDataArr = t.Result;
                if (reDataArr.Length > 0)
                {
                    //处理数据
                    foreach (ParaInfo p in pList)
                    {
                        int addr = p.Address;//寄存器地址   p的数据值
                        int decimalCount = p.DecimalCount;//小数的位数
                        string paraName = p.ParaName;//参数名
                        ushort uval = reDataArr[addr];//参数值
                        string strCurVal = "";
                        if (decimalCount > 0)
                        {
                            string formatStr = "0.";  //10----10.0     0.0
                            for (int j = 1; j < length; j++)
                            {
                                formatStr += "0";
                            }
                            strCurVal = ((double)uval / Math.Pow(10, decimalCount)).ToString(formatStr);
                        }
                        else
                            strCurVal = uval.ToString();
                        //当前值保存到实时集合中
                        currentValues[paraName] = strCurVal;
                    }
                }
            }
            else if (code == 1)//线圈状态值
            {
                Task<bool[]> t = Task.Run(async () =>
                {
                    bool[] reDatas = await rtuMaster.ReadCoilsAsync(slaveId, startAddr, length);
                    return reDatas;
                });
                bool[] reDataArr = t.Result;
                if (reDataArr.Length > 0)
                {
                    //处理数据
                    foreach (ParaInfo p in pList)
                    {
                        int addr = p.Address;//寄存器地址   p的数据值
                        int decimalCount = p.DecimalCount;//小数的位数
                        string paraName = p.ParaName;//参数名
                        bool uval = reDataArr[addr];//参数值
                        string strCurVal = uval.ToString();
                        //当前值保存到实时集合中
                        currentValues[paraName] = strCurVal;
                    }
                }
            }
        }

        /// <summary>
        /// 加载定时器的重复事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyLoadTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //定时加载数据
            var datas = currentValues;
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    //开关状态不加载，也OK
                    //水位数据加载
                    decimal current = decimal.Parse(datas["CurrentWPosition"]);
                    decimal highPos = decimal.Parse(datas["HighWPosition"]);
                    decimal lowPos = decimal.Parse(datas["LowWPosition"]);
                    foreach (Control c in panelWDatas.Controls)
                    {
                        if (c is ParaTextBox)
                        {
                            ParaTextBox txt = c as ParaTextBox;
                            string varName = txt.VarName;
                            txt.DataVal = datas[varName];//取到实时集合中的值
                        }
                    }

                    uStoreTank.Value = (int)(current * 100);//储水池的水位值
                    uStoreTank.MaxVlaue = (int)highPos * 100;//最高水位值
                    //水泵数据
                    if (uPump01.ActualState)
                    {
                        int voltage = 0;
                        voltage = int.Parse(datas["PumpVoltage"]);//当前的电压
                        uInPumpVoltage.Value = voltage;//仪表的值
                        //水泵数据面板中数据加载
                        foreach (Control c in panelPumpDatas.Controls)
                        {
                            if (c is ParaTextBox)
                            {
                                ParaTextBox txt = c as ParaTextBox;
                                string varName = txt.VarName;
                                txt.DataVal = datas[varName];//取到实时集合中的值
                            }
                        }
                        //报警检查
                        if (alarmSets.ContainsKey("PumpVoltage"))
                        {
                            int maxVoltage = int.Parse(alarmSets["PumpVoltage"]);//最大值
                            if (voltage > maxVoltage)
                            {
                                datas[alarmVoltage.VarName] = "True";//报警灯的状态
                            }
                            else
                            {
                                datas[alarmVoltage.VarName] = "False";
                            }
                            alarmVoltage.IsOn = bool.Parse(datas[alarmVoltage.VarName]);
                        }
                    }
                    uPump01.ActualState = bool.Parse(datas[uPump01.PumpParaState]);//水泵的状态
                    //水位检测---决定水泵的启停
                    if (current >= highPos && isStarted == 1)
                    {
                        //停止水泵抽水----关闭水泵
                        UpdatePump();   //启停水泵
                    }
                    else if (current <= lowPos && isStarted == 0)
                    {
                        //启动水泵抽水----启动水泵
                        UpdatePump();   //启停水泵
                    }
                }));
            }
        }

        /// <summary>
        /// 修改设备启停方法
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="blState"></param>
        /// <returns></returns>
        private bool UpdateDevState(string paraName, bool blState)
        {
            bool update = false;
            //切换读写状态----写
            if (isReading)
            {
                isReading = false;
                isWriting = true;
                myReadTimer.Stop();
            }
            //参数信息
            ParaInfo paraInfo = paraList.Find(p => p.ParaName == paraName);
            if (paraInfo != null)
            {
                //写状态
                Task<bool> t = Task.Run(async () => {
                    await rtuMaster.WriteSingleCoilAsync(paraInfo.SlaveId, paraInfo.Address, blState);
                    return true;
                });
                if (t.Result)
                {
                    update = true;
                    currentValues[paraName] = blState ? "True" : "False";//保存当前值
                    //状态切换为读
                    isReading = true;
                    isWriting = false;
                    myReadTimer.Start();
                }
            }
            return update;
        }


        /// <summary>
        /// 最小化与正常尺寸的切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭本页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStoreWater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确定要退出该系统吗？", "退出系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.ExitThread();
            }
        }

        //保存当前按下的位置，启动拖动
        private void uPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;//按下的点
            isMoving = true;//启动拖动
        }

        //拖动操作
        private void uPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMoving)
            {
                Point pNew = new Point(e.Location.X - point.X, e.Location.Y - point.Y);
                //Location = new Point(Location.X + pNew.X, Location.Y + pNew.Y);
                Location += new Size(pNew);
            }

        }

        private void uPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;//停止拖动
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            uPanel1_MouseDown(sender, e);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            uPanel1_MouseMove(sender, e);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            uPanel1_MouseUp(sender, e);
        }

        const int WM_NCHITTEST = 0x0084;// 移动鼠标
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if ((this.MaximizeBox == true && this.WindowState == FormWindowState.Normal))
                    {
                        Point vPoint = new Point((int)m.LParam & 0xFFFF,
              (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = PointToClient(vPoint);
                        if (vPoint.X <= 5)
                            if (vPoint.Y <= 5)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (vPoint.Y >= ClientSize.Height - 5)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else m.Result = (IntPtr)HTLEFT;
                        else if (vPoint.X >= ClientSize.Width - 5)
                            if (vPoint.Y <= 5)
                                m.Result = (IntPtr)HTTOPRIGHT;
                            else if (vPoint.Y >= ClientSize.Height - 5)
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                            else m.Result = (IntPtr)HTRIGHT;
                        else if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOP;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOM;

                    }

                    break;
            }
        }

        /// <summary>
        /// 打开开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uStart_ClickEvent(object sender, EventArgs e)
        {
            SetStart(true);
        }
        /// <summary>
        /// 关闭开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uStop_ClickEvent(object sender, EventArgs e)
        {
            SetStart(false);
        }

        /// <summary>
        /// 开关启停方法
        /// </summary>
        /// <param name="blState"></param>
        private void SetStart(bool blState)
        {
            if (blState)//打开开关
            {
                bool blStart = UpdateDevState(uStart.VarName, true);
                if (blStart)
                {
                    WriteMsg("系统已启动！");
                    uStart.Enabled = false;
                    uStart.IsOn = true;
                    uStop.Enabled = true;
                    uStop.IsOn = false;
                    myReadTimer.Start();
                    myLoadTimer.Start();
                }
            }
            else
            {
                bool blStart = UpdateDevState(uStart.VarName, false);
                if (blStart)
                {
                    WriteMsg("系统已停止！");
                    if (uPump01.ActualState)
                    {
                        UpdatePump(); //停止水泵
                    }
                    uStart.Enabled = true;
                    uStart.IsOn = false;
                    uStop.Enabled = false;
                    uStop.IsOn = true;
                    myReadTimer.Stop();
                    myLoadTimer.Stop();
                }
            }
        }

        /// <summary>
        /// 水泵的启停方法
        /// </summary>
        private void UpdatePump()
        {
            string paraName = uPump01.PumpParaState;//水泵状态参数名
            if (currentValues[paraName] == "True")//运行时
            {
                //停止水泵
                bool blStop = UpdateDevState(paraName, false);
                if (blStop)
                {
                    WriteMsg("水泵已关闭");
                    uPump01.ActualState = false;
                    ClearPumpData();//包含水管静止状态设置
                    isStarted = 0;
                }
            }
            else
            {
                //启动水泵
                bool blStart = UpdateDevState(paraName, true);
                if (blStart)
                {
                    WriteMsg("正在抽水中。。。。");
                    uPump01.ActualState = true;
                    SetPipesFlow(true);//水管状态为流动
                    isStarted = 1;
                }
            }
        }

        /// <summary>
        /// 写文本
        /// </summary>
        /// <param name="msg"></param>
        private void WriteMsg(string msg)
        {
            lblMsg.Text = msg;
        }

        private void uPump01_ChangedStateClick(object sender, EventArgs e)
        {
            UpdatePump();
        }
    }
}
