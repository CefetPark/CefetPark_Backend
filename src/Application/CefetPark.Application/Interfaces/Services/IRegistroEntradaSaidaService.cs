using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Get;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Put;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IRegistroEntradaSaidaService
    {
        public Task<bool> CadastrarAsync(CadastrarRegistroEntradaSaidaRequest request);
        public Task<bool> AtualizarAsync(AtualizarRegistroEntradaSaidaRequest request);
        public Task<IEnumerable<ObterRegistroEntradaSaidaSemSaidaResponse>> ObterEstacionadosAsync(int estacionamento_Id);
    }
}
