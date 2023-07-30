using CefetPark.Application.Interfaces.Services;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Authorize(Roles = "Adm")]
    [Route("[controller]")]
    public class TipoUsuarioController : PrincipalController
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;
        public TipoUsuarioController(INotificador notificador, ITipoUsuarioService tipoUsuarioService) : base(notificador)
        {
            _tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var response = await _tipoUsuarioService.ObterTodosAsync();
            return CustomResponse(response);
        }
    }
}
