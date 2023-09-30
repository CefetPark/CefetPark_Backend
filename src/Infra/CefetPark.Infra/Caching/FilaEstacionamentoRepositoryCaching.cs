using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Caching;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace CefetPark.Infra.Caching
{
    public class FilaEstacionamentoRepositoryCaching : CommonRepositoryCaching, IFilaEstacionamentoRepositoryCaching
    {
        private readonly IUser _user;
        private readonly ICommonRepository _commonRepository;
        public FilaEstacionamentoRepositoryCaching(IDistributedCache cache, IUser user, ICommonRepository commonRepository) : base(cache, new DistributedCacheEntryOptions(), commonRepository)
        {
            _user = user;
            _commonRepository = commonRepository;

        }

        public async Task<bool> DesistirFilaAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            fila.DesistirFila(_user.ObterUsuarioId());

            if (fila.ExisteIntegrantesNaFila() == true)
            {
                await SetAsync(fila);
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

            int usuarioId = _user.ObterUsuarioId();

            var usuario = await _commonRepository.ObterPorIdAsync<Usuario>(usuarioId);
            if(usuario == null)
            {
                return false;
            }

            var integrante = new IntegranteFilaEstacionamento()
            {
                Usuario_Id = usuarioId,
                Carro_Id = model.Carro_Id,
                NomeUsuario = usuario.Nome,
                 
            };

            fila.EntrarFila(integrante);


            await SetAsync(fila);

            return true;
        }

        public async Task<FilaEstacionamento?> ObterFilaAsync(int estacionamentoId)
        {
            var fila = await GetAsync<FilaEstacionamento>(new FilaEstacionamento(estacionamentoId).ObterKey());

            if (fila == null) return null;

            return fila;
        }

        public async Task<bool> ChamarProximoDaFilaAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            fila.ChamarProximoDaFila();

            await SetAsync(fila);


            return true;
        }

        public async Task<bool> LimparChamadoParaEstacionarAsync(int estacionamentoId)
        {
            var fila = await ObterFilaAsync(estacionamentoId);

            fila.LimparChamadoParaEstacionar();

            if (fila.ExisteIntegrantesNaFila() == true)
            {
                await SetAsync(fila);
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
            await SetAsync(fila);

            return true;
        }
    }
}
