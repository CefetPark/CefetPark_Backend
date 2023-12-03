namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IRegistroOcupacaoRepository
    {

        public Task<ICollection<int>> ObterMediasQtdLivresPorHorarioAsync(DateTime dia, ICollection<TimeSpan> horarios, int? estacionamentoId);
    }
}
