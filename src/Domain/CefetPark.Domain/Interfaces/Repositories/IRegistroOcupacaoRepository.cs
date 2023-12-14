using CefetPark.Domain.Models;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IRegistroOcupacaoRepository
    {

        public Task<ICollection<int>> ObterMediasQtdLivresPorHorarioAsync(DayOfWeek? dia, ICollection<HorariosGraficoModel> horarios, int? estacionamentoId);
    }
}
