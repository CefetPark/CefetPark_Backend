using CefetPark.Application.ViewModels.Response.Common.Get;

namespace CefetPark.Application.Interfaces.Services
{
    public interface ITipoUsuarioService
    {
        public Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync();
    }
}
