using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Put;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IRegistroEntradaSaidaService
    {
        public Task<bool> CadastrarAsync(CadastrarRegistroEntradaSaidaRequest request);
        public Task<bool> AtualizarAsync(AtualizarRegistroEntradaSaidaRequest request);
        public Task<IEnumerable<ObterRegistroEntradaSaidaResponse>> ObterEstacionadosAsync(int estacionamento_Id);
    }
}
