
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Get
{
    public class ObterEstacionadosRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Estacionamento_Id { get; set; }
    }
}
