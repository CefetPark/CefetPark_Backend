
using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public bool RastrearEntidade(CommonEntity entidade);
        public Task<bool> AdicionarEntidadeAsync(CommonEntity entidade);
        public bool RastrearEntidades(IEnumerable<CommonEntity> entidades);
        public Task<IEnumerable<T>> ObterTodosAsync<T>() where T : CommonEntity;
        public Task<T?> ObterPorIdAsync<T>(int id) where T : CommonEntity;

        public Task<int> SalvarAlteracoesAsync();

    }
}
