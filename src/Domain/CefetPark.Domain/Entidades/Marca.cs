namespace CefetPark.Domain.Entidades
{
    public class Marca : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Modelo> Modelos { get; set; }

    }
}
