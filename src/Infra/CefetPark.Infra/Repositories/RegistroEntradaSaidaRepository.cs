using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CefetPark.Infra.Repositories
{
    public class RegistroEntradaSaidaRepository : IRegistroEntradaSaidaRepository
    {
        private readonly DataContext _dataContext;

        public RegistroEntradaSaidaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<RegistroEntradaSaida>> ObterEstacionadosAsync(int estacionamento_id)
        {
            var result = await _dataContext.RegistrosEntradasSaidas
                .Where(x => x.Estacionamento_Id == estacionamento_id && x.DataSaida == null)
                .Include(x => x.Carro).ThenInclude(x => x.Cor)
                .Include(x => x.Carro).ThenInclude(x => x.Modelo)
                .ToListAsync();
            return result;
        }

        public async Task<bool> UsuarioJaEstacionadoAsync(int usuarioId)
        {
            var result = await _dataContext.RegistrosEntradasSaidas.Where(x => x.Usuario_Id == usuarioId && x.DataSaida == null).AnyAsync();
            return result;
        }

        public async Task<bool> CarroJaEstacionadoAsync(int carroId)
        {
            var result = await _dataContext.RegistrosEntradasSaidas.Where(x => x.Carro_Id == carroId && x.DataSaida == null).AnyAsync();
            return result;
        }
    }
}
