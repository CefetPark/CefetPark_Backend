using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Estacionamento.Post;
using CefetPark.Application.ViewModels.Request.Estacionamento.Put;
using CefetPark.Application.ViewModels.Response.Estacionamento.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;

namespace CefetPark.Application.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public EstacionamentoService(ICommonRepository commonRepository, IMapper mapper, INotificador notificador, IEstacionamentoRepository estacionamentoRepository)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
            _notificador = notificador;
            _estacionamentoRepository = estacionamentoRepository;
        }

        public async Task<bool> AtualizarAsync(AtualizarEstacionamentoRequest request)
        {
            var entidade = await _estacionamentoRepository.ObterPorIdAsync(request.Id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao("Entidade não Encontrada", System.Net.HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);

            HelperAtualizacao.AtualizarCamposEntidadeComBaseNaViewModel(request, entidade);

            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> CadastrarAsync(CadastrarEstacionamentoRequest request)
        {
            var entidade = _mapper.Map<Estacionamento>(request);

            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> DesativarAsync(int id)
        {
            var entidade = await _estacionamentoRepository.ObterPorIdAsync(id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao("Entidade não Encontrada", System.Net.HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);
            
            entidade.Desativar();

            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<ObterEstacionamentoResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _estacionamentoRepository.ObterPorIdAsync(id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao("Entidade não Encontrada", System.Net.HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterEstacionamentoResponse>(entidade);

            return response;
        }

        public async Task<IEnumerable<ObterEstacionamentoResponse>> ObterTodosAsync()
        {
            var entidades = await _estacionamentoRepository.ObterTodosAsync();

            var response = _mapper.Map<IEnumerable<ObterEstacionamentoResponse>>(entidades);

            return response;
        }
    }
}
