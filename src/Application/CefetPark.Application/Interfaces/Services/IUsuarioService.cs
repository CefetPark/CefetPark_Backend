﻿using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Usuario.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Task<bool> CadastrarAsync(CadastrarUsuarioRequest request);
        //public Task<bool> AtualizarAsync(AtualizarCommonRequest request);
        //public Task<bool> DesativarAsync(int id);
        public Task<ObterUsuarioResponse?> ObterPorIdAsync(int id);
        public Task<ObterUsuarioSegurancaResponse?> ObterPorGuidIdAsync(string aspNetUser_Id);
        public Task<IEnumerable<ObterUsuarioResponse>> ObterTodosAsync();
    }
}
