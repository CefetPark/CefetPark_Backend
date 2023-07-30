using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Carro.Post;
using CefetPark.Application.ViewModels.Request.Carro.Put;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Response.Carro.Get;
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
    public class CarroService : ICarroService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public CarroService(ICommonRepository commonRepository, INotificador notificador, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _notificador = notificador;
            _mapper = mapper;
        }
        public async Task<bool> AtualizarAsync(AtualizarCarroRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Carro>(request.Id, new List<string> { "Usuarios"});

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

        public async Task<bool> CadastrarAsync(CadastrarCarroRequest request)
        {
            var entidade = _mapper.Map<Carro>(request);

            _commonRepository.RastrearEntidades(entidade.Usuarios);
            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return true;

        }

        public async Task<bool> DesativarAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Carro>(id);

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

        public async Task<ObterCarroResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Carro>(id, new List<string> { "Usuarios", "Cor", "Modelo"});

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterCarroResponse>(entidade);

            return response;
        }

        public async Task<IEnumerable<ObterCarroResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Carro>(new List<string> {"Usuarios", "Cor", "Modelo"});

            var response = _mapper.Map<IEnumerable<ObterCarroResponse>>(entidades);

            return response;
        }
    }
}
