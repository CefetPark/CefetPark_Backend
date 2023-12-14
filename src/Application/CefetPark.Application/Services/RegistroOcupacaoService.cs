using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Domain.Models;

namespace CefetPark.Application.Services
{
    public class RegistroOcupacaoService : IRegistroOcupacaoService
    {
        private readonly IRegistroOcupacaoRepository _registroOcupacaoRepository;
        public RegistroOcupacaoService(IRegistroOcupacaoRepository registroOcupacaoRepository)
        {
            _registroOcupacaoRepository = registroOcupacaoRepository;
        }
        public async Task<ObterGraficoHojeRegistroOcupacaoRequest> ObterGraficoHistoricoOcupacaoAsync(int? estacionamentoId, DayOfWeek? dia)
        {
            var horarios = new List<HorariosGraficoModel>()
            {
                new HorariosGraficoModel{  Inicial = new TimeSpan(7,0,0), Final = new TimeSpan(9,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(9,0,0), Final = new TimeSpan(11,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(11,0,0), Final = new TimeSpan(13,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(13,0,0), Final = new TimeSpan(15,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(15,0,0), Final = new TimeSpan(17,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(17,0,0), Final = new TimeSpan(19,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(19,0,0), Final = new TimeSpan(21,0,0)},
                new HorariosGraficoModel{  Inicial = new TimeSpan(21,0,0), Final = new TimeSpan(23,0,0)},

        };
            var medias = await _registroOcupacaoRepository.ObterMediasQtdLivresPorHorarioAsync(dia, horarios, estacionamentoId);


            var response = new ObterGraficoHojeRegistroOcupacaoRequest
            {
                Horarios = horarios.Select(x => x.Inicial.ToString("hh")).ToList(),
                MediasQtdLivresPorHorario = medias
            };

            return response;

        }
    }
}
