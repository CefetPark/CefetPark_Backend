using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Application.ViewModels.Response.Auth.Post;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<LoginAuthResponse> LoginAsync(LoginAuthRequest request);
        public Task<bool> EsqueciMinhaSenhaAsync(EsqueciMinhaSenhaRequest request);
        public Task<bool> RedefinirMinhaSenhaAsync(RedefinirMinhaSenhaRequest request);
    }
}
