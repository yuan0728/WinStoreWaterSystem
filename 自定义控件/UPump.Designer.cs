namespace WinStoreWaterSystem
{
    partial class UPump
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.uLight = new WinStoreWaterSystem.ULightControl();
            this.uswitchPump = new WinStoreWaterSystem.USwitch();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::WinStoreWaterSystem.Properties.Resources.jdb;
            this.pictureBox1.Location = new System.Drawing.Point(3, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(23, 158);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "1#水泵";
            // 
            // uLight
            // 
            this.uLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLight.BackColor = System.Drawing.Color.Transparent;
            this.uLight.LightfocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.uLight.LightNormalColor = System.Drawing.Color.Gray;
            this.uLight.Location = new System.Drawing.Point(119, 3);
            this.uLight.Name = "uLight";
            this.uLight.Size = new System.Drawing.Size(42, 38);
            this.uLight.StateText = "";
            this.uLight.TabIndex = 2;
            this.uLight.VarName = null;
            // 
            // uswitchPump
            // 
            this.uswitchPump.Checked = false;
            this.uswitchPump.Font = new System.Drawing.Font("华文宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uswitchPump.Location = new System.Drawing.Point(12, 9);
            this.uswitchPump.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uswitchPump.Name = "uswitchPump";
            this.uswitchPump.Size = new System.Drawing.Size(94, 26);
            this.uswitchPump.TabIndex = 1;
            this.uswitchPump.Texts = new string[] {
        "已运行",
        "已停止"};
            this.uswitchPump.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.uswitchPump.Click += new System.EventHandler(this.uswitchPump_Click);
            // 
            // UPump
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.uLight);
            this.Controls.Add(this.uswitchPump);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UPump";
            this.Size = new System.Drawing.Size(173, 189);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private USwitch uswitchPump;
        private ULightControl uLight;
        private System.Windows.Forms.Label lblName;
    }
}
