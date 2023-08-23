namespace CefetPark.Domain.Entidades
{
    public class Departamento : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
