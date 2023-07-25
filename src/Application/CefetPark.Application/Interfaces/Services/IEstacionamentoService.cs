using CefetPark.Application.ViewModels.Request.Estacionamento.Post;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IEstacionamentoService
    {
        public Task<bool> CadastrarAsync(CadastrarEstacionamentoRequest request);
    }
}
