using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinStoreWaterSystem
{
    public partial class UPump : UserControl
    {
        public UPump()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, true); // 可以接受焦点
            pictureBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.Location = new Point(0, 66);
        }
        public event EventHandler ChangedStateClick;// 修改水泵状态时触发
        private Color lightOnColor = Color.Orange;
        [DefaultValue(typeof(Color), "Orange"), Description("运行时指示灯的颜色")]

        public Color LightOnColor
        {
            get { return lightOnColor; }
            set
            {
                lightOnColor = value;
                uLight.LightfocusColor = lightOnColor;
                //Invalidate();
            }
        }
        private Color lightOffColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("停止时指示灯的颜色")]

        public Color LightOffColor
        {
            get { return lightOffColor; }
            set
            {
                lightOffColor = value;
                uLight.LightNormalColor = lightOffColor;
                //Invalidate();
            }
        }
        private Color lightBorderColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("指示灯的边框颜色")]

        public Color LightBorderColor
        {
            get { return lightBorderColor; }
            set
            {
                lightBorderColor = value;
                uLight.BorderColor = lightBorderColor;
                //Invalidate();
            }
        }
        private string pumpName = "水泵名";
        [DefaultValue(typeof(string), "水泵名"), Description("水泵的名称")]

        public string PumpName
        {
            get { return pumpName; }
            set
            {
                pumpName = value;
                lblName.Text = pumpName;
                //Invalidate();
            }
        }
        private string pumpParaState = "PumpState";
        [DefaultValue(typeof(string), "PumpState"), Description("水泵状态参数名称")]

        public string PumpParaState
        {
            get { return pumpParaState; }
            set
            {
                pumpParaState = value;
                //Invalidate();
            }
        }
        private bool actualState = false;
        [DefaultValue(typeof(bool), "False"), Description("水泵的实际状态")]

        public bool ActualState
        {
            get { return actualState; }
            set
            {
                actualState = value;
                if (value)
                    uLight.LightNormalColor = lightOnColor;
                else
                    uLight.LightNormalColor = lightOffColor;
                uSwitch.Checked = actualState;
                //Invalidate();
            }
        }

        private void UPump_Click(object sender, EventArgs e)
        {
            ChangedStateClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
