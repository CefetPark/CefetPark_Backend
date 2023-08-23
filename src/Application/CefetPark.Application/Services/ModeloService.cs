using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Modelo.Post;
using CefetPark.Application.ViewModels.Request.Modelo.Put;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Modelo.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public ModeloService(ICommonRepository commonRepository, INotificador notificador, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _notificador = notificador;
            _mapper = mapper;
        }
        public async Task<bool> AtualizarAsync(AtualizarModeloRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Modelo>(request.Id);

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

        public async Task<bool> CadastrarAsync(CadastrarModeloRequest request)
        {
            var entidade = _mapper.Map<Modelo>(request);

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

        public async Task<ObterModeloResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Modelo>(id, new List<string> { "Marca" });

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterModeloResponse>(entidade);

            return response;
        }

        public async Task<IEnumerable<ObterModeloResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Modelo>(new List<string> { "Marca"});

            var response = _mapper.Map<IEnumerable<ObterModeloResponse>>(entidades);

            return response;
        }
    }
}
