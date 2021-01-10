using System;
using System.Collections.Generic;
using System.Text;

namespace Jeno.Common.Enum
{
    public enum ProxyStatus
    {
        /// <summary>
        /// 代理连接成功
        /// </summary>
        ProxySuccess = 0,

        /// <summary>
        /// 代理连接上了，但是没有经过测试
        /// </summary>
        ProxyConnButNoTest = 1,

        /// <summary>
        /// 代理状态未知，请求网页响应错误
        /// </summary>
        WebFaild = 2,

        /// <summary>
        /// 代理不可用，请求失败
        /// </summary>
        ProxyFaild = 3,

        /// <summary>
        /// 其他错误
        /// </summary>
        Faild = 4
    }
}
