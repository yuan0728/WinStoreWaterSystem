using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinStoreWaterSystem
{
    /// <summary>
    /// 报警灯
    /// </summary>
    public partial class UCAlarmControl : UserControl
    {
        public UCAlarmControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            this.Size = new System.Drawing.Size(50, 50);
            this.SizeChanged += UCAlarmControl_SizeChanged;
            // 定时器初始化
            timer = new System.Timers.Timer();
            timer.AutoReset = true; // 重复执行
            timer.Interval = 200;
            timer.Elapsed += Timer_Elapsed;
        }
        System.Timers.Timer timer = null;
        int inColorIndex = 0;// 当前颜色索引值
        Rectangle m_rectWorking; // 工作区 灯泡部分的绘制区域
        /// <summary>
        /// 定时执行报警灯颜色的切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            inColorIndex++;
            this.Invoke(new Action(() =>
            {
                if (inColorIndex == alarmLightColor.Length)
                    inColorIndex = 0;
                Invalidate();
            }));
        }
        /// <summary>
        /// 动态计算工作区的大小尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCAlarmControl_SizeChanged(object sender, EventArgs e)
        {
            // x:1/8width y:1/height width3/4 height3/4
            m_rectWorking = new Rectangle(Width / 8, Height / 8, Width - Width / 4, Height - Height / 4);

        }

        private string varName;
        [DefaultValue(typeof(string), "varName"), Description("报警灯状态参数名称")]
        public string VarName
        {
            get { return varName; }
            set
            {
                varName = value;
            }
        }
        private Color[] alarmLightColor = { Color.Red };
        [DefaultValue(typeof(Color[]), "Red"), Description("灯的颜色，当需要闪烁时，至少要设置两种或以上颜色；不需要闪烁，至少需要一种颜色")]
        public Color[] AlarmLightColor
        {
            get { return alarmLightColor; }
            set
            {
                if (value == null || value.Length == 0)
                    return;
                alarmLightColor = value;
                Invalidate();
            }
        }
        private Color alarmStandColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("灯座的颜色")]
        public Color AlarmStandColor
        {
            get { return alarmStandColor; }
            set
            {
                alarmStandColor = value;
                Invalidate();
            }
        }
        private int twinkInterval = 0;
        [DefaultValue(typeof(int), "0"), Description("闪烁间隔时间（毫秒），当值为0时，不闪烁")]
        public int TwinkInterval
        {
            get { return twinkInterval; }
            set
            {
                if (value < 0) return;
                twinkInterval = value;
                if (value == 0 && alarmLightColor.Length <= 1)
                {
                    this.timer.Enabled = false;
                }
                else
                {
                    inColorIndex = 0;
                }
                Invalidate();
            }
        }
        private bool isOn = false;
        [DefaultValue(typeof(bool), "false"), Description("报警灯是否报警")]
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                if (IsOn && twinkInterval > 0)
                {
                    timer.Interval = twinkInterval;
                    this.timer.Enabled = true;
                    this.timer.Start();
                }
                else
                {
                    this.timer.Enabled = false;
                    timer.Stop();
                    inColorIndex = 0;
                }
                Invalidate();
            }
        }
        /// <summary>
        /// 绘制报警灯
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color c = alarmLightColor[inColorIndex];// 当前灯的颜色值
            // 灯泡部分的路径
            GraphicsPath path = new GraphicsPath();
            // 左边的竖线 从上 --> 下
            path.AddLine(m_rectWorking.Left, m_rectWorking.Bottom - Height / 4 + 2, m_rectWorking.Left, m_rectWorking.Top + m_rectWorking.Width);
            // 半圆弧
            path.AddArc(m_rectWorking.Left, m_rectWorking.Top, m_rectWorking.Width, m_rectWorking.Width, 180f, 180f);
            // 右边的竖线 从下 --> 上
            path.AddLine(m_rectWorking.Right, m_rectWorking.Top + m_rectWorking.Width, m_rectWorking.Right, m_rectWorking.Bottom - Height / 4 + 2);
            path.CloseAllFigures();// 关闭图形 形成闭合区域
            // 填充灯泡
            g.FillPath(new SolidBrush(c), path);
            // 填充灯座
            g.FillRectangle(new SolidBrush(alarmStandColor), new RectangleF(0f, m_rectWorking.Bottom - Height/4, Width, Height / 4));
        }
    }
}
