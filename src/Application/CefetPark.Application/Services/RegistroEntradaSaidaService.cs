﻿using AutoMapper;
using CefetPark.Application.Interfaces.Jobs;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Get;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Post;
using CefetPark.Application.ViewModels.Request.RegistroEntradaSaida.Put;
using CefetPark.Application.ViewModels.Response.RegistroEntradaSaida.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Caching;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using Microsoft.Win32;
using System.Net;

namespace CefetPark.Application.Services
{
    public class RegistroEntradaSaidaService : IRegistroEntradaSaidaService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IRegistroEntradaSaidaRepository _registroEntradaSaidaRepository;
        private readonly IFilaEstacionamentoRepositoryCaching _filaEstacionamentoCaching;
        private readonly IFilaEstacionamentoJob _filaEstacionamentoJob;
        public RegistroEntradaSaidaService(ICommonRepository commonRepository, IMapper mapper, INotificador notificador, IRegistroEntradaSaidaRepository registroEntradaSaidaRepository, IFilaEstacionamentoRepositoryCaching filaEstacionamentoCaching, IFilaEstacionamentoJob filaEstacionamentoJob)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
            _notificador = notificador;
            _registroEntradaSaidaRepository = registroEntradaSaidaRepository;
            _filaEstacionamentoCaching = filaEstacionamentoCaching;
            _filaEstacionamentoJob = filaEstacionamentoJob;
        }


        public async Task<bool> AtualizarAsync(AtualizarRegistroEntradaSaidaRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<RegistroEntradaSaida>(request.Id, new List<string> { "RegistrosOcupacao"});

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;
            }

            if(entidade.DataSaida != null)
            {
                _notificador.Handle(new Notificacao("Esse carro não se encontra no estacionamento"));
                return false;
            }

            var estacionamento = await _commonRepository.ObterPorIdAsync<Estacionamento>(entidade.Estacionamento_Id);

            if (estacionamento == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);
            _commonRepository.RastrearEntidade(estacionamento);

            AtualizacaoHelper.AtualizarCamposEntidadeComBaseNaViewModel(request, entidade);

            estacionamento.QtdVagasLivres++;


            entidade.RegistrosOcupacao.Add(new RegistroOcupacao { Data = entidade.DataSaida.Value, QuantidadeVagasLivres = estacionamento.QtdVagasLivres });


            await _commonRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<bool> CadastrarAsync(CadastrarRegistroEntradaSaidaRequest request)
        {
            
            if(request.Usuario_Id != 0)
            {
                var usuario = await _commonRepository.ObterPorIdAsync<Usuario>(request.Usuario_Id, new List<string> { "Carros" });
                if (usuario == null)
                {
                    _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                    return false;
                }

                if (!usuario.Carros.Any(x => x.Id == request.Carro_Id))
                {
                    _notificador.Handle(new Notificacao(EMensagemNotificacao.ESSE_CARRO_NAO_PERTENCE_A_ESSA_ENTIDADE));
                    return false;
                }
            }
            else
            {
                var convidado = await _commonRepository.ObterPorIdAsync<Convidado>(request.Convidado_Id, new List<string> { "Carros"});
                if(convidado == null)
                {
                    _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                    return false;
                }

                if(!convidado.Carros.Any(x => x.Id == request.Carro_Id))
                {
                    _notificador.Handle(new Notificacao(EMensagemNotificacao.ESSE_CARRO_NAO_PERTENCE_A_ESSA_ENTIDADE));
                    return false;
                }
            }

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

            var estacionamento = await _commonRepository.ObterPorIdAsync<Estacionamento>(request.Estacionamento_Id);

            if (estacionamento == null)
            {

                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;

            }

            if (estacionamento.QtdVagasLivres <= 0)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ESTACIONAMENTO_LOTADO));
                return false;
            }

            _commonRepository.RastrearEntidade(estacionamento);

            estacionamento.QtdVagasLivres--;

            var entidade = _mapper.Map<RegistroEntradaSaida>(request);

            if (entidade.Usuario_Id == 0) entidade.Usuario_Id = null;
            else entidade.Convidado_Id = null;

            entidade.RegistrosOcupacao.Add(new RegistroOcupacao { Data = entidade.DataEntrada, QuantidadeVagasLivres = estacionamento.QtdVagasLivres });
          

            await _commonRepository.AdicionarEntidadeAsync(entidade);
            await _commonRepository.SalvarAlteracoesAsync();


            return true;
        }

        public async Task<IEnumerable<ObterRegistroEntradaSaidaSemSaidaResponse>> ObterEstacionadosAsync(int estacionamento_Id)
        {
            var estacionamento = await _commonRepository.ObterPorIdAsync<Estacionamento>(estacionamento_Id);

            if (estacionamento == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var entidades = await _registroEntradaSaidaRepository.ObterEstacionadosAsync(estacionamento_Id);

            var response = entidades.Select(registro =>
            {
                var carroResponse = new ObterRegistroEntradaSaidaCarroResponse
                {
                    Id = registro.Carro.Id,
                    Placa = registro.Carro.Placa,
                    Cor = registro.Carro.Cor.Nome,
                    Modelo = registro.Carro.Modelo.Nome
                };

                return new ObterRegistroEntradaSaidaSemSaidaResponse
                {
                    Id = registro.Id,
                    DataEntrada = registro.DataEntrada,
                    Estacionamento_Id = registro.Estacionamento_Id,
                    Carro = carroResponse
                    // Mapeie outras propriedades conforme necessário
                };
            });
            return response;
        }
    }
}
