
using CefetPark.Application.ViewModels.Request.Convidado.Post;
using CefetPark.Application.ViewModels.Request.Convidado.Put;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Convidado.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IConvidadoService
    {
        public Task<bool> CadastrarAsync(CadastrarConvidadoRequest request);
        public Task<bool> AtualizarAsync(AtualizarConvidadoRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterConvidadoResponse?> ObterPorIdAsync(int id);
        public Task<IEnumerable<ObterConvidadoResponse>> ObterTodosAsync();
    }
}
