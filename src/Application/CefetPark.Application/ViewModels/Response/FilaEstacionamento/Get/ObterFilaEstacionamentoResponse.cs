using CefetPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Response.FilaEstacionamento.Get
{
    public class ObterFilaEstacionamentoResponse
    {
        public int Estacionamento_Id { get; set; }
        public List<ObterIntegrantesFilaEstacionamentoResponse> Integrantes { get; set; } = new List<ObterIntegrantesFilaEstacionamentoResponse>();

        public ObterIntegrantesFilaEstacionamentoResponse? ChamadoParaEstacionar { get;  set; }
    }
}
