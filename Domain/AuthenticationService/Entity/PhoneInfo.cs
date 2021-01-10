using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticationService.Entity
{
    public class PhoneInfo
    {
        /// <summary>
        /// 手机内置uudid
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// 总空间单位G
        /// </summary>
        public string TotalSpace { get; set; }

        /// <summary>
        /// 手机类型
        /// </summary>
        public string Plat { get; set; }

        /// <summary>
        /// cpu类型分为32位和64位
        /// </summary>
        public string CpuType { get; set; }

        /// <summary>
        /// 系统版本
        /// </summary>
        public string OSVer { get; set; }

        /// <summary>
        /// 设备屏幕外壳颜色
        /// </summary>
        public string DevColor { get; set; }

        /// <summary>
        /// 手机序列号
        /// </summary>
        public string DevId { get; set; }
    }
}
