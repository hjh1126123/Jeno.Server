using Masuit.Tools.Hardware;
using System;
using Jeno.Common.Features;

namespace Jeno.Common.Utils
{
    /// <summary>
    /// 系统信息、系统操作工具类
    /// </summary>
    [DI(AutoFacInstanceType = Enum.AutoFacInstanceType.SingleInstance)]
    public class SystemUtils
    {
        public SystemUtils()
        {
        }

        /// <summary>
        /// 获取性能相关信息
        /// </summary>
        /// <returns></returns>
        public Model.ComputedInfo GetComputedInfo()
        {
            return new Model.ComputedInfo
            {
                CpuInfos = SystemInfo.GetCpuInfo(),
                MemoryPData = SystemInfo.GetMemoryPData(),
                MemoryVData = SystemInfo.GetMemoryVData(),
                DiskTotal = SystemInfo.DiskTotalSpace(),
                FreeDisk = SystemInfo.DiskFree(),
                AllLocalIP = SystemInfo.GetLocalIPs(),
                NetData = SystemInfo.GetNetData(NetData.ReceivedAndSent)
            };
        }
    }
}
