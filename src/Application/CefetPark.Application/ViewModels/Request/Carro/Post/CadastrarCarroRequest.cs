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
    public class CadastrarCarroRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Cor_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Modelo_Id { get; set; }

        [UsuariosOuConvidadosRequired(ErrorMessage = "Pelo menos um usuário ou convidado é obrigatório.")]
        public ICollection<CadastrarCommonRelationRequest> Usuarios { get; set; }

        [UsuariosOuConvidadosRequired(ErrorMessage = "Pelo menos um usuário ou convidado é obrigatório.")]
        public ICollection<CadastrarCommonRelationRequest> Convidados { get; set; }

    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UsuariosOuConvidadosRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is ICollection<CadastrarCommonRelationRequest> collection)
            {
                if (collection == null || collection.Count == 0)
                {
                    return new ValidationResult(ErrorMessage ?? $"O campo {validationContext.DisplayName} é obrigatório.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
