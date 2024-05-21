namespace WinStoreWaterSystem
{
    partial class Form1
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
            this.uArrowControl1 = new WinStoreWaterSystem.UArrowControl();
            this.uPump1 = new WinStoreWaterSystem.UPump();
            this.ucPipe1 = new WinStoreWaterSystem.UCPipe();
            this.uSwitch1 = new WinStoreWaterSystem.USwitch();
            this.ucAlarmControl1 = new WinStoreWaterSystem.UCAlarmControl();
            this.ucWaterTank1 = new WinStoreWaterSystem.UCWaterTank();
            this.uLightControl1 = new WinStoreWaterSystem.ULightControl();
            this.paraTextBox1 = new WinStoreWaterSystem.ParaTextBox();
            this.uPanel1 = new WinStoreWaterSystem.UPanel();
            this.SuspendLayout();
            // 
            // uArrowControl1
            // 
            this.uArrowControl1.ArrowColor = System.Drawing.Color.Blue;
            this.uArrowControl1.Direction = WinStoreWaterSystem.ArrowDirection.Top;
            this.uArrowControl1.Location = new System.Drawing.Point(278, 171);
            this.uArrowControl1.Name = "uArrowControl1";
            this.uArrowControl1.Size = new System.Drawing.Size(50, 100);
            this.uArrowControl1.TabIndex = 8;
            // 
            // uPump1
            // 
            this.uPump1.ActualState = true;
            this.uPump1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uPump1.Location = new System.Drawing.Point(2, 124);
            this.uPump1.Name = "uPump1";
            this.uPump1.Size = new System.Drawing.Size(235, 366);
            this.uPump1.TabIndex = 7;
            // 
            // ucPipe1
            // 
            this.ucPipe1.FlowDirection = WinStoreWaterSystem.FlowDirection.Backward;
            this.ucPipe1.IsFlow = true;
            this.ucPipe1.Location = new System.Drawing.Point(840, 12);
            this.ucPipe1.Name = "ucPipe1";
            this.ucPipe1.PipeStyle = WinStoreWaterSystem.PipeStyle.Horizontal_Up_None;
            this.ucPipe1.Size = new System.Drawing.Size(200, 30);
            this.ucPipe1.TabIndex = 6;
            // 
            // uSwitch1
            // 
            this.uSwitch1.Checked = false;
            this.uSwitch1.Location = new System.Drawing.Point(638, 2);
            this.uSwitch1.Name = "uSwitch1";
            this.uSwitch1.Size = new System.Drawing.Size(196, 74);
            this.uSwitch1.SwitchType = WinStoreWaterSystem.SwitchType.Line;
            this.uSwitch1.TabIndex = 5;
            this.uSwitch1.Texts = new string[] {
        "开",
        "关"};
            // 
            // ucAlarmControl1
            // 
            this.ucAlarmControl1.AlarmLightColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.ucAlarmControl1.Location = new System.Drawing.Point(503, 2);
            this.ucAlarmControl1.Name = "ucAlarmControl1";
            this.ucAlarmControl1.Size = new System.Drawing.Size(103, 116);
            this.ucAlarmControl1.TabIndex = 4;
            this.ucAlarmControl1.TwinkInterval = 100;
            this.ucAlarmControl1.VarName = null;
            // 
            // ucWaterTank1
            // 
            this.ucWaterTank1.Location = new System.Drawing.Point(383, 2);
            this.ucWaterTank1.Name = "ucWaterTank1";
            this.ucWaterTank1.RectWidth = 2;
            this.ucWaterTank1.Size = new System.Drawing.Size(93, 116);
            this.ucWaterTank1.TabIndex = 3;
            this.ucWaterTank1.Value = 70;
            // 
            // uLightControl1
            // 
            this.uLightControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uLightControl1.Location = new System.Drawing.Point(269, 9);
            this.uLightControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uLightControl1.Name = "uLightControl1";
            this.uLightControl1.Size = new System.Drawing.Size(80, 80);
            this.uLightControl1.TabIndex = 2;
            this.uLightControl1.VarName = null;
            // 
            // paraTextBox1
            // 
            this.paraTextBox1.AutoSize = true;
            this.paraTextBox1.DataVal = "12.5";
            this.paraTextBox1.Location = new System.Drawing.Point(210, 9);
            this.paraTextBox1.Name = "paraTextBox1";
            this.paraTextBox1.Size = new System.Drawing.Size(62, 18);
            this.paraTextBox1.TabIndex = 1;
            this.paraTextBox1.Text = "12.5 V";
            this.paraTextBox1.Unit = "V";
            this.paraTextBox1.VarName = null;
            // 
            // uPanel1
            // 
            this.uPanel1.BgColor = System.Drawing.Color.White;
            this.uPanel1.BgColor2 = System.Drawing.Color.IndianRed;
            this.uPanel1.BorderColor = System.Drawing.Color.IndianRed;
            this.uPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.uPanel1.Location = new System.Drawing.Point(2, 2);
            this.uPanel1.Name = "uPanel1";
            this.uPanel1.Radius = 10;
            this.uPanel1.Size = new System.Drawing.Size(202, 116);
            this.uPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 739);
            this.Controls.Add(this.uArrowControl1);
            this.Controls.Add(this.uPump1);
            this.Controls.Add(this.ucPipe1);
            this.Controls.Add(this.uSwitch1);
            this.Controls.Add(this.ucAlarmControl1);
            this.Controls.Add(this.ucWaterTank1);
            this.Controls.Add(this.uLightControl1);
            this.Controls.Add(this.paraTextBox1);
            this.Controls.Add(this.uPanel1);
            this.Name = "Form1";
            this.Text = "自动储水系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UPanel uPanel1;
        private ParaTextBox paraTextBox1;
        private ULightControl uLightControl1;
        private UCWaterTank ucWaterTank1;
        private UCAlarmControl ucAlarmControl1;
        private USwitch uSwitch1;
        private UCPipe ucPipe1;
        private UPump uPump1;
        private UArrowControl uArrowControl1;
    }
}

