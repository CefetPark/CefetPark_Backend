namespace CefetPark.Domain.Entidades
{
    public class Endereco : CommonEntity
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Estacionamento Estacionamento { get; set; }
    }
}
