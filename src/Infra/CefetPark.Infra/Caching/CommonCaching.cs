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
        public async Task<T?> GetAsync<T>(int chavePrimaria) where T : IModelCaching
        {
            var key = chavePrimaria.ToString();
            var resultString = await _cache.GetStringAsync(key);

            if (resultString == null)
            {
                return default(T);
            }

            var resultModel = JsonConvert.DeserializeObject<T>(resultString);


            return resultModel;
        }

        public async Task<bool> SetAsync<T>(int chavePrimaria, T value) where T : IModelCaching
        {
            string key = chavePrimaria.ToString();
            var stringValue = JsonConvert.SerializeObject(value);

            await _cache.SetStringAsync(key, stringValue, _options);

            return true;
        }

        public async Task<bool> RemoveAsync<T>(T value) where T : IModelCaching
        {
            var key = value.ObterKey();

            await _cache.RemoveAsync(key.ToString());

            return true;
        }
    }
}
