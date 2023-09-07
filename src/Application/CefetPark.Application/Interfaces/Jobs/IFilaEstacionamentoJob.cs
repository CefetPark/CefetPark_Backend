
namespace CefetPark.Application.Interfaces.Jobs
{
    public interface IFilaEstacionamentoJob
    {
        public Task<bool> TempoEsgotadoRetirarChamadoParaEstacionarAsync(int estacionamentoId, System.Timers.Timer timer);
    }
}
