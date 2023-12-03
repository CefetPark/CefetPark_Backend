using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using CefetPark.Domain.Interfaces.Repositories;

namespace CefetPark.Application.Services
{
    public class RegistroOcupacaoService : IRegistroOcupacaoService
    {
        private readonly IRegistroOcupacaoRepository _registroOcupacaoRepository;
        public RegistroOcupacaoService(IRegistroOcupacaoRepository registroOcupacaoRepository)
        {
                _registroOcupacaoRepository = registroOcupacaoRepository;
        }
        public async Task<ObterGraficoHojeRegistroOcupacaoRequest> ObterGraficoHojeAsync()
        {
            var horarios = new List<TimeSpan>()
            {
                new TimeSpan(7, 0, 0),
                new TimeSpan(9, 0, 0),
                new TimeSpan(11, 0, 0),
                new TimeSpan(13, 0, 0),
                new TimeSpan(15, 0, 0),
                new TimeSpan(17, 0, 0),
                new TimeSpan(19, 0, 0),
                new TimeSpan(21, 0, 0),
            };
            var medias = await _registroOcupacaoRepository.ObterMediasQtdLivresPorHorarioAsync(DateTime.Now, horarios);


            var response = new ObterGraficoHojeRegistroOcupacaoRequest
            {
                Horarios = horarios.Select(x => x.ToString("hh")).ToList(),
                MediasQtdLivresPorHorario = medias
            };

            return response;

        }
    }
}
