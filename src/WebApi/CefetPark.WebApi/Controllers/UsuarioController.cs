using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : PrincipalController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(INotificador notificador, IUsuarioService usuarioService) : base(notificador)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Adm")]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarAsync(CadastrarUsuarioRequest request)
        {
            var response = await _usuarioService.CadastrarAsync(request);
            return CustomResponse(response);
        }
    }
}
