using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Endereco.Post
{
    public class CadastrarEnderecoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TipoLogradouro { get; set; }

    }
}
