using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using System.Net;

namespace CefetPark.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public MarcaService(ICommonRepository commonRepository, INotificador notificador, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _notificador = notificador;
            _mapper = mapper;
        }
        public async Task<bool> AtualizarAsync(AtualizarCommonRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Marca>(request.Id);

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

        public async Task<bool> CadastrarAsync(CadastrarCommonRequest request)
        {
            var entidade = _mapper.Map<Marca>(request);

            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return true;

        }

        public async Task<bool> DesativarAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Marca>(id);

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

        public async Task<ObterCommonResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Marca>(id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterCommonResponse>(entidade);

            return response;
        }

        public async Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Marca>(new List<string>{ "Modelos"});

            var response = _mapper.Map<IEnumerable<ObterCommonResponse>>(entidades);

            return response;
        }
    }
}
