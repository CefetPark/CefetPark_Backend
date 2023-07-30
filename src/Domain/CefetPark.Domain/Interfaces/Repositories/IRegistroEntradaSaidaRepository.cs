
using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IRegistroEntradaSaidaRepository
    {
        public Task<IEnumerable<RegistroEntradaSaida>> ObterEstacionadosAsync(int estacionamento_id);
    }
}
