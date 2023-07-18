
namespace CefetPark.Domain.Interfaces.Models
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();
    }
}
