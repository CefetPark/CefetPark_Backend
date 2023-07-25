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
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly DataContext _dataContext;

        public EstacionamentoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Estacionamento> ObterPorIdAsync(int id)
        {
            var result = await _dataContext.Estacionamentos
                .Include(x => x.Endereco)
                .Include(x => x.RegistrosEntradasSaidas)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<Estacionamento>> ObterTodosAsync()
        {
            var result = await _dataContext.Estacionamentos
                .Include(x => x.Endereco)
                .Include(x => x.RegistrosEntradasSaidas)
                .ToListAsync();

            return result;
        }
    }
}
