
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Auth.Post
{
    public class RedefinirMinhaSenhaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("NovaSenha", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
