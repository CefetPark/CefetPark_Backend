using CefetPark.Application.ViewModels.Request.FilaEstacionamento.Post;
using CefetPark.Application.ViewModels.Response.FilaEstacionamento.Get;
using CefetPark.Domain.Models;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IFilaEstacionamentoService
    {
        public Task<bool> EntrarFilaAsync(EntrarFilaEstacionamentoRequest model);
        public Task<bool> DesistirFilaAsync(int estacionamentoId);
        public Task<ObterFilaEstacionamentoResponse?> ObterFilaAsync(int estacionamentoId);

        public Task<bool> ChamarProximoDaFilaAsync(int estacionamentoId);

    }
}
