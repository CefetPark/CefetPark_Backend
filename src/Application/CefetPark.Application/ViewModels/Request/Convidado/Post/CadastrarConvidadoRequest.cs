using CefetPark.Application.ViewModels.Request.Common.Post;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Convidado.Post
{
    public class CadastrarConvidadoRequest : CadastrarCommonRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sicap { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ICollection<CadastrarConvidadoCarroRequest> Carros { get; set; }
    }
}
