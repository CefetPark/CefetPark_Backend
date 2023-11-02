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
    public class MarcaController : PrincipalController
    {
        private readonly IMarcaService _marcaService;
        public MarcaController(IMarcaService marcaService, INotificador notificador) : base(notificador)
        {
            _marcaService = marcaService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarCommonRequest request)
        {
            var result = await _marcaService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarCommonRequest request)
        {
            var result = await _marcaService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _marcaService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var client = new HttpClient();
          var result2 = await client.GetAsync("https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:20775020&key=AIzaSyCHgKH-eygqNT50LdgzEuT6ssaTkDq9y80");
            string content = await result2.Content.ReadAsStringAsync();
            var result = await _marcaService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _marcaService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }
    }
}
