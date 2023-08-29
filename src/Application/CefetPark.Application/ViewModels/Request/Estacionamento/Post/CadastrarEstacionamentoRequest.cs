using CefetPark.Application.ViewModels.Request.Endereco.Post;
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Estacionamento.Post
{
    public class CadastrarEstacionamentoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtdVagasTotal { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CadastrarEnderecoRequest Endereco { get; set; }
    }
}
