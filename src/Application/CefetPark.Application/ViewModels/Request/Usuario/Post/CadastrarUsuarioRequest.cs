using CefetPark.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.Usuario.Post
{
    public class CadastrarUsuarioRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TelefonePrincipal { get; set; }
        public string? TelefoneSecundario { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string EmailPrincipal { get; set; }
        public string? EmailSecundario { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Departamento_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoUsuario_Id { get; set; }
    }
}
