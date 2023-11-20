using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.Auth.Post
{
    public class RedefinirMinhaSenhaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("NovaSenha", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
