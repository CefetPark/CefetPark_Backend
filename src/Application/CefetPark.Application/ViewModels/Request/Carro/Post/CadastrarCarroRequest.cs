using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.Carro.Post
{
    [UsuarioOuConvidadoRequerido(ErrorMessage = "O carro deve ser vinculado a pelo menos um usuário ou convidado.")]
    public class CadastrarCarroRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? Cor_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? Modelo_Id { get; set; }
        public ICollection<CadastrarCommonRelationRequest> Usuarios { get; set; }

        public ICollection<CadastrarCommonRelationRequest> Convidados { get; set; }

    }

    [AttributeUsage(AttributeTargets.Class)]
    public class UsuarioOuConvidadoRequeridoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var request = (CadastrarCarroRequest)validationContext.ObjectInstance;

            if ((request.Usuarios == null || request.Usuarios.Count == 0) &&
                (request.Convidados == null || request.Convidados.Count == 0))
            {
                return new ValidationResult("O carro deve ser vinculado a pelo menos um usuário ou convidado.");
            }

            return ValidationResult.Success;
        }
    }


}
