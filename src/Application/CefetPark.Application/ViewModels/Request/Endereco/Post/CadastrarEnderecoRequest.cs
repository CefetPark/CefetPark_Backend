namespace CefetPark.Application.ViewModels.Request.Endereco.Post
{
    public class CadastrarEnderecoRequest
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string TipoLogradouro { get; set; }
    }
}
