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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Usuario?> ObterPorGuidIdAsync(string id)
        {
            var result = await _dataContext
                .Usuarios
                .Include(x => x.Carros).ThenInclude(y => y.Modelo)
                .Include(x => x.Carros).ThenInclude(y => y.Modelo).ThenInclude(y => y.Marca)
                .Include(x => x.Carros).ThenInclude(y => y.Cor)
                .Include(x => x.Departamento)
                .Include(x => x.TipoUsuario)
                .FirstOrDefaultAsync(x => x.AspNetUsers_Id == id.ToString());
            return result;
        }
    }
}
