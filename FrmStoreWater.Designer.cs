namespace WinStoreWaterSystem
{
    partial class FrmStoreWater
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uPanel2 = new UPanel();
            this.uStop = new ULightControl();
            this.panelPumpDatas = new UPanel();
            this.ptxtPumpVoltage = new ParaTextBox();
            this.ptxtPumpEC = new ParaTextBox();
            this.ptxtPumpFrequency = new ParaTextBox();
            this.ptxtPumpPower = new ParaTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelWDatas = new UPanel();
            this.ptxtLowWPosition = new ParaTextBox();
            this.ptxtHighWPosition = new ParaTextBox();
            this.ptxtCurrentWPosition = new ParaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uArrowControl2 = new UArrowControl();
            this.uArrowControl1 = new UArrowControl();
            this.ucPipe7 = new UCPipe();
            this.ucPipe2 = new UCPipe();
            this.ucPipe5 = new UCPipe();
            this.ucPipe4 = new UCPipe();
            this.ucPipe6 = new UCPipe();
            this.ucPipe3 = new UCPipe();
            this.ucPipe8 = new UCPipe();
            this.ucPipe1 = new UCPipe();
            this.uPump01 = new UPump();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uStoreTank = new UCWaterTank();
            this.uSupplyTank = new UCWaterTank();
            this.lblMsg = new System.Windows.Forms.Label();
            this.alarmVoltage = new UCAlarmControl();
            this.uStart = new ULightControl();
            this.uInPumpVoltage = new UInstrumentControl();
            this.uPanel1 = new UPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uPanel2.SuspendLayout();
            this.panelPumpDatas.SuspendLayout();
            this.panelWDatas.SuspendLayout();
            this.uPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uPanel2
            // 
            this.uPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uPanel2.BackColor = System.Drawing.Color.Transparent;
            this.uPanel2.BgColor = System.Drawing.Color.SteelBlue;
            this.uPanel2.BgColor2 = System.Drawing.Color.White;
            this.uPanel2.Controls.Add(this.uStop);
            this.uPanel2.Controls.Add(this.panelPumpDatas);
            this.uPanel2.Controls.Add(this.panelWDatas);
            this.uPanel2.Controls.Add(this.uArrowControl2);
            this.uPanel2.Controls.Add(this.uArrowControl1);
            this.uPanel2.Controls.Add(this.ucPipe7);
            this.uPanel2.Controls.Add(this.ucPipe2);
            this.uPanel2.Controls.Add(this.ucPipe5);
            this.uPanel2.Controls.Add(this.ucPipe4);
            this.uPanel2.Controls.Add(this.ucPipe6);
            this.uPanel2.Controls.Add(this.ucPipe3);
            this.uPanel2.Controls.Add(this.ucPipe8);
            this.uPanel2.Controls.Add(this.ucPipe1);
            this.uPanel2.Controls.Add(this.uPump01);
            this.uPanel2.Controls.Add(this.label4);
            this.uPanel2.Controls.Add(this.label3);
            this.uPanel2.Controls.Add(this.uStoreTank);
            this.uPanel2.Controls.Add(this.uSupplyTank);
            this.uPanel2.Controls.Add(this.lblMsg);
            this.uPanel2.Controls.Add(this.alarmVoltage);
            this.uPanel2.Controls.Add(this.uStart);
            this.uPanel2.Controls.Add(this.uInPumpVoltage);
            this.uPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.uPanel2.Location = new System.Drawing.Point(0, 93);
            this.uPanel2.Name = "uPanel2";
            this.uPanel2.Size = new System.Drawing.Size(1263, 681);
            this.uPanel2.TabIndex = 1;
            // 
            // uStop
            // 
            this.uStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uStop.LightfocusColor = System.Drawing.Color.Gray;
            this.uStop.Location = new System.Drawing.Point(1136, 134);
            this.uStop.Name = "uStop";
            this.uStop.Size = new System.Drawing.Size(84, 82);
            this.uStop.StateText = "停止";
            this.uStop.TabIndex = 10;
            this.uStop.Text = "uLightControl1";
            this.uStop.VarName = null;
            this.uStop.ClickEvent += new System.EventHandler(this.uStop_ClickEvent);
            // 
            // panelPumpDatas
            // 
            this.panelPumpDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPumpDatas.BgColor = System.Drawing.Color.WhiteSmoke;
            this.panelPumpDatas.BorderColor = System.Drawing.Color.SteelBlue;
            this.panelPumpDatas.BorderWidth = 5;
            this.panelPumpDatas.Controls.Add(this.ptxtPumpVoltage);
            this.panelPumpDatas.Controls.Add(this.ptxtPumpEC);
            this.panelPumpDatas.Controls.Add(this.ptxtPumpFrequency);
            this.panelPumpDatas.Controls.Add(this.ptxtPumpPower);
            this.panelPumpDatas.Controls.Add(this.label11);
            this.panelPumpDatas.Controls.Add(this.label8);
            this.panelPumpDatas.Controls.Add(this.label9);
            this.panelPumpDatas.Controls.Add(this.label10);
            this.panelPumpDatas.Location = new System.Drawing.Point(492, 194);
            this.panelPumpDatas.Name = "panelPumpDatas";
            this.panelPumpDatas.Size = new System.Drawing.Size(201, 153);
            this.panelPumpDatas.TabIndex = 9;
            // 
            // ptxtPumpVoltage
            // 
            this.ptxtPumpVoltage.DataVal = "220";
            this.ptxtPumpVoltage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtPumpVoltage.ForeColor = System.Drawing.Color.BlueViolet;
            this.ptxtPumpVoltage.Location = new System.Drawing.Point(75, 110);
            this.ptxtPumpVoltage.Name = "ptxtPumpVoltage";
            this.ptxtPumpVoltage.Size = new System.Drawing.Size(73, 21);
            this.ptxtPumpVoltage.TabIndex = 5;
            this.ptxtPumpVoltage.Text = "220 V";
            this.ptxtPumpVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtPumpVoltage.Unit = "V";
            this.ptxtPumpVoltage.VarName = null;
            // 
            // ptxtPumpEC
            // 
            this.ptxtPumpEC.DataVal = "10";
            this.ptxtPumpEC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtPumpEC.ForeColor = System.Drawing.Color.BlueViolet;
            this.ptxtPumpEC.Location = new System.Drawing.Point(75, 82);
            this.ptxtPumpEC.Name = "ptxtPumpEC";
            this.ptxtPumpEC.Size = new System.Drawing.Size(73, 21);
            this.ptxtPumpEC.TabIndex = 5;
            this.ptxtPumpEC.Text = "10 A";
            this.ptxtPumpEC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtPumpEC.Unit = "A";
            this.ptxtPumpEC.VarName = null;
            // 
            // ptxtPumpFrequency
            // 
            this.ptxtPumpFrequency.DataVal = "50";
            this.ptxtPumpFrequency.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtPumpFrequency.ForeColor = System.Drawing.Color.BlueViolet;
            this.ptxtPumpFrequency.Location = new System.Drawing.Point(75, 54);
            this.ptxtPumpFrequency.Name = "ptxtPumpFrequency";
            this.ptxtPumpFrequency.Size = new System.Drawing.Size(73, 21);
            this.ptxtPumpFrequency.TabIndex = 6;
            this.ptxtPumpFrequency.Text = "50 Hz";
            this.ptxtPumpFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtPumpFrequency.Unit = "Hz";
            this.ptxtPumpFrequency.VarName = null;
            // 
            // ptxtPumpPower
            // 
            this.ptxtPumpPower.DataVal = "1000";
            this.ptxtPumpPower.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtPumpPower.ForeColor = System.Drawing.Color.BlueViolet;
            this.ptxtPumpPower.Location = new System.Drawing.Point(75, 27);
            this.ptxtPumpPower.Name = "ptxtPumpPower";
            this.ptxtPumpPower.Size = new System.Drawing.Size(73, 21);
            this.ptxtPumpPower.TabIndex = 7;
            this.ptxtPumpPower.Text = "1000 W";
            this.ptxtPumpPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtPumpPower.Unit = "W";
            this.ptxtPumpPower.VarName = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(21, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 19);
            this.label11.TabIndex = 2;
            this.label11.Text = "电压：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(21, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "电流：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(21, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 3;
            this.label9.Text = "频率：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(21, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 19);
            this.label10.TabIndex = 4;
            this.label10.Text = "功率：";
            // 
            // panelWDatas
            // 
            this.panelWDatas.BgColor = System.Drawing.Color.WhiteSmoke;
            this.panelWDatas.BorderColor = System.Drawing.Color.SteelBlue;
            this.panelWDatas.BorderWidth = 5;
            this.panelWDatas.Controls.Add(this.ptxtLowWPosition);
            this.panelWDatas.Controls.Add(this.ptxtHighWPosition);
            this.panelWDatas.Controls.Add(this.ptxtCurrentWPosition);
            this.panelWDatas.Controls.Add(this.label7);
            this.panelWDatas.Controls.Add(this.label6);
            this.panelWDatas.Controls.Add(this.label5);
            this.panelWDatas.Location = new System.Drawing.Point(48, 48);
            this.panelWDatas.Name = "panelWDatas";
            this.panelWDatas.Size = new System.Drawing.Size(198, 118);
            this.panelWDatas.TabIndex = 9;
            // 
            // ptxtLowWPosition
            // 
            this.ptxtLowWPosition.DataVal = "0.2";
            this.ptxtLowWPosition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtLowWPosition.ForeColor = System.Drawing.Color.Blue;
            this.ptxtLowWPosition.Location = new System.Drawing.Point(102, 82);
            this.ptxtLowWPosition.Name = "ptxtLowWPosition";
            this.ptxtLowWPosition.Size = new System.Drawing.Size(73, 21);
            this.ptxtLowWPosition.TabIndex = 1;
            this.ptxtLowWPosition.Text = "0.2 m";
            this.ptxtLowWPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtLowWPosition.VarName = null;
            // 
            // ptxtHighWPosition
            // 
            this.ptxtHighWPosition.DataVal = "5.00";
            this.ptxtHighWPosition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtHighWPosition.ForeColor = System.Drawing.Color.Blue;
            this.ptxtHighWPosition.Location = new System.Drawing.Point(102, 54);
            this.ptxtHighWPosition.Name = "ptxtHighWPosition";
            this.ptxtHighWPosition.Size = new System.Drawing.Size(73, 21);
            this.ptxtHighWPosition.TabIndex = 1;
            this.ptxtHighWPosition.Text = "5.00 m";
            this.ptxtHighWPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtHighWPosition.VarName = null;
            // 
            // ptxtCurrentWPosition
            // 
            this.ptxtCurrentWPosition.DataVal = "1.00";
            this.ptxtCurrentWPosition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ptxtCurrentWPosition.ForeColor = System.Drawing.Color.Red;
            this.ptxtCurrentWPosition.Location = new System.Drawing.Point(102, 27);
            this.ptxtCurrentWPosition.Name = "ptxtCurrentWPosition";
            this.ptxtCurrentWPosition.Size = new System.Drawing.Size(73, 21);
            this.ptxtCurrentWPosition.TabIndex = 1;
            this.ptxtCurrentWPosition.Text = "1.00 m";
            this.ptxtCurrentWPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ptxtCurrentWPosition.VarName = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(20, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "最低水位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(20, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "最高水位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(20, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "当前水位：";
            // 
            // uArrowControl2
            // 
            this.uArrowControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uArrowControl2.ArrowColor = System.Drawing.Color.Gray;
            this.uArrowControl2.BorderColor = System.Drawing.Color.Blue;
            this.uArrowControl2.Direction =  ArrowDirection.Top;
            this.uArrowControl2.Location = new System.Drawing.Point(388, 285);
            this.uArrowControl2.Name = "uArrowControl2";
            this.uArrowControl2.Size = new System.Drawing.Size(26, 84);
            this.uArrowControl2.TabIndex = 8;
            // 
            // uArrowControl1
            // 
            this.uArrowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uArrowControl1.ArrowColor = System.Drawing.Color.Gray;
            this.uArrowControl1.BorderColor = System.Drawing.Color.Blue;
            this.uArrowControl1.Location = new System.Drawing.Point(850, 265);
            this.uArrowControl1.Name = "uArrowControl1";
            this.uArrowControl1.Size = new System.Drawing.Size(75, 25);
            this.uArrowControl1.TabIndex = 8;
            // 
            // ucPipe7
            // 
            this.ucPipe7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPipe7.FlowDirection =  FlowDirection.Backward;
            this.ucPipe7.FlowLength = 8;
            this.ucPipe7.FlowSpace = 3;
            this.ucPipe7.FlowWidth = 3;
            this.ucPipe7.Location = new System.Drawing.Point(794, 296);
            this.ucPipe7.Name = "ucPipe7";
            this.ucPipe7.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe7.PipeStyle =  PipeStyle.Horizontal_Down_Down;
            this.ucPipe7.Size = new System.Drawing.Size(216, 20);
            this.ucPipe7.TabIndex = 7;
            // 
            // ucPipe2
            // 
            this.ucPipe2.FlowDirection =  FlowDirection.Backward;
            this.ucPipe2.FlowLength = 8;
            this.ucPipe2.FlowSpace = 3;
            this.ucPipe2.FlowWidth = 3;
            this.ucPipe2.Location = new System.Drawing.Point(161, 190);
            this.ucPipe2.Name = "ucPipe2";
            this.ucPipe2.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe2.PipeStyle =  PipeStyle.Horizontal_Down_Down;
            this.ucPipe2.Size = new System.Drawing.Size(222, 20);
            this.ucPipe2.TabIndex = 7;
            // 
            // ucPipe5
            // 
            this.ucPipe5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPipe5.FlowDirection =  FlowDirection.Backward;
            this.ucPipe5.FlowLength = 8;
            this.ucPipe5.FlowSpace = 3;
            this.ucPipe5.FlowWidth = 3;
            this.ucPipe5.Location = new System.Drawing.Point(694, 518);
            this.ucPipe5.Name = "ucPipe5";
            this.ucPipe5.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe5.PipeStyle =  PipeStyle.Horizontal_None_Up;
            this.ucPipe5.Size = new System.Drawing.Size(120, 20);
            this.ucPipe5.TabIndex = 7;
            // 
            // ucPipe4
            // 
            this.ucPipe4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPipe4.FlowDirection =  FlowDirection.Backward;
            this.ucPipe4.FlowLength = 8;
            this.ucPipe4.FlowSpace = 3;
            this.ucPipe4.FlowWidth = 3;
            this.ucPipe4.Location = new System.Drawing.Point(362, 514);
            this.ucPipe4.Name = "ucPipe4";
            this.ucPipe4.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe4.PipeStyle =  PipeStyle.Horizontal_Up_None;
            this.ucPipe4.Size = new System.Drawing.Size(162, 20);
            this.ucPipe4.TabIndex = 7;
            // 
            // ucPipe6
            // 
            this.ucPipe6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPipe6.FlowLength = 8;
            this.ucPipe6.FlowSpace = 3;
            this.ucPipe6.FlowWidth = 3;
            this.ucPipe6.Location = new System.Drawing.Point(794, 315);
            this.ucPipe6.Name = "ucPipe6";
            this.ucPipe6.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe6.PipeStyle =  PipeStyle.Vertical_None_None;
            this.ucPipe6.Size = new System.Drawing.Size(20, 204);
            this.ucPipe6.TabIndex = 7;
            // 
            // ucPipe3
            // 
            this.ucPipe3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ucPipe3.FlowDirection =  FlowDirection.Backward;
            this.ucPipe3.FlowLength = 8;
            this.ucPipe3.FlowSpace = 3;
            this.ucPipe3.FlowWidth = 3;
            this.ucPipe3.Location = new System.Drawing.Point(362, 209);
            this.ucPipe3.Name = "ucPipe3";
            this.ucPipe3.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe3.PipeStyle =  PipeStyle.Vertical_None_None;
            this.ucPipe3.Size = new System.Drawing.Size(20, 307);
            this.ucPipe3.TabIndex = 7;
            // 
            // ucPipe8
            // 
            this.ucPipe8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPipe8.FlowDirection =  FlowDirection.Backward;
            this.ucPipe8.FlowLength = 8;
            this.ucPipe8.FlowSpace = 3;
            this.ucPipe8.FlowWidth = 3;
            this.ucPipe8.Location = new System.Drawing.Point(990, 315);
            this.ucPipe8.Name = "ucPipe8";
            this.ucPipe8.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe8.PipeStyle =  PipeStyle.Vertical_None_None;
            this.ucPipe8.Size = new System.Drawing.Size(20, 274);
            this.ucPipe8.TabIndex = 7;
            // 
            // ucPipe1
            // 
            this.ucPipe1.FlowLength = 8;
            this.ucPipe1.FlowSpace = 3;
            this.ucPipe1.FlowWidth = 3;
            this.ucPipe1.Location = new System.Drawing.Point(161, 209);
            this.ucPipe1.Name = "ucPipe1";
            this.ucPipe1.PipeColor = System.Drawing.Color.LightSlateGray;
            this.ucPipe1.PipeStyle =  PipeStyle.Vertical_None_None;
            this.ucPipe1.Size = new System.Drawing.Size(20, 107);
            this.ucPipe1.TabIndex = 7;
            // 
            // uPump01
            // 
            this.uPump01.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.uPump01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uPump01.BackColor = System.Drawing.Color.DarkGray;
            this.uPump01.LightOffColor = System.Drawing.Color.DimGray;
            this.uPump01.Location = new System.Drawing.Point(492, 363);
            this.uPump01.Name = "uPump01";
            this.uPump01.PumpName = "抽水泵";
            this.uPump01.Size = new System.Drawing.Size(238, 245);
            this.uPump01.TabIndex = 6;
            this.uPump01.ChangedStateClick += new System.EventHandler(this.uPump01_ChangedStateClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1158, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "供水池";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(44, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "储水池";
            // 
            // uStoreTank
            // 
            this.uStoreTank.BackColor = System.Drawing.Color.Transparent;
            this.uStoreTank.BorderColor = System.Drawing.Color.Black;
            this.uStoreTank.Location = new System.Drawing.Point(48, 274);
            this.uStoreTank.Name = "uStoreTank";
            this.uStoreTank.RectWidth = 2;
            this.uStoreTank.Size = new System.Drawing.Size(254, 257);
            this.uStoreTank.TabIndex = 4;
            this.uStoreTank.Value = 80;
            // 
            // uSupplyTank
            // 
            this.uSupplyTank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uSupplyTank.BackColor = System.Drawing.Color.Transparent;
            this.uSupplyTank.BorderColor = System.Drawing.Color.Black;
            this.uSupplyTank.Location = new System.Drawing.Point(913, 386);
            this.uSupplyTank.Name = "uSupplyTank";
            this.uSupplyTank.RectWidth = 2;
            this.uSupplyTank.Size = new System.Drawing.Size(307, 257);
            this.uSupplyTank.TabIndex = 4;
            this.uSupplyTank.Value = 80;
            this.uSupplyTank.ValColor = System.Drawing.Color.RoyalBlue;
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(815, 61);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(255, 42);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "未启动";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // alarmVoltage
            // 
            this.alarmVoltage.AlarmLightColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))))};
            this.alarmVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.alarmVoltage.BackColor = System.Drawing.Color.Transparent;
            this.alarmVoltage.Location = new System.Drawing.Point(923, 134);
            this.alarmVoltage.Name = "alarmVoltage";
            this.alarmVoltage.Size = new System.Drawing.Size(50, 64);
            this.alarmVoltage.TabIndex = 2;
            this.alarmVoltage.TwinkInterval = 100;
            this.alarmVoltage.VarName = null;
            // 
            // uStart
            // 
            this.uStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uStart.BackColor = System.Drawing.Color.Transparent;
            this.uStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uStart.LightfocusColor = System.Drawing.Color.GreenYellow;
            this.uStart.LightNormalColor = System.Drawing.Color.Green;
            this.uStart.Location = new System.Drawing.Point(1136, 21);
            this.uStart.Name = "uStart";
            this.uStart.Size = new System.Drawing.Size(84, 82);
            this.uStart.StateText = "自动";
            this.uStart.TabIndex = 1;
            this.uStart.VarName = null;
            this.uStart.ClickEvent += new System.EventHandler(this.uStart_ClickEvent);
            // 
            // uInPumpVoltage
            // 
            this.uInPumpVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uInPumpVoltage.BackColor = System.Drawing.Color.Transparent;
            this.uInPumpVoltage.BoundaryLineColor = System.Drawing.Color.Red;
            this.uInPumpVoltage.ExternalRoundColor = System.Drawing.Color.Blue;
            this.uInPumpVoltage.FixedText = "电压";
            this.uInPumpVoltage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uInPumpVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.uInPumpVoltage.InsideRoundColor = System.Drawing.Color.Gray;
            this.uInPumpVoltage.Location = new System.Drawing.Point(492, 5);
            this.uInPumpVoltage.MaxValue = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.uInPumpVoltage.MeterDegrees = 180;
            this.uInPumpVoltage.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uInPumpVoltage.Name = "uInPumpVoltage";
            this.uInPumpVoltage.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.uInPumpVoltage.ScaleColor = System.Drawing.Color.DimGray;
            this.uInPumpVoltage.ScaleValueColor = System.Drawing.Color.Blue;
            this.uInPumpVoltage.Size = new System.Drawing.Size(238, 152);
            this.uInPumpVoltage.SplitCount = 10;
            this.uInPumpVoltage.TabIndex = 0;
            this.uInPumpVoltage.TextColor = System.Drawing.Color.Red;
            this.uInPumpVoltage.TextFont = new System.Drawing.Font("华文宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uInPumpVoltage.TextLocation =  TextLocation.Top;
            this.uInPumpVoltage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // uPanel1
            // 
            this.uPanel1.BgColor = System.Drawing.Color.SteelBlue;
            this.uPanel1.Controls.Add(this.btnClose);
            this.uPanel1.Controls.Add(this.btnMin);
            this.uPanel1.Controls.Add(this.label1);
            this.uPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanel1.Location = new System.Drawing.Point(0, 0);
            this.uPanel1.Name = "uPanel1";
            this.uPanel1.Radius = 0;
            this.uPanel1.Size = new System.Drawing.Size(1263, 87);
            this.uPanel1.TabIndex = 0;
            this.uPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uPanel1_MouseDown);
            this.uPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uPanel1_MouseMove);
            this.uPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uPanel1_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1217, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "r";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(1170, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.TabIndex = 1;
            this.btnMin.Text = "0";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("华文宋体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(467, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "自 动 储 水 系 统";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // FrmStoreWater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1263, 774);
            this.Controls.Add(this.uPanel2);
            this.Controls.Add(this.uPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1246, 762);
            this.Name = "FrmStoreWater";
            this.Text = "自动储水系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStoreWater_FormClosing);
            this.Load += new System.EventHandler(this.FrmStoreWater_Load);
            this.uPanel2.ResumeLayout(false);
            this.uPanel2.PerformLayout();
            this.panelPumpDatas.ResumeLayout(false);
            this.panelPumpDatas.PerformLayout();
            this.panelWDatas.ResumeLayout(false);
            this.panelWDatas.PerformLayout();
            this.uPanel1.ResumeLayout(false);
            this.uPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private  UPanel uPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label label1;
        private  UPanel uPanel2;
        private  UInstrumentControl uInPumpVoltage;
        private  ULightControl uStart;
        private System.Windows.Forms.Label lblMsg;
        private  UCAlarmControl alarmVoltage;
        private System.Windows.Forms.Label label3;
        private  UCWaterTank uStoreTank;
        private  UCWaterTank uSupplyTank;
        private System.Windows.Forms.Label label4;
        private  UPump uPump01;
        private  UArrowControl uArrowControl2;
        private  UArrowControl uArrowControl1;
        private  UCPipe ucPipe7;
        private  UCPipe ucPipe2;
        private  UCPipe ucPipe5;
        private  UCPipe ucPipe4;
        private  UCPipe ucPipe6;
        private  UCPipe ucPipe3;
        private  UCPipe ucPipe8;
        private  UCPipe ucPipe1;
        private  UPanel panelPumpDatas;
        private  UPanel panelWDatas;
        private  ParaTextBox ptxtPumpVoltage;
        private  ParaTextBox ptxtPumpEC;
        private  ParaTextBox ptxtPumpFrequency;
        private  ParaTextBox ptxtPumpPower;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private  ParaTextBox ptxtLowWPosition;
        private  ParaTextBox ptxtHighWPosition;
        private  ParaTextBox ptxtCurrentWPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private  ULightControl uStop;
    }
}

