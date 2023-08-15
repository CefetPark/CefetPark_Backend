using CefetPark.Domain.Entidades;


namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<Usuario?> ObterPorIdAsync(int id);
        public Task<Usuario?> ObterPorGuidIdAsync(string aspNetUser_Id);
    }
}
