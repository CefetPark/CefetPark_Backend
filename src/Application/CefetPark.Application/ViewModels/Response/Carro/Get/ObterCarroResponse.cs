
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Convidado.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;

namespace CefetPark.Application.ViewModels.Response.Carro.Get
{
    public class ObterCarroResponse
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public int Modelo_Id { get; set; }
        public int Cor_Id { get; set; }
        public ICollection<ObterCarroUsuarioResponse> Usuarios { get; set; }
        public ICollection<ObterCarroConvidadoResponse> Convidados { get; set; }
    }
}
