using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Application.ViewModels.Request.Estacionamento.Put;
using CefetPark.Application.ViewModels.Response.Estacionamento.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using System.Net;

namespace CefetPark.Application.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public EstacionamentoService(ICommonRepository commonRepository, IMapper mapper, INotificador notificador)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
            _notificador = notificador;
        }

        public async Task<bool> AtualizarAsync(AtualizarEstacionamentoRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Estacionamento>(request.Id, new List<string> { "Endereco" });

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);

            AtualizacaoHelper.AtualizarCamposEntidadeComBaseNaViewModel(request, entidade);
            entidade.QtdVagasLivres = entidade.QtdVagasTotal;

            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> CadastrarAsync(CadastrarEstacionamentoRequest request)
        {
            var entidade = _mapper.Map<Estacionamento>(request);

            entidade.QtdVagasLivres = entidade.QtdVagasTotal;
            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> DesativarAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Estacionamento>(id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);
            
            entidade.Desativar();

            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<ObterEstacionamentoResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Estacionamento>(id, new List<string> { "Endereco"});

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterEstacionamentoResponse>(entidade);

            return response;
        }

        public async Task<IEnumerable<ObterEstacionamentoResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Estacionamento>(new List<string> { "Endereco"});

            var response = _mapper.Map<IEnumerable<ObterEstacionamentoResponse>>(entidades);

            return response;
        }
    }
}
