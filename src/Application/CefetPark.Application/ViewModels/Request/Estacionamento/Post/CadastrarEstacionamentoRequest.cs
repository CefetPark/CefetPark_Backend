using CefetPark.Application.ViewModels.Request.Endereco.Post;

namespace CefetPark.Application.ViewModels.Request.Estacionamento.Post
{
    public class CadastrarEstacionamentoRequest
    {
        public string Nome { get; set; }
        public int QtdVagasTotal { get; set; }
        public int QtdVagasLivres { get; set; }
        public CadastrarEnderecoRequest Endereco { get; set; }
    }
}
