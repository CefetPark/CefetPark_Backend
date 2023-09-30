namespace CefetPark.Domain.Entidades
{
    public class Convidado : CommonEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICollection<RegistroEntradaSaida> RegistroEntradaSaidas { get; set; }
        public ICollection<Carro> Carros { get; set; }
        
    }
}
