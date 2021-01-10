using Jeno.Common.Features;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Jeno.Common.Utils
{
    /// <summary>
    /// 序列化、反序列化工具类
    /// </summary>
    [DI(AutoFacInstanceType = Enum.AutoFacInstanceType.SingleInstance)]
    public class SerializerUtils
    {
        // Json序列化配置类
        JsonSerializerOptions Options;

        public SerializerUtils()
        {
            Options = new JsonSerializerOptions
            {
                // 定义要读取的 JSON 有效负载中是否允许（和忽略）对象或数组中 JSON 值的列表末尾多余的逗号
                AllowTrailingCommas = true,
                // 允许所有编码器
                Encoder = JavaScriptEncoder.Create(allowedRanges: UnicodeRanges.All),
                // 在确定序列化和反序列化过程中是否忽略 null 值
                IgnoreNullValues = false,
                // 是否不区分属性名的大小写
                PropertyNameCaseInsensitive = true,
                // 对json属性名称使用驼峰命名（有大小写）
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        /// <summary>
        /// Json序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Json<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, Options);
        }

        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T DeJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Json克隆对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Clone<T>(T obj)
        {
            var json = Json(obj);

            return DeJson<T>(json);
        }

        /// <summary>
        /// byte序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            if (obj == null)
                return null;

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                var data = memoryStream.ToArray();
                return data;
            }
        }

        /// <summary>
        /// byte反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            if (data == null)
                return default(T);

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(data))
            {
                var result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}
