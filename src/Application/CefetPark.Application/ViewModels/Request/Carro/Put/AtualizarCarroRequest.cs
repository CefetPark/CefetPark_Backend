using CefetPark.Application.ViewModels.Request.Common.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.Carro.Put
{
    public class AtualizarCarroRequest
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Cor_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Modelo_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ICollection<CadastrarCommonRelationRequest> Usuarios { get; set; }
    }
}
