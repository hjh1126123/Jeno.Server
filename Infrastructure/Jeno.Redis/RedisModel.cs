namespace Jeno.Redis
{
    public class RedisModel
    {
        private string protocol;
        private string ip;
        private string user;
        private int? port;
        private string password;
        private int? defaultDataBase;
        private int? minPoolSize;
        private int? maxPoolSize;
        private int? idleTimeout;
        private int? connectTimeout;
        private int? receiveTimeout;
        private int? sendTimeout;
        private string encoding;
        private bool? ssl;
        private string name;
        private string prefix;
        private string custom;

        /// <summary>
        /// Redis 对象
        /// </summary>
        /// <param name="protocol">redis 协议 默认 RESP2 （RESP3需要6.0以上版本）</param>
        /// <param name="ip">redis 连接地址</param>
        /// <param name="user">redis 服务器用户名</param>
        /// <param name="port">redis 连接端口</param>
        /// <param name="password">redis 连接密码</param>
        /// <param name="defaultDataBase">redis 默认数据库 默认0</param>
        /// <param name="minPoolSize">最大连接池</param>
        /// <param name="maxPoolSize">最小连接池</param>
        /// <param name="idleTimeout">连接对象在连接池中的空闲时间</param>
        /// <param name="connectTimeout">连接超时时间</param>
        /// <param name="receiveTimeout">接收超时时间</param>
        /// <param name="sendTimeout">发送超时时间</param>
        /// <param name="encoding">编码 默认 utf-8</param>
        /// <param name="ssl">是否启用加密传输</param>
        /// <param name="name">连接名</param>
        /// <param name="prefix">key前缀</param>
        /// <param name="custom">自定义字符串</param>
        public RedisModel(string protocol = null, string ip = null, int? port = null, string password = null, string user = null, int? defaultDataBase = null, int? minPoolSize = null, int? maxPoolSize = null, int? idleTimeout = null, int? connectTimeout = null, int? receiveTimeout = null, int? sendTimeout = null, string encoding = null, bool? ssl = null, string name = null, string prefix = null, string custom = null)
        {
            this.protocol = protocol;
            this.ip = ip;
            this.user = user;
            this.port = port;
            this.password = password;
            this.defaultDataBase = defaultDataBase;
            this.minPoolSize = minPoolSize;
            this.maxPoolSize = maxPoolSize;
            this.idleTimeout = idleTimeout;
            this.connectTimeout = connectTimeout;
            this.receiveTimeout = receiveTimeout;
            this.sendTimeout = sendTimeout;
            this.encoding = encoding;
            this.ssl = ssl;
            this.name = name;
            this.prefix = prefix;
            this.custom = custom;
        }

        public override string ToString()
        {
            var conn = string.Empty;

            if (!string.IsNullOrWhiteSpace(custom))
            {
                conn += custom;
            }

            if (!string.IsNullOrWhiteSpace(ip))
            {
                conn += $"{ip}:{port}";
            }

            if (!string.IsNullOrWhiteSpace(protocol))
            {
                conn += $"protocol={protocol}";
            }

            if (!string.IsNullOrWhiteSpace(user))
            {
                conn += $",user={user}";
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                conn += $",password={password}";
            }

            if (!string.IsNullOrWhiteSpace(encoding))
            {
                conn += $",encoding={encoding}";
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                conn += $",name={name}";
            }

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                conn += $",prefix={prefix}";
            }

            if (defaultDataBase != null && defaultDataBase.HasValue)
            {
                conn += $",defaultDatabase={defaultDataBase}";
            }

            if (maxPoolSize != null && maxPoolSize.HasValue)
            {
                conn += $",max poolsize={maxPoolSize}";
            }

            if (minPoolSize != null && minPoolSize.HasValue)
            {
                conn += $",min poolsize={minPoolSize}";
            }

            if (idleTimeout != null && idleTimeout.HasValue)
            {
                conn += $",idleTimeout={minPoolSize}";
            }

            if (connectTimeout != null && connectTimeout.HasValue)
            {
                conn += $",connectTimeout={connectTimeout}";
            }

            if (receiveTimeout != null && receiveTimeout.HasValue)
            {
                conn += $",receiveTimeout={receiveTimeout}";
            }

            if (sendTimeout != null && sendTimeout.HasValue)
            {
                conn += $",sendTimeout={sendTimeout}";
            }

            if (ssl != null && ssl.HasValue)
            {
                conn += $",ssl={ssl}";
            }

            return conn;
        }
    }
}
