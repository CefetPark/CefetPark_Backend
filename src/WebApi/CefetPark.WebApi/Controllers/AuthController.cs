using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class AuthController : PrincipalController
    {
        private readonly INotificador _notificador;
        private readonly IAuthService _authService;
        public AuthController(INotificador notificador, IAuthService authService) : base(notificador)
        {
            _notificador = notificador;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(LoginPostRequestAuth request)
        {
            var response = await _authService.LoginAsync(request);
            return CustomResponse(response);
        }
    }
}
