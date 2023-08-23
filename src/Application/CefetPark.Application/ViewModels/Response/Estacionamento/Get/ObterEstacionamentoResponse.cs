using CefetPark.Application.ViewModels.Response.Endereco.Get;

namespace CefetPark.Application.ViewModels.Response.Estacionamento.Get
{
    public class ObterEstacionamentoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdVagasTotal { get; set; }
        public int QtdVagasLivres { get; set; }
        public ObterEnderecoResponse Endereco { get; set; }
    }
}
