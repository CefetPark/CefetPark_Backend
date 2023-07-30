using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post
{
    public class CadastrarRegistroEntradaSaidaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataEntrada { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Estacionamento_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Usuario_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Carro_Id { get; set; }
    }
}
