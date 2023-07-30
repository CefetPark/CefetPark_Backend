
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Modelo.Put
{
    public class AtualizarModeloRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Marca_Id { get; set; }
    }
}
