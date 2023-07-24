using CefetPark.Utils.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace CefetPark.WebApi.Controllers
{
    [Route("[controller]")]
    public class EstacionamentoController : PrincipalController
    {
        public EstacionamentoController(INotificador notificador) : base(notificador)
        {
        }
    }
}
