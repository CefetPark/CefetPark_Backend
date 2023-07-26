
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IDepartamentoService
    {
        public Task<bool> CadastrarAsync(CadastrarCommonRequest request);
        public Task<bool> AtualizarAsync(AtualizarCommonRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterCommonResponse?> ObterPorIdAsync(int id);
        public Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync();

    }
}
