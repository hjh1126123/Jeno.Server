using System;
using System.Collections.Generic;
using System.Text;
using FreeRedis;
using SqlSugar;

namespace Jeno.Dto
{
    public class RedisCache : ICacheService
    {
        private RedisClient _redis;

        private string _redisParentKey = string.Empty;
        private string MergeKey(string key)
        {
            if (string.IsNullOrWhiteSpace(_redisParentKey))
            {
                return key;
            }
            else
            {
                return $"{_redisParentKey}:{key}";
            }
        }

        public RedisCache(string redisParentKey)
        {
            _redis = Redis.Mananger.Instance.Get();
            _redisParentKey = redisParentKey;
        }

        public void Add<V>(string key, V value)
        {
            _redis.Set(MergeKey(key), value);
        }

        public void Add<V>(string key, V value, int cacheDurationInSeconds)
        {
            _redis.Set(MergeKey(key), value, cacheDurationInSeconds);
        }

        public bool ContainsKey<V>(string key)
        {
            return _redis.Exists(MergeKey(key));
        }

        public V Get<V>(string key)
        {
            return _redis.Get<V>(MergeKey(key));
        }

        public IEnumerable<string> GetAllKey<V>()
        {
            return _redis.Keys(_redisParentKey);
        }

        public V GetOrCreate<V>(string cacheKey, Func<V> create, int cacheDurationInSeconds = int.MaxValue)
        {
            if (ContainsKey<V>(MergeKey(cacheKey)))
            {
                return Get<V>(MergeKey(cacheKey));
            }
            else
            {
                var result = create();
                Add(MergeKey(cacheKey), result, cacheDurationInSeconds);
                return result;
            }
        }

        public void Remove<V>(string key)
        {
            _redis.Del(MergeKey(key));
        }
    }
}
