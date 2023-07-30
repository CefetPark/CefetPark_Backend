﻿using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Modelo.Post;
using CefetPark.Application.ViewModels.Request.Modelo.Put;
using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IModeloService
    {
        public Task<bool> CadastrarAsync(CadastrarModeloRequest request);
        public Task<bool> AtualizarAsync(AtualizarModeloRequest request);
        public Task<bool> DesativarAsync(int id);
        public Task<ObterCommonResponse?> ObterPorIdAsync(int id);
        public Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync();
    }
}
