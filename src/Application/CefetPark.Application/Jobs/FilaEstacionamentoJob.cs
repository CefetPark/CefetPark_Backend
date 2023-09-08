
using CefetPark.Application.Interfaces.Jobs;
using CefetPark.Domain.Interfaces.Caching;
using System.Timers;

namespace CefetPark.Application.Jobs
{
    public class FilaEstacionamentoJob : IFilaEstacionamentoJob
    {
        private readonly IFilaEstacionamentoRepositoryCaching _filaEstacionamentoCaching;

        public FilaEstacionamentoJob(IFilaEstacionamentoRepositoryCaching filaEstacionamentoCaching)
        {
            _filaEstacionamentoCaching = filaEstacionamentoCaching;
        }

        public async Task<bool> TempoEsgotadoRetirarChamadoParaEstacionarAsync(int estacionamentoId, System.Timers.Timer timer)
        {
            var fila = await _filaEstacionamentoCaching.ObterFilaAsync(estacionamentoId);

            if(fila != null)
            {
                await _filaEstacionamentoCaching.LimparChamadoParaEstacionarAsync(estacionamentoId);
            }

            timer.Stop();
            return true;
        }

    }
}
