using CefetPark.Application.ViewModels.Request.Common.Post;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Carro.Post
{
    public class CadastrarCarroRequest
    {
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
