using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Task<bool> CadastrarAsync(CadastrarUsuarioRequest request);
        public Task<bool> AtualizarAsync(AtualizarCommonRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterCommonResponse?> ObterPorIdAsync(int id);
        public Task<ObterCommonResponse?> ObterPorAspNetUserIdAsync(string aspNetUser_Id);
        public Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync();
    }
}
