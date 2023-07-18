using CefetPark.Application.ViewModels.Request.Auth.Post;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<string> LoginAsync(LoginPostRequestAuth request);
    }
}
