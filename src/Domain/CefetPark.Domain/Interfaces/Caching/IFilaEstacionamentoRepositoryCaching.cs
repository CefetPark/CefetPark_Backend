
using CefetPark.Domain.Models;

namespace CefetPark.Domain.Interfaces.Caching
{
    public interface IFilaEstacionamentoRepositoryCaching
    {
        public Task<bool> EntrarFilaAsync(EntrarFilaEstacionamento model);
        public Task<bool> DesistirFilaAsync(int estacionamentoId);
        public Task<bool> ChamarProximoDaFilaAsync(int estacionamentoId);
        public Task<FilaEstacionamento?> ObterFilaAsync(int estacionamentoId);

        public Task<bool> LimparChamadoParaEstacionarAsync(int estacionamentoId);

        public Task<bool> ExisteIntegrantesNaFilaAsync(int estacionamentoId);

        public Task<bool> UsuarioEstaNaFilaAsync(int estacionamentoId);

        public Task<bool> SalvarFilaAsync(FilaEstacionamento fila);



    }
}
