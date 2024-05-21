using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterSystem.Models
{
    /// <summary>
    /// 从站信息  存储区类
    /// </summary>
    public class StoreRegionInfo
    {
        /// <summary>
        /// 从站地址
        /// </summary>
        public byte SlaveId { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public int FunctionCode { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>
        public ushort StartAddress { get; set; }
        /// <summary>
        /// 读取长度   数量
        /// </summary>
        public ushort Length { get; set; }
    }
}
