using CefetPark.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Utils.Interfaces.External_Apis
{
    public interface IGoogleGeoApi
    {
        public Task<ObterCep?> ObterEnderecoPorCepAsync(string cep);
    }
}
