using CefetPark.Domain.Interfaces.Caching;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CefetPark.Infra.Caching
{
    public class CommonRepositoryCaching : ICommonRepositoryCaching
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;
        private readonly ICommonRepository _commonRepository;

        public CommonRepositoryCaching(IDistributedCache cache, DistributedCacheEntryOptions options, ICommonRepository commonRepository)
        {
            _cache = cache;
            _options = options;
            _commonRepository = commonRepository;
        }
        public async Task<T?> GetAsync<T>(string key) where T : CommonModelCaching
        {
            var resultString = await _cache.GetStringAsync(key.ToString());

            if (resultString == null)
            {
                return default;
            }

            var resultModel = JsonConvert.DeserializeObject<T>(resultString);


            return resultModel;
        }

        public async Task<bool> SetAsync<T>(T value) where T : CommonModelCaching
        {
            var stringValue = JsonConvert.SerializeObject(value);

            await _cache.SetStringAsync(value.ObterKey(), stringValue, _options);

            return true;
        }

        public async Task<bool> RemoveAsync<T>(T value) where T : CommonModelCaching
        {
            await _cache.RemoveAsync(value.ObterKey());

            return true;
        }
    }
}
