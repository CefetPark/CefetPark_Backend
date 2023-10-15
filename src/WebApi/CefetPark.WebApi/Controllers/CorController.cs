using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class CorController : PrincipalController
    {
        private readonly ICorService _corService;

        public CorController(ICorService corService, INotificador notificador) : base(notificador)
        {
            _corService = corService;
        }

        [Authorize(Roles = "Adm")]
        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarCommonRequest request)
        {
            var result = await _corService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm")]
        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarCommonRequest request)
        {
            var result = await _corService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _corService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _corService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _corService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }
    }
}
