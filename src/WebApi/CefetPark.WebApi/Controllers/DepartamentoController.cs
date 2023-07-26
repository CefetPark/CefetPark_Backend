using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Authorize(Roles = "Adm")]
    [Route("[controller]")]
    public class DepartamentoController : PrincipalController
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService, INotificador notificador) : base(notificador)
        {
            _departamentoService = departamentoService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarCommonRequest request)
        {
            var result = await _departamentoService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarCommonRequest request)
        {
            var result = await _departamentoService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _departamentoService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _departamentoService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _departamentoService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }
    }
}
