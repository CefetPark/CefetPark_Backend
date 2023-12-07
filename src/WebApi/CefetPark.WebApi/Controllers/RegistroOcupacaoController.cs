using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Carro.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class RegistroOcupacaoController : PrincipalController
    {
        private readonly IRegistroOcupacaoService _registroOcupacaoService;

        public RegistroOcupacaoController(IRegistroOcupacaoService registroOcupacaoService, INotificador notificador) : base(notificador)
        {
            _registroOcupacaoService = registroOcupacaoService;
        }

        [Authorize()]
        [HttpGet("obter-grafico-hoje")]
        public async Task<ActionResult> ObterGraficoHojeAsync(int? estacionamentoId)
        {
            var result = await _registroOcupacaoService.ObterGraficoHojeAsync(estacionamentoId);
            return CustomResponse(result);
        }
    }
}
