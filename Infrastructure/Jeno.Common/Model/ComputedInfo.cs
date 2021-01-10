using Masuit.Tools.Hardware;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Jeno.Common.Model
{
    /// <summary>
    /// 电脑信息模型
    /// </summary>
    public class ComputedInfo
    {
        /// <summary>
        /// Cpu信息
        /// </summary>
        public List<CpuInfo> CpuInfos { get; set; }

        /// <summary>
        /// 物理内存使用率描述
        /// </summary>
        public string MemoryPData { get; set; }

        /// <summary>
        /// 虚拟内存使用率描述
        /// </summary>
        public string MemoryVData { get; set; }

        /// <summary>
        /// 磁盘总空间
        /// </summary>
        public Dictionary<string, string> DiskTotal { get; set; }

        /// <summary>
        /// 磁盘剩余空间
        /// </summary>
        public Dictionary<string, string> FreeDisk { get; set; }

        /// <summary>
        /// 本机所有IP地址
        /// </summary>
        public List<UnicastIPAddressInformation> AllLocalIP { get; set; }

        /// <summary>
        /// 网络传输速率
        /// </summary>
        public double NetData { get; set; }
    }
}
