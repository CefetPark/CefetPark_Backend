
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;

namespace CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get
{
    public class ObterRegistroEntradaSaidaCarroResponse
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
    }
}
