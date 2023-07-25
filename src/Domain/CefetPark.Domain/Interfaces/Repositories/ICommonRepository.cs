
using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public bool RastrearEntidade(CommonEntity entidade);
        public Task<bool> AdicionarEntidadeAsync(CommonEntity entidade);
        public bool RastrearEntidades(IEnumerable<CommonEntity> entidades);

    }
}
