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
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICommonRepository commonRepository, INotificador notificador, IMapper mapper, ICarroRepository carroRepository)
        {
            _commonRepository = commonRepository;
            _notificador = notificador;
            _mapper = mapper;
            _carroRepository = carroRepository;
        }
        public async Task<bool> AtualizarAsync(AtualizarCarroRequest request)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Carro>(request.Id, new List<string> { "Usuarios" });

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return false;
            }

            _commonRepository.RastrearEntidade(entidade);


            AtualizacaoHelper.AtualizarCamposEntidadeComBaseNaViewModel(request, entidade);

            entidade.Usuarios.Clear();
            entidade.Usuarios = _mapper.Map<ICollection<Usuario>>(request.Usuarios);

            _commonRepository.RastrearEntidades(entidade.Usuarios);
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
            var entidade = await _commonRepository.ObterPorIdAsync<Carro>(id, new List<string> { "Usuarios", "Cor", "Modelo" });

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterCarroResponse>(entidade);

            return response;
        }

        public async Task<ObterCarroResponse?> ObterPorPlacaAsync(string placa)
        {
            var entidade = await _carroRepository.ObterPorPlacaAsync(placa);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = new ObterCarroResponse
            {
                Id = entidade.Id,
                Cor = entidade.Cor.Nome,
                Modelo = entidade.Modelo.Nome,
                Placa = placa,
                Usuarios = entidade.Usuarios.Select(x => new ObterCarroUsuarioResponse
                {
                    Id = x.Id,
                    Cpf = x.Cpf,
                    Matricula = x.Matricula,
                    Nome = x.Nome,
                    TelefonePrincipal = x.TelefonePrincipal,
                    TelefoneSecundario = x.TelefoneSecundario,
                    EmailPrincipal = x.EmailPrincipal,
                    EmailSecundario = x.EmailSecundario,
                    Departamento = x.Departamento.Nome,
                    TipoUsuario = x.TipoUsuario.Nome
                }).ToList()
            };

            return response;

        }

        public async Task<IEnumerable<ObterCarroResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Carro>(new List<string> { "Usuarios", "Cor", "Modelo" });

            var response = _mapper.Map<IEnumerable<ObterCarroResponse>>(entidades);


            return response;
        }


    }
}
