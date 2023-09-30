
using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Common.Get;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Response.Convidado.Get
{
    public class ObterConvidadoResponse : ObterCommonResponse
    {
        public string Cpf { get; set; }
        public ICollection<ObterConvidadoCarroResponse> Carros { get; set; }
    }
}
