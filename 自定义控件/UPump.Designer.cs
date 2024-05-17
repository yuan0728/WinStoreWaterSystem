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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.uLight = new WinStoreWaterSystem.ULightControl();
            this.uSwitch = new WinStoreWaterSystem.USwitch();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::WinStoreWaterSystem.Properties.Resources.jdb;
            this.pictureBox2.Location = new System.Drawing.Point(0, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 216);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(27, 310);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 24);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "1#水泵";
            // 
            // uLight
            // 
            this.uLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLight.LightfocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.uLight.LightNormalColor = System.Drawing.Color.Gray;
            this.uLight.Location = new System.Drawing.Point(194, 10);
            this.uLight.Name = "uLight";
            this.uLight.Size = new System.Drawing.Size(50, 50);
            this.uLight.StateText = "";
            this.uLight.TabIndex = 3;
            this.uLight.VarName = null;
            // 
            // uSwitch
            // 
            this.uSwitch.Checked = true;
            this.uSwitch.Location = new System.Drawing.Point(3, 14);
            this.uSwitch.Name = "uSwitch";
            this.uSwitch.Size = new System.Drawing.Size(134, 40);
            this.uSwitch.TabIndex = 1;
            this.uSwitch.Texts = new string[] {
        "已开启",
        "已停止"};
            this.uSwitch.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            // 
            // UPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.uLight);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.uSwitch);
            this.Controls.Add(this.pictureBox2);
            this.Name = "UPump";
            this.Size = new System.Drawing.Size(256, 363);
            this.Click += new System.EventHandler(this.UPump_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private USwitch uSwitch;
        private System.Windows.Forms.Label lblName;
        private ULightControl uLight;
    }
}
