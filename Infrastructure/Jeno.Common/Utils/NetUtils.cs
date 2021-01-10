using Jeno.Common.Features;
using RestSharp;
using System;
using System.Text.Json;

namespace Jeno.Common.Utils
{
    /// <summary>
    /// 客户端网络请求工具类
    /// </summary>
    [DI(AutoFacInstanceType = Enum.AutoFacInstanceType.SingleInstance)]
    public class NetUtils
    {
        public NetUtils()
        {
        }

        public T Get<T>(string url, object pars, Action<RestRequest> options = null)
        {
            var type = Method.GET;
            T res = GetApiInfo<T>(url, pars, type, options);

            return res;
        }
        public T Post<T>(string url, object pars, Action<RestRequest> options = null)
        {
            var type = Method.POST;
            T res = GetApiInfo<T>(url, pars, type, options);

            return res;
        }
        public T Delete<T>(string url, object pars, Action<RestRequest> options = null)
        {
            var type = Method.DELETE;
            T res = GetApiInfo<T>(url, pars, type, options);

            return res;
        }
        public T Put<T>(string url, object pars, Action<RestRequest> options = null)
        {
            var type = Method.PUT;
            T res = GetApiInfo<T>(url, pars, type, options);

            return res;
        }

        private T GetApiInfo<T>(string url, object pars, Method type, Action<RestRequest> options)
        {
            var request = new RestRequest(type);

            if (pars != null)
                request.AddObject(pars);

            options?.Invoke(request);

            var client = new RestClient(url);
            client.UseJson();

            //client.CookieContainer = new System.Net.CookieContainer();
            IRestResponse reval = client.Execute(request);

            if (reval.ErrorException != null)
            {
                throw new Exception("请求出错");
            }

            return JsonSerializer.Deserialize<T>(reval.Content);
        }
    }
}
