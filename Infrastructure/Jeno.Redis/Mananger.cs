using FreeRedis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jeno.Redis
{
    public class Mananger
    {
        /// <summary>
        /// 惰性单例
        /// </summary>
        private static readonly Lazy<Mananger> lazy = new Lazy<Mananger>(() =>
        {
            return new Mananger();
        });

        public static Mananger Instance { get { return lazy.Value; } }

        private Mananger()
        {

        }

        /// <summary>
        /// redis客户端对象
        /// </summary>
        private RedisClient _cli;


        /// <summary>
        /// 构建标准读写分离池redis服务
        /// </summary>
        /// <param name="write"></param>
        /// <param name="reads"></param>
        public void BuildPooling(RedisModel write, RedisModel[] reads)
        {
            try
            {
                List<ConnectionStringBuilder> _conns = new List<ConnectionStringBuilder>();

                foreach (var _read in reads)
                {
                    _conns.Add(_read.ToString());
                }

                _cli = new RedisClient(write.ToString(), _conns.ToArray());
                _cli.Serialize = obj => JsonSerializer.Serialize(obj);
                _cli.Deserialize = (json, type) => JsonSerializer.Deserialize(json, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 构建哨兵高可用redis服务
        /// </summary>
        /// <param name="master">主库</param>
        /// <param name="sentinels">哨兵</param>
        /// <param name="isSlave">是否读写分离</param>
        public void BuildSentinel(bool isSlave, RedisModel master, params RedisModel[] sentinels)
        {
            try
            {
                List<string> _conns = new List<string>();

                foreach (var _sentinel in sentinels)
                {
                    _conns.Add(_sentinel.ToString());
                }

                _cli = new RedisClient(master.ToString(), _conns.ToArray(), isSlave);
                _cli.Serialize = obj => JsonSerializer.Serialize(obj);
                _cli.Deserialize = (json, type) => JsonSerializer.Deserialize(json, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 构建集群redis服务
        /// </summary>
        /// <param name="conns">redis 集群对象</param>
        public void BuildCluster(params RedisModel[] conns)
        {
            try
            {
                List<ConnectionStringBuilder> _conns = new List<ConnectionStringBuilder>();

                foreach (var _conn in conns)
                {
                    _conns.Add(_conn.ToString());
                }

                _cli = new RedisClient(_conns.ToArray());
                _cli.Serialize = obj => JsonSerializer.Serialize(obj);
                _cli.Deserialize = (json, type) => JsonSerializer.Deserialize(json, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取redis对象
        /// </summary>
        /// <returns></returns>
        public RedisClient Get()
        {
            return _cli;
        }
    }
}
