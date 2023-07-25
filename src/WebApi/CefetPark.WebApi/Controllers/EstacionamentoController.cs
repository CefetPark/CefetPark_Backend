using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class EstacionamentoController : PrincipalController
    {
        private readonly IEstacionamentoService _estacionamentoService;
        public EstacionamentoController(IEstacionamentoService estacionamentoService,INotificador notificador) : base(notificador)
        {
            _estacionamentoService = estacionamentoService;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAsync(CadastrarEstacionamentoRequest request)
        {
            var result = await _estacionamentoService.CadastrarAsync(request);
            return CustomResponse(result);
        }

    }
}
