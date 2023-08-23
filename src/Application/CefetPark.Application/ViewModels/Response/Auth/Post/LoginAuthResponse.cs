using CefetPark.Application.ViewModels.Response.Usuario.Get;

namespace CefetPark.Application.ViewModels.Response.Auth.Post
{
    public class LoginAuthResponse
    {
        public string Token { get; set; }
        public LoginUsuarioAuthResponse Usuario { get; set; }
    }
}
