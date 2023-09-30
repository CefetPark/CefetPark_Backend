using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Response.FilaEstacionamento.Get
{
    public class ObterIntegrantesFilaEstacionamentoResponse
    {
        public int Carro_Id { get; set; }
        public int Usuario_Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public int Posicao { get; set; }
        public string NomeUsuario { get; set; }
    }
}
