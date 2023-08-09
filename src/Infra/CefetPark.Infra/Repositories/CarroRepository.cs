using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Infra.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly DataContext _dataContext;
        public CarroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Carro?> ObterPorPlacaAsync(string placa)
        {
            var result = await _dataContext.Carros
                .Where(x => x.Placa.Equals(placa))
                .Include(x => x.Modelo)
                .Include(x => x.Cor)
                .Include(x => x.Usuarios).ThenInclude(x => x.Departamento)
                .Include(x => x.Usuarios).ThenInclude(x => x.TipoUsuario)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
