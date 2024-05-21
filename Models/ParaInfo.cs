using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterSystem.Models
{
    /// <summary>
    /// 参数信息的封装
    /// </summary>
    public class ParaInfo
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParaName { get; set; }
        /// <summary>
        /// 从站地址
        /// </summary>
        public byte SlaveId { get; set; }
        /// <summary>
        /// 寄存器地址
        /// </summary>
        public ushort Address { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 如果是浮点数，小数的位置
        /// </summary>
        public int DecimalCount { get; set; }
    }
}
