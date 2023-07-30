using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get
{
    public class ObterRegistroEntradaSaidaResponse
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public int Estacionamento_Id { get; set; }
        public ObterUsuarioResponse Usuario { get; set; }
        public ObterCarroResponse Carro { get; set; }
    }
}
