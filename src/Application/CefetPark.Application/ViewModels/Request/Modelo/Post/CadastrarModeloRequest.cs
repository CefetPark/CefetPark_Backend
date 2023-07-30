using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Modelo.Post
{
    public class CadastrarModeloRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Marca_Id { get; set; }
    }
}
