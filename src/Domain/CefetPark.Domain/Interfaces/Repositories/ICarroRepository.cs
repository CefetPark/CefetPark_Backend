using CefetPark.Domain.Entidades;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface ICarroRepository
    {
        public Task<Carro?> ObterPorPlacaAsync(string placa);
    }
}
