using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CefetPark.Infra.Repositories
{
    public class CommonRepository  : ICommonRepository
    {
        private readonly DataContext _dataContext;

        private bool disposed = false;

        public CommonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AdicionarEntidadeAsync(CommonEntity entidade)
        {
            await _dataContext.AddAsync(entidade);
            return true;
        }

        public bool RastrearEntidade(CommonEntity entidade)
        {
            _dataContext.Attach(entidade);
            return true;
        }

        public bool RastrearEntidades(IEnumerable<CommonEntity> entidades)
        {
            _dataContext.AttachRange(entidades);
            return true;
        }

        public async Task<IEnumerable<T>> ObterTodosAsync<T>() where T : CommonEntity
        {
            var result = await _dataContext.Set<T>().ToListAsync();

            return result;
        }
        public async Task<T?> ObterPorIdAsync<T>(int id) where T : CommonEntity
        {
            var result = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id) ;
            return result;
        }

        public async Task<int> SalvarAlteracoesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync<T>(IEnumerable<string> propriedadesRelacionamentos) where T : CommonEntity
        {
            var query = _dataContext.Set<T>().AsQueryable();
            
            foreach (var prop in propriedadesRelacionamentos)
            {
                if (typeof(T).GetProperty(prop) == null) throw new Exception($"Propriedade {prop} não existente na Entidade");
                query = query.Include(prop);
            }

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<T?> ObterPorIdAsync<T>(int id, IEnumerable<string> propriedadesRelacionamentos) where T : CommonEntity
        {
            var query = _dataContext.Set<T>().AsQueryable();

            foreach (var prop in propriedadesRelacionamentos)
            {
                if (typeof(T).GetProperty(prop) == null) throw new Exception($"Propriedade {prop} não existente na Entidade");
                query = query.Include(prop);
            }

            var result = await query.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
