using Jeno.Common.Enum;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Jeno.Common.Model
{
    public class ProxyInfo
    {
        /// <summary>
        /// 客户端连接状态
        /// </summary>
        public HttpClient HttpClient { get; set; }

        /// <summary>
        /// 代理连接成功
        /// </summary>
        public ProxyStatus ProxyStatus { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
    }
}
