using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Carro.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class RegistroOcupacaoController : PrincipalController
    {
        private readonly IRegistroOcupacaoService _registroOcupacaoService;

        public RegistroOcupacaoController(IRegistroOcupacaoService registroOcupacaoService, INotificador notificador) : base(notificador)
        {
            _registroOcupacaoService = registroOcupacaoService;
        }


        //[HttpGet("obter-grafico-historico-ocupacao")]
        [HttpGet("obter-grafico-hoje")]
        public async Task<ActionResult> ObterGraficoHistoricoOcupacaoAsync(int? estacionamentoId, [EnumDataType(typeof(DayOfWeek))]  DayOfWeek? dia = null)
        {
            var result = await _registroOcupacaoService.ObterGraficoHistoricoOcupacaoAsync(estacionamentoId, dia);
            return CustomResponse(result);
        }
    }
}
