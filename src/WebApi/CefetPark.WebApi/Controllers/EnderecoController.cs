using CefetPark.Utils.Interfaces.External_Apis;
using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.WebApi.Controllers
{ 

    [Authorize]
    [Route("[controller]")]
    public class EnderecoController : PrincipalController
    {
        private readonly IGoogleGeoApi _googleGeoApi;
        private readonly INotificador _notificador;
        public EnderecoController(INotificador notificador, IGoogleGeoApi googleGeoApi) : base(notificador)
        {
            _googleGeoApi = googleGeoApi;
            _notificador = notificador;
        }


        [HttpGet("obter-por-cep/{cep}")]
        public async Task<ActionResult> ObterPorCepAsync([Required(ErrorMessage = "O campo {0} é obrigatório")]  string Cep)
        {
            var response = await _googleGeoApi.ObterEnderecoPorCepAsync(Cep);

            if (response == null) _notificador.Handle(new Utils.Models.Notificacao("Erro ao buscar cep na api do Google"));

            return CustomResponse(response);
        }

    }
}
