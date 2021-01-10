using Jeno.Common.Features;
using MihaZupan;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Jeno.Common
{
    /// <summary>
    /// 代理工具类
    /// </summary>
    [DI(AutoFacInstanceType = Enum.AutoFacInstanceType.SingleInstance)]
    public class ProxyUtils
    {
        public ProxyUtils()
        {
        }

        /// <summary>
        /// 连接代理
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<Model.ProxyInfo> AsyncConnProxy(string ip, int port, string username, string pass, int timeout = 10, string url = "", HttpClientHandler httpClientHandler = null)
        {
            Model.ProxyInfo proxyInfo = new Model.ProxyInfo();

            try
            {
                var httpClient = AsyncConnProxy(ip, port, username, pass, timeout, httpClientHandler);

                if (!string.IsNullOrWhiteSpace(url))
                {
                    var isSuccess = await AsyncCheckProxyHandle(httpClient, url);
                    if (isSuccess)
                    {
                        proxyInfo.ProxyStatus = Enum.ProxyStatus.ProxySuccess;
                        proxyInfo.Message = "代理连接成功";
                    }
                    else
                    {
                        proxyInfo.ProxyStatus = Enum.ProxyStatus.ProxyFaild;
                        proxyInfo.Message = "代理连接成功，但是代理连接测试失败";
                    }
                }
                else
                {
                    proxyInfo.ProxyStatus = Enum.ProxyStatus.ProxyConnButNoTest;
                    proxyInfo.Message = "代理已连接，但是没有测试";
                }

            }
            catch (Exception ex)
            {
                proxyInfo.Message = ex.Message;
                proxyInfo.ProxyStatus = Enum.ProxyStatus.Faild;
            }

            return proxyInfo;
        }

        /// <summary>
        /// 异步检查代理（访问地址需可以进行访问）
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <param name="url">访问地址</param>
        /// <param name="timeOut">超时时间（秒）</param>
        /// <returns></returns>
        private async Task<bool> AsyncCheckProxyHandle(HttpClient httpClient, string url)
        {
            try
            {
                var result = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));

                return result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 异步连接代理
        /// </summary>
        /// <returns></returns>
        private HttpClient AsyncConnProxy(string ip, int port, string username, string pass, int timeout, HttpClientHandler httpClientHandler = null)
        {
            HttpToSocks5Proxy proxy;

            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(pass))
            {
                proxy = new HttpToSocks5Proxy(ip, port);
            }
            else
            {
                proxy = new HttpToSocks5Proxy(ip, port, username, pass);
            }

            if (httpClientHandler != null)
            {
                httpClientHandler.Proxy = proxy;
            }
            else
            {
                httpClientHandler = new HttpClientHandler { Proxy = proxy };
            }

            var httpClient = new HttpClient(httpClientHandler, false);

            // httpClient 配置
            httpClient.Timeout = new TimeSpan(0, 0, timeout);

            return httpClient;
        }
    }
}
