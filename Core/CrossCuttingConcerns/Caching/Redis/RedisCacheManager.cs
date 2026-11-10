using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json; // System.Text.Json yerine bunu kullanıyoruz
using System;
using StackExchange.Redis;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _cache;

        
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public RedisCacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void Add(string key, object data, int duration)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(duration));

            
            var jsonData = JsonConvert.SerializeObject(data, _jsonSettings);
            _cache.SetString(key, jsonData, options);
        }

        public T Get<T>(string key)
        {
            var jsonData = _cache.GetString(key);
            if (jsonData != null)
            {
                return JsonConvert.DeserializeObject<T>(jsonData, _jsonSettings);
            }
            return default;
        }

        public object Get(string key)
        {
            var jsonData = _cache.GetString(key);
            if (jsonData != null)
            {
                
                return JsonConvert.DeserializeObject(jsonData, _jsonSettings);
            }
            return null;
        }

        public bool IsAdd(string key)
        {
            return _cache.GetString(key) != null;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {

            var redis = ConnectionMultiplexer.Connect("redis:6379");
            var endpoint = redis.GetEndPoints().First();
            var server = redis.GetServer(endpoint);
            var db = redis.GetDatabase();


            var keys = server.Keys(pattern: $"*AgarthaProject_*{pattern}*");

            
            foreach (var key in keys)
            {
                db.KeyDelete(key);
            }

        }
    }
}