﻿

using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Modelo.Post;
using CefetPark.Application.ViewModels.Request.Modelo.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CefetPark.WebApi.Controllers
{
    [Authorize(Roles = "Adm")]
    [Route("[controller]")]
    public class ModeloController : PrincipalController
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService, INotificador notificador) : base(notificador)
        {
            _modeloService = modeloService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarModeloRequest request)
        {
            var result = await _modeloService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarModeloRequest request)
        {
            var result = await _modeloService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _modeloService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _modeloService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _modeloService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }
    }
}
