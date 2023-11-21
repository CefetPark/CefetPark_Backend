using System.ComponentModel.DataAnnotations;


namespace CefetPark.Application.ViewModels.Request.Convidado.Post
{
    public class CadastrarConvidadoCarroRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }
    }
}
