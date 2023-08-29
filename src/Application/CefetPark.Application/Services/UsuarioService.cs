
using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Models;
using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Application.ViewModels.Request.Common.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Auth.Post;
using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace CefetPark.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly INotificador _notificador;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ICommonRepository _commonRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(INotificador notificador, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, ICommonRepository commonRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _notificador = notificador;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _commonRepository = commonRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarAsync(CadastrarUsuarioRequest request)
        {
            var userRoleEntidade = await _commonRepository.ObterPorIdAsync<TipoUsuario>(request.TipoUsuario_Id);

            if (userRoleEntidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.TIPO_USUARIO_NAO_ENCONTRADO));
                return false;
            }

            var matriculaExiste = await _usuarioRepository.MatriculaExisteAsync(request.Matricula);

            if (matriculaExiste)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.MATRICULA_JA_EXISTENTE));
                return false;
            }

            var cpfExiste = await _usuarioRepository.CpfExisteAsync(request.Cpf);

            if (cpfExiste)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.CPF_JA_EXISTENTE));
                return false;
            }

            var user = new IdentityUser
            {
                UserName = request.Cpf,
                EmailConfirmed = true,

            };

            var result = await _userManager.CreateAsync(user, request.Senha);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _notificador.Handle(new Notificacao(error.Description));
                }
                return false;
            }

            var result2 = await _userManager.AddToRoleAsync(user, userRoleEntidade.Nome);

            if (!result2.Succeeded)
            {
                foreach (var error in result2.Errors)
                {
                    _notificador.Handle(new Notificacao(error.Description));
                }
                return false;
            }

            var userAspNet = await _userManager.FindByNameAsync(request.Cpf);

            var usuario = _mapper.Map<Usuario>(request);

            usuario.Cpf = request.Cpf;
            usuario.AspNetUsers_Id = userAspNet.Id;

            await _commonRepository.AdicionarEntidadeAsync(usuario);

            await _commonRepository.SalvarAlteracoesAsync();

            await _signInManager.SignInAsync(user, false);

            return true;
        }

        public async Task<string> CadastrarListaAsync(List<CadastrarUsuarioRequest> usuarios)
        {
            var successCount = 0;

            foreach (var usuario in usuarios)
            {
                var cadastrado = await CadastrarAsync(usuario);
                if (cadastrado)
                {
                    successCount++;
                }
            }

            string result = $"Foram cadastrados com sucesso {successCount} usuários.";

            return result;
        }

        public async Task<ObterUsuarioResponse?> ObterPorIdAsync(int id)
        {
            var entidade = await _commonRepository.ObterPorIdAsync<Usuario>(id, new List<string> { "Carros", "TipoUsuario", "Departamentos" });

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var response = _mapper.Map<ObterUsuarioResponse>(entidade);

            return response;
        }

        public async Task<ObterUsuarioSegurancaResponse?> ObterPorGuidIdAsync(string aspNetUser_Id)
        {
            var entidade = await _usuarioRepository.ObterPorGuidIdAsync(aspNetUser_Id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }



            var usuarioPayload = new ObterUsuarioSegurancaResponse
            {
                Id = entidade.Id,
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula,
                Nome = entidade.Nome,
                TelefonePrincipal = entidade.TelefonePrincipal,
                TelefoneSecundario = entidade.TelefoneSecundario,
                EmailPrincipal = entidade.EmailPrincipal,
                EmailSecundario = entidade.EmailSecundario,
                Departamento = entidade.Departamento.Nome,
                TipoUsuario = entidade.TipoUsuario.Nome,
                Carros = entidade.Carros.Select(x => new LoginCarroAuthResponse
                {
                    Id = x.Id,
                    Cor = x.Cor.Nome,
                    Modelo = x.Modelo.Nome,
                    Placa = x.Placa
                }).ToList()
            };

            return usuarioPayload;
        }

        public async Task<IEnumerable<ObterUsuarioResponse>> ObterTodosAsync()
        {
            var entidades = await _commonRepository.ObterTodosAsync<Usuario>(new List<string> { "Departamento", "TipoUsuario", "Carros" });

            var response = _mapper.Map<IEnumerable<ObterUsuarioResponse>>(entidades);

            return response;
        }

        //Task<bool> AtualizarAsync(AtualizarCommonRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<bool> DesativarAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
