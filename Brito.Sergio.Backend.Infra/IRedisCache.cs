using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Infra
{
    public interface IRedisCache
    {
        Task<bool> ExistObjectAsync(IDistributedCache cache, string key);
        Task<T> GetObjectAsync<T>(IDistributedCache cache, string key);
        Task SetObjectAsync<T>(IDistributedCache cache, string key, T value, TimeSpan? timeout = null);
    }
}