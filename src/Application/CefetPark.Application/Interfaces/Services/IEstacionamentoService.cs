using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Application.ViewModels.Request.Estacionamento.Put;
using CefetPark.Application.ViewModels.Response.Estacionamento.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IEstacionamentoService
    {
        public Task<bool> CadastrarAsync(CadastrarEstacionamentoRequest request);
        public Task<bool> AtualizarAsync(AtualizarEstacionamentoRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterEstacionamentoResponse?> ObterPorIdAsync(int id);
        public Task<IEnumerable<ObterEstacionamentoResponse>> ObterTodosAsync();
    }
}
