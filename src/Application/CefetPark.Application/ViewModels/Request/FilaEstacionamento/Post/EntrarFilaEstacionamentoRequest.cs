using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.FilaEstacionamento.Post
{
    public class EntrarFilaEstacionamentoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Estacionamento_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Carro_Id { get; set; }
    }
}
