using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.FilaEstacionamento.Post;
using CefetPark.Application.ViewModels.Response.FilaEstacionamento.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Caching;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Domain.Models;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;


namespace CefetPark.Application.Services
{
    public class FilaEstacionamentoService : IFilaEstacionamentoService
    {
        private readonly IFilaEstacionamentoRepositoryCaching _filaEstacionamentoCaching;
        private readonly ICommonRepository _commonRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public FilaEstacionamentoService(IFilaEstacionamentoRepositoryCaching filaEstacionamentoCaching, ICommonRepository commonRepository, INotificador notificador, IMapper mapper)
        {
            _filaEstacionamentoCaching = filaEstacionamentoCaching;
            _commonRepository = commonRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<bool> ChamarProximoDaFilaAsync(int estacionamentoId)
        {
            var estacionamentoExiste = await _commonRepository.EntidadeExisteAsync<Estacionamento>(estacionamentoId);
            if (estacionamentoExiste == false)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, System.Net.HttpStatusCode.NotFound));
                return false;
            }
            await _filaEstacionamentoCaching.ChamarProximoDaFilaAsync(estacionamentoId);

            return true;
        }

        public async Task<bool> DesistirFilaAsync(int estacionamentoId)
        {
            var estacionamentoExiste = await _commonRepository.EntidadeExisteAsync<Estacionamento>(estacionamentoId);
            if (estacionamentoExiste == false)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, System.Net.HttpStatusCode.NotFound));
                return false;
            }

            var fila = await _filaEstacionamentoCaching.ObterFilaAsync(estacionamentoId);

            if (fila == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                return false;
            }

            var usuarioEstaNaFila = await _filaEstacionamentoCaching.UsuarioEstaNaFilaAsync(estacionamentoId);

            if (!usuarioEstaNaFila)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.USUARIO_NAO_ESTA_NA_FILA));
                return false;
            }

            await _filaEstacionamentoCaching.DesistirFilaAsync(estacionamentoId);

            return true;

        }

        public async Task<bool> EntrarFilaAsync(EntrarFilaEstacionamentoRequest request)
        {
            var estacionamentoExiste = await _commonRepository.EntidadeExisteAsync<Estacionamento>(request.Estacionamento_Id);
            if (estacionamentoExiste == false)
            {
                _notificador.Handle(new Notificacao("EstacionamentoId não encontrado", System.Net.HttpStatusCode.NotFound));
                return false;
            }

            var carroExiste = await _commonRepository.EntidadeExisteAsync<Carro>(request.Carro_Id);
            if (carroExiste == false)
            {
                _notificador.Handle(new Notificacao("CarroId não encontrado", System.Net.HttpStatusCode.NotFound));
                return false;
            }

            var estacionamento = await _commonRepository.ObterPorIdAsync<Estacionamento>(request.Estacionamento_Id);

            if (estacionamento != null && estacionamento.QtdVagasLivres > 0)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.SEM_NECESSIDADE_DE_FILA));
                return false;
            }

            var usuarioJaEstaNaFila = await _filaEstacionamentoCaching.UsuarioEstaNaFilaAsync(request.Estacionamento_Id);

            if (usuarioJaEstaNaFila)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.USUARIO_JA_ESTA_NA_FILA));
                return false;
            }

            var model = _mapper.Map<EntrarFilaEstacionamento>(request);

            await _filaEstacionamentoCaching.EntrarFilaAsync(model);

            return true;
        }

        public async Task<ObterFilaEstacionamentoResponse?> ObterFilaAsync(int estacionamentoId)
        {
            var estacionamentoExiste = await _commonRepository.EntidadeExisteAsync<Estacionamento>(estacionamentoId);
            if (estacionamentoExiste == false)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, System.Net.HttpStatusCode.NotFound));
                return null;
            }

            var model = await _filaEstacionamentoCaching.ObterFilaAsync(estacionamentoId);

            if (model == null) return null;

            var response = _mapper.Map<ObterFilaEstacionamentoResponse>(model);

            return response;

        }
    }
}
