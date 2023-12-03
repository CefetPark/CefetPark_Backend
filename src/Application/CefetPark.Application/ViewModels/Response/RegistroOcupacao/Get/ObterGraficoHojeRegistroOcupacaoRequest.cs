

namespace CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get
{
    public class ObterGraficoHojeRegistroOcupacaoRequest
    {
        public ICollection<string> Horarios { get; set; }
        public ICollection<int> MediasQtdLivresPorHorario { get; set; }
    }
}
