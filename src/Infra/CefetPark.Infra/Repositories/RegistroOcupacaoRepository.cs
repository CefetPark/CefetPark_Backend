using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Domain.Models;
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

        public async Task<ICollection<int>> ObterMediasQtdLivresPorHorarioAsync(DayOfWeek? dia, ICollection<HorariosGraficoModel> horarios, int? estacionamentoId)
        {
            dia = dia == null ? DateTime.Now.DayOfWeek : dia;

            var mediasQtdLivresPorHorario = new List<int>();
            var query = _context.RegistrosOcupacoes.AsQueryable();
            int quantidadeTotalVagas;

            if (estacionamentoId != null)
            {
                query = query.Where(x => x.RegistroEntradaSaida.Estacionamento_Id == estacionamentoId);
                quantidadeTotalVagas = (await _context.Estacionamentos.FirstAsync(x => x.Id == estacionamentoId)).QtdVagasTotal;
            }
            else
            {
                quantidadeTotalVagas = (int)await _context.Estacionamentos.AverageAsync(x => x.QtdVagasTotal);
            }

            var dataLimite = DateTime.Now.AddMonths(-3);
            foreach (var horario in horarios)
            {

                var quantidadeTotalLivres = await query
                                             .Where(r => r.Data >= dataLimite &&
                                                         r.Data.Hour >= horario.Inicial.Hours &&
                                                         r.Data.Hour < horario.Final.Hours &&
                                                         r.Data.DayOfWeek == dia)
                                             .SumAsync(r => r.QuantidadeVagasLivres);

                var quantidadeRegistros = await query
                    .CountAsync(r => r.Data >= dataLimite &&
                                     r.Data.Hour >= horario.Inicial.Hours &&
                                     r.Data.Hour < horario.Final.Hours &&
                                     r.Data.DayOfWeek == dia);

                double mediaVagasLivres = quantidadeRegistros > 0 ? ((double)quantidadeTotalLivres / quantidadeRegistros) : 0;
                double porcentagemVagasLivres = (((double)mediaVagasLivres / quantidadeTotalVagas)) * 100;

                double porcentagemVagasOcupadas = porcentagemVagasLivres != 0 ? 100 - porcentagemVagasLivres : 0;

                mediasQtdLivresPorHorario.Add((int)porcentagemVagasOcupadas);
            }

            return mediasQtdLivresPorHorario;
        }
    }
}
