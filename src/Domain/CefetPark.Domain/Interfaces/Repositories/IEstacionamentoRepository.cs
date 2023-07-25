using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IEstacionamentoRepository
    {
        public Task<Estacionamento> ObterPorIdAsync(int id);
        public Task<IEnumerable<Estacionamento>> ObterTodosAsync();
    }
}
