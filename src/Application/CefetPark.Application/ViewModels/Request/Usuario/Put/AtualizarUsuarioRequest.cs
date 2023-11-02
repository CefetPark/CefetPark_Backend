using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.Usuario.Put
{
    public class AtualizarUsuarioRequest
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }
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
