
using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Models;
using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Application.ViewModels.Response.Auth.Post;
using CefetPark.Application.ViewModels.Response.Carro.Get;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using CefetPark.Utils.Interfaces.External_Apis;
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
    public class AuthService : IAuthService
    {
        private readonly INotificador _notificador;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUser _user;

        private readonly ICommonRepository _commonRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AuthService(INotificador notificador, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, ICommonRepository commonRepository, IUsuarioRepository usuarioRepository, IMapper mapper, IEmailService emailService, IUser user)
        {
            _notificador = notificador;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _commonRepository = commonRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _emailService = emailService;
            _user = user;
        }

        public async Task<LoginAuthResponse> LoginAsync(LoginAuthRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Login, request.Senha, false, true);
            if (!result.Succeeded)
            {
                _notificador.Handle(new Notificacao("Usuario ou Senha Incorreto", HttpStatusCode.Unauthorized));
                return null;
            }
            if (result.IsLockedOut)
            {
                _notificador.Handle(new Notificacao("Usuario temporariamente bloqueado por tentativas inválidas"));
                return null;
            }


            var user = await _userManager.FindByNameAsync(request.Login);
            var usuario = await _usuarioRepository.ObterPorGuidIdAsync(user.Id);

            if (usuario == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA, HttpStatusCode.NotFound));
                return null;
            }

            var token = await GerarJwt(user, usuario);



            var usuarioPayload = new LoginUsuarioAuthResponse
            {
                AspNetUsers_Id = usuario.AspNetUsers_Id,
                Cpf = usuario.Cpf,
                Matricula = usuario.Matricula,
                Nome = usuario.Nome,
                TelefonePrincipal = usuario.TelefonePrincipal,
                TelefoneSecundario = usuario.TelefoneSecundario,
                EmailPrincipal = usuario.EmailPrincipal,
                EmailSecundario = usuario.EmailSecundario,
                Departamento = usuario.Departamento.Nome,
                TipoUsuario = usuario.TipoUsuario.Nome,
                TrocarSenha = usuario.TrocarSenha,
                Carros = usuario.Carros.Select(x => new LoginCarroAuthResponse
                {
                    Id = x.Id,
                    Cor = x.Cor.Nome,
                    Modelo = x.Modelo.Nome,
                    Placa = x.Placa
                }).ToList()
            };

            var payload = new LoginAuthResponse
            {
                Token = token,
                Usuario = usuarioPayload
            };


            return payload;
        }


        private async Task<string?> GerarJwt(IdentityUser user, Usuario usuario)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            claims.Add(new("Id", usuario.Id.ToString()));
            claims.Add(new("Nome", usuario.Nome));


            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public async Task<bool> EsqueciMinhaSenhaAsync(EsqueciMinhaSenhaRequest request)
        {

            var usuarioEntidade = await _usuarioRepository.ObterPorCpfAsync(request.Cpf);

            if (usuarioEntidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                return false;
            }

            var user = await _userManager.FindByIdAsync(usuarioEntidade.AspNetUsers_Id);
            if (user == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                return false;
            }

            

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var senha  = $"Cefet{request.Cpf.Substring(0, 3)}!";
            var result = await _userManager.ResetPasswordAsync(user, token, senha);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _notificador.Handle(new Notificacao(error.Description));
                }
                return false;
            }

            await _emailService.EnviarEmailAsync(new EnviarEmailRequest { Senha = senha, Email = usuarioEntidade.EmailPrincipal, NomeUsuario = usuarioEntidade.Nome });

            _commonRepository.RastrearEntidade(usuarioEntidade);

            usuarioEntidade.TrocarSenha = true;

            await _commonRepository.SalvarAlteracoesAsync();


            return true;



        }

        public async Task<bool> RedefinirMinhaSenhaAsync(RedefinirMinhaSenhaRequest request)
        {

            var usuarioEntidade = await _usuarioRepository.ObterPorIdSemRelacionamentoAsync(_user.ObterUsuarioId());

            if (usuarioEntidade == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                return false;
            }

            var user = await _userManager.FindByIdAsync(usuarioEntidade.AspNetUsers_Id);
            if (user == null)
            {
                _notificador.Handle(new Notificacao(EMensagemNotificacao.ENTIDADE_NAO_ENCONTRADA));
                return false;
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);


            var result = await _userManager.ResetPasswordAsync(user, token, request.NovaSenha);



            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _notificador.Handle(new Notificacao(error.Description));
                }
                return false;
            }

            _commonRepository.RastrearEntidade(usuarioEntidade);

            usuarioEntidade.TrocarSenha = false;

            await _commonRepository.SalvarAlteracoesAsync();

            return true;

        }
    }
}
