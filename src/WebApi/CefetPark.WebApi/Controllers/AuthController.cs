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
    }
}
