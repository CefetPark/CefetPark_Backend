using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Convidado.Post;
using CefetPark.Application.ViewModels.Request.Convidado.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class ConvidadoController : PrincipalController
    {
        private readonly IConvidadoService _convidadoService;

        public ConvidadoController(IConvidadoService convidadoService, INotificador notificador) : base(notificador)
        {
            _convidadoService = convidadoService;
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarConvidadoRequest request)
        {
            var result = await _convidadoService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarConvidadoRequest request)
        {
            var result = await _convidadoService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _convidadoService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _convidadoService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _convidadoService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }
    }
}
