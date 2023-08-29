using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Auth.Post;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Task<bool> CadastrarAsync(CadastrarUsuarioRequest request);

        //public Task<bool> AtualizarAsync(AtualizarCommonRequest request);
        //public Task<bool> DesativarAsync(int id);

        public Task<string> CadastrarListaAsync(List<CadastrarUsuarioRequest> usuarios);
        public Task<ObterUsuarioResponse?> ObterPorIdAsync(int id);
        public Task<ObterUsuarioSegurancaResponse?> ObterPorGuidIdAsync(string aspNetUser_Id);
        public Task<IEnumerable<ObterUsuarioResponse>> ObterTodosAsync();
    }
}
