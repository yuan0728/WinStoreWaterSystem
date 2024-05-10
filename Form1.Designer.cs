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
            this.paraTextBox1 = new WinStoreWaterSystem.ParaTextBox();
            this.uPanel1 = new WinStoreWaterSystem.UPanel();
            this.SuspendLayout();
            // 
            // paraTextBox1
            // 
            this.paraTextBox1.AutoSize = true;
            this.paraTextBox1.DataVal = "12.5";
            this.paraTextBox1.Location = new System.Drawing.Point(210, 9);
            this.paraTextBox1.Name = "paraTextBox1";
            this.paraTextBox1.Size = new System.Drawing.Size(62, 18);
            this.paraTextBox1.TabIndex = 1;
            this.paraTextBox1.Text = "12.5 m";
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
            this.Controls.Add(this.paraTextBox1);
            this.Controls.Add(this.uPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UPanel uPanel1;
        private ParaTextBox paraTextBox1;
    }
}

