using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CefetPark.Infra.Repositories
{
    public class CommonRepository  : ICommonRepository, IDisposable
    {
        private readonly DataContext _dataContext;

        private bool disposed = false;

        public CommonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AdicionarEntidadeAsync<T>(T entidade) where T : CommonEntity
        {
            await _dataContext.AddAsync(entidade);
            return true;
        }

        public bool RastrearEntidade<T>(T entidade) where T : CommonEntity
        {
            _dataContext.Attach(entidade);
            return true;
        }

        public bool RastrearEntidades<T>(ICollection<T> entidades) where T : CommonEntity
        {
            _dataContext.AttachRange(entidades);
            return true;
        }

        public async Task<ICollection<T>> ObterTodosAsync<T>() where T : CommonEntity
        {
            var result = await _dataContext.Set<T>().Where(x => x.EstaAtivo).ToListAsync();

            return result;
        }
        public async Task<T?> ObterPorIdAsync<T>(int id) where T : CommonEntity
        {
            var result = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.EstaAtivo) ;
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

        public async Task<ICollection<T>> ObterTodosAsync<T>(ICollection<string> propriedadesRelacionamentos) where T : CommonEntity
        {
            if (propriedadesRelacionamentos == null) throw new Exception($"propriedadesRelacionamentos não pode ser Null");

            var query = _dataContext.Set<T>().AsQueryable();
            
            foreach (var prop in propriedadesRelacionamentos)
            {
                if (typeof(T).GetProperty(prop) == null) throw new Exception($"Propriedade {prop} não existente na Entidade {typeof(T).Name}");
                query = query.Include(prop);
            }

            var result = await query.Where(x => x.EstaAtivo).ToListAsync();
            return result;
        }

        public async Task<T?> ObterPorIdAsync<T>(int id, ICollection<string> propriedadesRelacionamentos) where T : CommonEntity
        {
            if(propriedadesRelacionamentos == null) throw new Exception($"propriedadesRelacionamentos não pode ser Null");

            var query = _dataContext.Set<T>().AsQueryable();

            foreach (var prop in propriedadesRelacionamentos)
            {
                if (typeof(T).GetProperty(prop) == null) throw new Exception($"Propriedade {prop} não existente na Entidade {typeof(T).Name}");
                query = query.Include(prop);
            }

            var result = await query.FirstOrDefaultAsync(x => x.Id == id && x.EstaAtivo);
            return result;
        }

        public async Task<bool> EntidadeExisteAsync<T>(int id) where T : CommonEntity
        {
            var result = await _dataContext.Set<T>().AnyAsync(x => x.Id == id);

            return result;
        }
    }
}
