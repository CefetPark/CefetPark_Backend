using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using CefetPark.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        private readonly INotificador _notificador;

        public PrincipalController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new CustomResponseSuccess(result));
            }

            return StatusCode
                (
                _notificador.ObterNotificacoes().OrderByDescending(x => x.HttpStatusCode).First().HttpStatusCode,
                new CustomResponseError(_notificador.ObterNotificacoes())
                );
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
