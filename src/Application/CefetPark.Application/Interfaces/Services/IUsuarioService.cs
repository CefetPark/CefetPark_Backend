using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Common.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Task<bool> CadastrarAsync(CadastrarUsuarioRequest request);
        public Task<bool> CadastrarMassaTesteAsync(List<CadastrarUsuarioRequest> listaRequest);
        public Task<bool> AtualizarAsync(AtualizarCommonRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterCommonResponse?> ObterPorIdAsync(int id);
        public Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync();
    }
}
