using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Convidado.Post;
using CefetPark.Application.ViewModels.Request.Convidado.Put;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Convidado.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using System.Net;

namespace CefetPark.Application.Services
{
    public class ConvidadoService : IConvidadoService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public ConvidadoService(ICommonRepository commonRepository, INotificador notificador, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarAsync(AtualizarConvidadoRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Convidado>(request.Id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);

            AtualizacaoHelper.AtualizarCamposEntidadeComBaseNaViewModel(request, entidade);

            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> CadastrarAsync(CadastrarConvidadoRequest request)
        {
            var entidade = _mapper.Map<Convidado>(request);

            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> DesativarAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Convidado>(id);

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

        public async Task<ObterConvidadoResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Convidado>(id, new List<string> { "Carros" });

            var response = _mapper.Map<ObterConvidadoResponse>(entidade);

            return response;
        }

        public async Task<IEnumerable<ObterConvidadoResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Convidado>(new List<string> { "Carros" });

            var response = _mapper.Map<IEnumerable<ObterConvidadoResponse>>(entidades);

            return response;
        }
    }
}
