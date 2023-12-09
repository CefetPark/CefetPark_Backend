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
    public class RegistroOcupacaoRepository : IRegistroOcupacaoRepository
    {
        private readonly DataContext _context;

        public RegistroOcupacaoRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<ICollection<int>> ObterMediasQtdLivresPorHorarioAsync(DateTime dia, ICollection<TimeSpan> horarios, int? estacionamentoId)
        {

            
            var mediasQtdLivresPorHorario = new List<int>();
            var query = _context.RegistrosOcupacoes.AsQueryable();

            if(estacionamentoId != null) query = query.Where(x => x.Estacionamento_Id == estacionamentoId);
            foreach (var horario in horarios)
            {
                var horarioInicio = horario.Subtract(TimeSpan.FromHours(2));

                var registrosNoHorario = await query
                    .Where(r => r.DataEntrada.Date == dia.Date &&
                                r.DataEntrada.TimeOfDay >= horarioInicio &&
                                r.DataEntrada.TimeOfDay <= horario &&
                                (!r.DataSaida.HasValue || r.DataSaida.Value.TimeOfDay >= horarioInicio))
                    .ToListAsync();

                int mediaQtdLivres;
                if (registrosNoHorario.Any())
                {
                    mediaQtdLivres = (int)registrosNoHorario
                    .Average(r => r.QuantidadeVagasLivresEntrada);
                }
                else
                {
                    mediaQtdLivres = 0;
                }
                

                mediasQtdLivresPorHorario.Add(mediaQtdLivres);
            }

            return mediasQtdLivresPorHorario;
        }
    }
}
