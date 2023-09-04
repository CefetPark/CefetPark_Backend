using CefetPark.Domain.Interfaces.Models;

namespace CefetPark.Domain.Interfaces.Caching
{
    public interface ICommonCaching
    {
        public Task<T?> GetAsync<T>(int chavePrimaria) where T : IModelCaching;

        public Task<bool> SetAsync<T>(int chavePrimaria, T value) where T : IModelCaching;

        public Task<bool> RemoveAsync<T>(T value) where T : IModelCaching;
    }
}
