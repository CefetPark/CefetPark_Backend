using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Caching;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace CefetPark.Infra.Caching
{
    public class FilaEstacionamentoCaching : CommonCaching, IFilaEstacionamentoCaching
    {
        private readonly IUser _user;
        public FilaEstacionamentoCaching(IDistributedCache cache, IUser user) : base(cache, new DistributedCacheEntryOptions())
        {
            _user = user;

        }

        public async Task<bool> DesistirFilaAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            fila.DesistirFila(_user.ObterUsuarioId());

            if (fila.ExisteIntegrantesNaFila() == true)
            {
                await SetAsync(fila.ObterKey(), fila);
            }
            else
            {
                await RemoveAsync(fila);
            }

            return true;
        }

        public async Task<bool> EntrarFilaAsync(EntrarFilaEstacionamento model)
        {
            var fila = await ObterFilaAsync(model.Estacionamento_Id);

            if (fila == null)
            {
                fila = new FilaEstacionamento(model.Estacionamento_Id);
            }

            var integrante = new IntegranteFilaEstacionamento()
            {
                Usuario_Id = _user.ObterUsuarioId(),
                Carro_Id = model.Carro_Id
            };

            fila.EntrarFila(integrante);


            await SetAsync(model.Estacionamento_Id, fila);

            return true;
        }

        public async Task<FilaEstacionamento?> ObterFilaAsync(int estacionamentoId)
        {
            var fila = await GetAsync<FilaEstacionamento>(estacionamentoId);

            if (fila == null) return null;

            fila.PreencherPosicoesIntegrantes();

            return fila;
        }

        public async Task<bool> ChamarProximoDaFilaAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            fila.ChamarProximoDaFila();

            await SetAsync(fila.ObterKey(), fila);


            return true;
        }

        public async Task<bool> LimparChamadoParaEstacionarAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            fila.LimparChamadoParaEstacionar();

            if (fila.ExisteIntegrantesNaFila() == true)
            {
                await SetAsync(fila.ObterKey(), fila);
            }
            else
            {
                await RemoveAsync(fila);
            }

            return true;
        }

        public async Task<bool> ExisteIntegrantesNaFilaAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            return fila.ExisteIntegrantesNaFila();
        }

        public async Task<bool> UsuarioEstaNaFilaAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            if (fila == null) return false;

            return fila.Integrantes.Any(x => x.Usuario_Id == _user.ObterUsuarioId()) || (fila.ChamadoParaEstacionar != null && fila.ChamadoParaEstacionar.Usuario_Id == _user.ObterUsuarioId()) ;
        }

        public async Task<bool> SalvarFilaAsync(FilaEstacionamento fila)
        {
            await SetAsync(fila.ObterKey(), fila);

            return true;
        }
    }
}
