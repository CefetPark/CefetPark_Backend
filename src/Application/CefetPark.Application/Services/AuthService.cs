
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Auth.Post;

namespace CefetPark.Application.Services
{
    public class AuthService : IAuthService
    {

        public async Task<string> LoginAsync(LoginPostRequestAuth request)
        {
            return "s";
        }
    }
}
