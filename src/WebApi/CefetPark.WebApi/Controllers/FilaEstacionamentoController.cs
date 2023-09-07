using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.FilaEstacionamento.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FilaEstacionamentoController : PrincipalController
    {
        private readonly IFilaEstacionamentoService _filaEstacionamentoService;
        public FilaEstacionamentoController(IFilaEstacionamentoService filaEstacionamentoService , INotificador notificador) : base(notificador)
        {
            _filaEstacionamentoService = filaEstacionamentoService;
        }


        [HttpPost("entrar")]
        public async Task<IActionResult> EntrarFilaAsync(EntrarFilaEstacionamentoRequest request)
        {
            var result = await _filaEstacionamentoService.EntrarFilaAsync(request);
            return CustomResponse(result);
        }

        [HttpDelete("desistir/estacionamentoId/{estacionamentoId}")]
        public async Task<IActionResult> DesistirFilaAsync(int estacionamentoId)
        {
            var result = await _filaEstacionamentoService.DesistirFilaAsync(estacionamentoId);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> ObterFilaAsync(int estacionamentoId)
        {
            var result = await _filaEstacionamentoService.ObterFilaAsync(estacionamentoId);
            return CustomResponse(result);
        }
    }
}
