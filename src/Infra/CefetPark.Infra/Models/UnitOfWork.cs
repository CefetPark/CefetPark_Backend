
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Infra.Contexts;

namespace CefetPark.Infra.Models
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext _context;
        private bool disposed = false;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
