using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Get;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Put;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using System.Net;

namespace CefetPark.Application.Services
{
    public class RegistroEntradaSaidaService : IRegistroEntradaSaidaService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IRegistroEntradaSaidaRepository _registroEntradaSaidaRepository;

        public RegistroEntradaSaidaService(ICommonRepository commonRepository, IMapper mapper, INotificador notificador, IRegistroEntradaSaidaRepository registroEntradaSaidaRepository)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
            _notificador = notificador;
            _registroEntradaSaidaRepository = registroEntradaSaidaRepository;
        }


        public async Task<bool> AtualizarAsync(AtualizarRegistroEntradaSaidaRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<RegistroEntradaSaida>(request.Id);

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

        public async Task<bool> CadastrarAsync(CadastrarRegistroEntradaSaidaRequest request)
        {
            var entidade = _mapper.Map<RegistroEntradaSaida>(request);

            var usuarioJaEstacionado = await _registroEntradaSaidaRepository.UsuarioJaEstacionadoAsync(request.Usuario_Id);
            if (usuarioJaEstacionado)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.USUARIO_JA_ESTACIONADO));
                return false;
            }

            var carroJaEstacionado = await _registroEntradaSaidaRepository.CarroJaEstacionadoAsync(request.Carro_Id);
            if (carroJaEstacionado)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.CARRO_JA_ESTACIONADO));
                return false;
            }

            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();

            return true;

        }

        public async Task<IEnumerable<ObterRegistroEntradaSaidaResponse>> ObterEstacionadosAsync(ObterEstacionadosRequest request)
        {
            var estacionamento = await _commonRepository.ObterPorIdAsync<Estacionamento>(request.Estacionamento_Id);

            if (estacionamento == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var entidades = await _registroEntradaSaidaRepository.ObterEstacionadosAsync(request.Estacionamento_Id);
            var response = _mapper.Map<IEnumerable<ObterRegistroEntradaSaidaResponse>>(entidades);
            return response;
        }
    }
}
