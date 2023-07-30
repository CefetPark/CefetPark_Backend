using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.ViewModels.Response.Modelo.Get
{
    public class ObterModeloResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ObterCommonResponse Marca { get; set; }
        public ICollection<ObterCarroResponse> Carros { get; set; }
    }
}
