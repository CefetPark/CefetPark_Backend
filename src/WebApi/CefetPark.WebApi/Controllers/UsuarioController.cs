﻿using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Services;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Request.Usuario.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsuarioController : PrincipalController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(INotificador notificador, IUsuarioService usuarioService) : base(notificador)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost()]
        public async Task<ActionResult> CadastrarAsync(CadastrarUsuarioRequest request)
        {
            var response = await _usuarioService.CadastrarAsync(request);
            return CustomResponse(response);
        }

        [Authorize(Roles = "Adm")]
        [HttpPost("cadastrarLista")]
        public async Task<ActionResult> CadastrarListaAsync(List<CadastrarUsuarioRequest> request)
        {
            var response = await _usuarioService.CadastrarListaAsync(request);
            return CustomResponse(response);
        }

        [Authorize(Roles = "Adm")]
        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _usuarioService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm")]
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _usuarioService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }

        [Authorize(Roles = "Adm, Seguranca")]
        [HttpGet("/AspnetUserId{aspNetUser_Id}")]
        public async Task<ActionResult> ObterPorGuidIdAsync(string aspNetUser_Id)
        {
            var result = await _usuarioService.ObterPorGuidIdAsync(aspNetUser_Id);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarUsuarioRequest request)
        {
            var result = await _usuarioService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _usuarioService.DesativarAsync(id);
            return CustomResponse(result);
        }
    }
}
