using CefetPark.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Usuario.Post
{
    public class CadastrarUsuarioRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos")]
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
