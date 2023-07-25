using CefetPark.Domain.Entidades;


namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<Usuario?> ObterPorGuidIdAsync(string id);
    }
}
