﻿using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Carro.Post;
using CefetPark.Application.ViewModels.Request.Carro.Put;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class CarroController : PrincipalController
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService, INotificador notificador): base(notificador)
        {
            _carroService = carroService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarCarroRequest request)
        {
            var result = await _carroService.CadastrarAsync(request);
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarAsync(AtualizarCarroRequest request)
        {
            var result = await _carroService.AtualizarAsync(request);
            return CustomResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarAsync(int id)
        {
            var result = await _carroService.DesativarAsync(id);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosAsync()
        {
            var result = await _carroService.ObterTodosAsync();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorIdAsync(int id)
        {
            var result = await _carroService.ObterPorIdAsync(id);
            return CustomResponse(result);
        }
    }
}
