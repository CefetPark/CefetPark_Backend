using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class AuthController : PrincipalController
    {
        private readonly IAuthService _authService;
        public AuthController(INotificador notificador, IAuthService authService) : base(notificador)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginAuthRequest request)
        {
            var response = await _authService.LoginAsync(request);
            return CustomResponse(response);
        }

        [HttpPost("esqueci-minha-senha")]
        public async Task<ActionResult> EsqueciMinhaSenhaAsync(EsqueciMinhaSenhaRequest request)
        {
            var response = await _authService.EsqueciMinhaSenhaAsync(request);
            return CustomResponse(response);
        }

        [Authorize]
        [HttpPost("redefinir-minha-senha")]
        public async Task<ActionResult> RedefinirMinhaSenhaAsync(RedefinirMinhaSenhaRequest request)
        {
            var response = await _authService.RedefinirMinhaSenhaAsync(request);
            return CustomResponse(response);
        }
    }
}
