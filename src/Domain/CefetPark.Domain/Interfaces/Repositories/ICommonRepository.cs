
using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public bool RastrearEntidade<T>(T entidade) where T : CommonEntity;
        public Task<bool> AdicionarEntidadeAsync<T>(T entidade) where T : CommonEntity;
        public bool RastrearEntidades<T>(ICollection<T> entidades) where T : CommonEntity;
        public Task<ICollection<T>> ObterTodosAsync<T>() where T : CommonEntity;
        public Task<ICollection<T>> ObterTodosAsync<T>(ICollection<string> propriedadesRelacionamentos) where T : CommonEntity;
        public Task<T?> ObterPorIdAsync<T>(int id) where T : CommonEntity;
        public Task<bool> EntidadeExisteAsync<T>(int id) where T : CommonEntity;

        public Task<T?> ObterPorIdAsync<T>(int id, ICollection<string> propriedadesRelacionamentos) where T : CommonEntity;

        public Task<int> SalvarAlteracoesAsync();

    }
}
