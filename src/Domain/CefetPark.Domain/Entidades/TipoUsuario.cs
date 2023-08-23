namespace CefetPark.Domain.Entidades
{
    public class TipoUsuario : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
