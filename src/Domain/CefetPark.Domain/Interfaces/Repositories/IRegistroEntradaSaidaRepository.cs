
using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IRegistroEntradaSaidaRepository
    {
        public Task<IEnumerable<RegistroEntradaSaida>> ObterEstacionadosAsync(int estacionamento_id);

        public Task<bool> UsuarioJaEstacionadoAsync(int usuarioId);
        public Task<bool> CarroJaEstacionadoAsync(int carroId);
    }
}
