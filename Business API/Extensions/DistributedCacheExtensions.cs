using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BussinessApi.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromHours(1);
            options.SlidingExpiration = unusedExpireTime ?? TimeSpan.FromMinutes(20);

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<List<T>> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if(jsonData is null)
            {
                return default(List<T>);
            }
            
            return JsonSerializer.Deserialize<List<T>>(jsonData);
        }
    }
}
