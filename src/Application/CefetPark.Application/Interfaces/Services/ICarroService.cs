using CefetPark.Application.ViewModels.Request.Carro.Post;
using CefetPark.Application.ViewModels.Request.Carro.Put;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface ICarroService
    {
        public Task<bool> CadastrarAsync(CadastrarCarroRequest request);
        public Task<bool> AtualizarAsync(AtualizarCarroRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterCarroResponse?> ObterPorIdAsync(int id);
        public Task<IEnumerable<ObterCarroResponse>> ObterTodosAsync();

        public Task<ObterCarroResponse?> ObterPorPlacaAsync(string placa);
    }
}
