
using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.ViewModels.Response.Carro.Get
{
    public class ObterCarroResponse
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public ObterCommonResponse Cor { get; set; }
        public ObterCommonResponse Modelo { get; set; }
    }
}
