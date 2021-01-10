using System;
using System.Collections.Generic;
using System.Reflection;
using SqlSugar;

namespace Jeno.Dto
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

        public SqlSugarClient DB;

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="dbType"></param>
        /// <param name="redisParentKey"></param>
        public void Init(string conn, DbType dbType, string redisParentKey = "", bool useRedisCache = true, Action<ConnectionConfig> action = null)
        {
            var config = new ConnectionConfig
            {
                ConnectionString = conn,
                DbType = dbType,
                IsAutoCloseConnection = true,
                IsShardSameThread = true,
                InitKeyType = InitKeyType.Attribute,
                MoreSettings = new ConnMoreSettings()
                {
                    IsAutoRemoveDataCache = true
                }
            };

            if (useRedisCache)
            {
                config.ConfigureExternalServices = new ConfigureExternalServices()
                {
                    DataInfoCacheService = new RedisCache(redisParentKey)
                };
            }

            action?.Invoke(config);

            DB = new SqlSugarClient(config);
        }

        /// <summary>
        /// 同步实体表
        /// </summary>
        /// <returns></returns>
        public bool SyncTable()
        {
            if (DB == null)
                return false;

            try
            {
                DB.CodeFirst.SetStringDefaultLength(128).InitTables(GetTypesByTableAttribute());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取所有实体表
        /// </summary>
        /// <returns></returns>
        public Type[] GetTypesByTableAttribute(params Assembly[] assembly)
        {
            List<Type> tableAssembies = new List<Type>();

            if (assembly == null && assembly.Length <= 0)
            {
                foreach (Type type in Assembly.GetEntryAssembly().GetExportedTypes())
                {
                    foreach (Attribute attribute in type.GetCustomAttributes())
                    {
                        if (attribute is SugarTable)
                        {
                            tableAssembies.Add(type);
                        }
                    }
                }
            }
            else
            {
                foreach (var ass in assembly)
                {
                    foreach (Type type in ass.GetExportedTypes())
                    {
                        foreach (Attribute attribute in type.GetCustomAttributes())
                        {
                            if (attribute is SugarTable)
                            {
                                tableAssembies.Add(type);
                            }
                        }
                    }
                }
            }

            return tableAssembies.ToArray();
        }
    }
}
