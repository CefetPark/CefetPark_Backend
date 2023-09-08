using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Models;

namespace CefetPark.Domain.Interfaces.Caching
{
    public interface ICommonRepositoryCaching
    {
        public Task<T?> GetAsync<T>(string key) where T : CommonModelCaching;

        public Task<bool> SetAsync<T>(T value) where T : CommonModelCaching;

        public Task<bool> RemoveAsync<T>(T value) where T : CommonModelCaching;
    }
}
