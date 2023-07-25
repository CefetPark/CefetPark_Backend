using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;

namespace CefetPark.Infra.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DataContext _dataContext;

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
    }
}
