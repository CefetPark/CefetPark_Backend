namespace CefetPark.Domain.Entidades
{
    public class Cor : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}
