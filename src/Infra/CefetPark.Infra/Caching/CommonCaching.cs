using CefetPark.Domain.Interfaces.Caching;
using CefetPark.Domain.Interfaces.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CefetPark.Infra.Caching
{
    public class CommonCaching : ICommonCaching
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;

        public CommonCaching(IDistributedCache cache, DistributedCacheEntryOptions options)
        {
            _cache = cache;
            _options = options;
        }
        public async Task<T?> GetAsync<T>(string key) where T : IModelCaching
        {
            var resultString = await _cache.GetStringAsync(key.ToString());

            if (resultString == null)
            {
                return default;
            }

            var resultModel = JsonConvert.DeserializeObject<T>(resultString);


            return resultModel;
        }

        public async Task<bool> SetAsync<T>(T value) where T : IModelCaching
        {
            var stringValue = JsonConvert.SerializeObject(value);

            await _cache.SetStringAsync(value.ObterKey(), stringValue, _options);

            return true;
        }

        public async Task<bool> RemoveAsync<T>(T value) where T : IModelCaching
        {
            await _cache.RemoveAsync(value.ObterKey());

            return true;
        }
    }
}
