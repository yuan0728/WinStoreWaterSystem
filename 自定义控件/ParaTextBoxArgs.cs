using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterSystem
{
    /// <summary>
    /// 参数文本框事件参数类
    /// </summary>
    public class ParaTextBoxArgs:EventArgs
    {
        public string DataVal { get; set; }
        public ParaTextBoxArgs(string val)
        {
            DataVal = val;
        }
    }
}
