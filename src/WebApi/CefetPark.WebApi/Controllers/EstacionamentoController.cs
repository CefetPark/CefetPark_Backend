using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Application.ViewModels.Request.Estacionamento.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class EstacionamentoController : PrincipalController
    {
        private readonly IEstacionamentoService _estacionamentoService;
        public EstacionamentoController(IEstacionamentoService estacionamentoService,INotificador notificador) : base(notificador)
        {
            _estacionamentoService = estacionamentoService;
        }
        
        [Authorize(Roles = "Adm")]
        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarEstacionamentoRequest request)
        {
            var result = await _estacionamentoService.CadastrarAsync(request);
            return CustomResponse(result);
        }
        
        [Authorize(Roles = "Adm")]
        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarEstacionamentoRequest request)
        {
            var result = await _estacionamentoService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _estacionamentoService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _estacionamentoService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _estacionamentoService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }

    }
}
