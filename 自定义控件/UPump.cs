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
            LightOnColor = Color.Orange;
        }
        public event EventHandler ChangedStateClick;//修改水泵状态时触发

        private Color lightOnColor = Color.Orange;
        [DefaultValue(typeof(Color), "Orange"), Description("运行时指示灯的颜色")]
        public Color LightOnColor
        {
            get { return lightOnColor; }
            set
            {
                lightOnColor = value;
                uLight.LightfocusColor = lightOnColor;
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
            }
        }

        private bool actualState = false;
        [DefaultValue(typeof(bool), "False"), Description("水泵状态")]
        public bool ActualState
        {
            get { return actualState; }
            set
            {
                actualState = value;
                if (actualState)
                {
                    uLight.IsOn = true;
                }
                else
                {
                    uLight.IsOn = false;
                }
                uswitchPump.Checked = actualState;
            }
        }






        private void uswitchPump_Click(object sender, EventArgs e)
        {
            ChangedStateClick?.Invoke(this, new EventArgs());
        }
    }
}
