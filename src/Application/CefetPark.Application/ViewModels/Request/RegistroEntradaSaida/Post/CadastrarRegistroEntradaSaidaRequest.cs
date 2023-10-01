using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post
{

    [OneOfTwoRequired("Usuario_Id", "Convidado_Id")]
    public class CadastrarRegistroEntradaSaidaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataEntrada { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Estacionamento_Id { get; set; }
        public int Usuario_Id { get; set; }
        public int Convidado_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Carro_Id { get; set; }
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class OneOfTwoRequiredAttribute : ValidationAttribute
    {
        private readonly string firstProperty;
        private readonly string secondProperty;

        public OneOfTwoRequiredAttribute(string firstProperty, string secondProperty)
        {
            this.firstProperty = firstProperty;
            this.secondProperty = secondProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var firstValue = (int)validationContext.ObjectType.GetProperty(firstProperty).GetValue(validationContext.ObjectInstance, null);
            var secondValue = (int)validationContext.ObjectType.GetProperty(secondProperty).GetValue(validationContext.ObjectInstance, null);

            if (firstValue == 0 && secondValue == 0)
            {
                return new ValidationResult($"Pelo menos um entre {firstProperty} e {secondProperty} deve ser preenchido.");
            }

            if (firstValue != 0 && secondValue != 0)
            {
                return new ValidationResult($"Apenas um entre {firstProperty} e {secondProperty} deve ser preenchido, não ambos.");
            }

            return ValidationResult.Success;
        }
    }

}
