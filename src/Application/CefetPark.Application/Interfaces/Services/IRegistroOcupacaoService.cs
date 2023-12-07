using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.Interfaces.Services
{
    public interface IRegistroOcupacaoService
    {
        public Task<ObterGraficoHojeRegistroOcupacaoRequest> ObterGraficoHojeAsync(int? estacionamentoId);
    }
}
