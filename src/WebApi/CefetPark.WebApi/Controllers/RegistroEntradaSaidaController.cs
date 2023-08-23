
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{

    [Route("[controller]")]
    public class RegistroEntradaSaidaController : PrincipalController
    {
        private readonly IRegistroEntradaSaidaService _registroEntradaSaidaService;

        public RegistroEntradaSaidaController(IRegistroEntradaSaidaService registroEntradaSaidaService, INotificador notificador) : base(notificador)
        {
            _registroEntradaSaidaService = registroEntradaSaidaService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarRegistroEntradaSaidaRequest request)
        {
            var result = await _registroEntradaSaidaService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarRegistroEntradaSaidaRequest request)
        {
            var result = await _registroEntradaSaidaService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [HttpGet("obter-estacionados/{estacionamento_Id}")]
        public async Task<ActionResult> ObterEstacionadosAsync(int estacionamento_Id)
        {
            var result = await _registroEntradaSaidaService.ObterEstacionadosAsync(estacionamento_Id);
            return CustomResponse(result);
        }
    }
}
