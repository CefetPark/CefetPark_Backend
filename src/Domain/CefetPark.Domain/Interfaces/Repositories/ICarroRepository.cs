using CefetPark.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Interfaces.Repositories
{
    public interface ICarroRepository
    {
        public Task<Carro?> ObterPorPlacaAsync(string placa);
    }
}
