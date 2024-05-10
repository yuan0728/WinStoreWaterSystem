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
    public partial class ParaTextBox : Label
    {
        public ParaTextBox()
        {
            InitializeComponent();
        }

        public event Action<object, ParaTextBoxArgs> DataValClick; // 参数点击事件
        public event Action<object, ParaTextBoxArgs> DataValChanged; // 参数值改变事件
        private string dataVal;
        [DefaultValue(typeof(string), "0.0"), Description("参数值")]
        public string DataVal
        {
            get { return dataVal; }
            set
            {
                if (dataVal != value)
                {
                    dataVal = value;
                    Text = value + " " + unit;
                    // 调用DataValChanged事件
                    DataValChanged?.Invoke(this, new ParaTextBoxArgs(dataVal));
                }
            }
        }
        private string unit;
        [DefaultValue(typeof(string), "m"), Description("单位")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                Text = dataVal + " " + value;
            }
        }
        private string varName;
        [DefaultValue(typeof(string), "varName"), Description("参数名称")]
        public string VarName
        {
            get { return varName; }
            set
            {
                varName = value;
            }
        }

        private void ParaTextBox_Click(object sender, EventArgs e)
        {
            DataValClick?.Invoke(this, new ParaTextBoxArgs(dataVal));
        }
    }
}
