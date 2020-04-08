using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Infra
{
    public class RedisCache : IRedisCache
    {
        public async Task SetObjectAsync<T>(IDistributedCache cache, string key, T value, TimeSpan? timeout = null)
        {

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeout ?? new TimeSpan(0, 0, 30)
            };
            await cache.SetStringAsync(key, JsonConvert.SerializeObject(value), options);
        }

        public async Task<T> GetObjectAsync<T>(IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
        public async Task<bool> ExistObjectAsync(IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);
            return value != null;
        }
    }
}
