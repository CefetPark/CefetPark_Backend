
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Put
{
    public class AtualizarRegistroEntradaSaidaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataSaida {get;set;}
    }
}
