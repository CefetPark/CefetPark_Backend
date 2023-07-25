﻿
using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Models;
using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Application.ViewModels.Response.Auth.Post;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CefetPark.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly INotificador _notificador;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ICommonRepository _commonRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AuthService(INotificador notificador, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, ICommonRepository commonRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
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

        public async Task<LoginAuthResponse> LoginAsync(LoginAuthRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Login, request.Senha, false, true);
            if (!result.Succeeded)
            {
                _notificador.Handle(new Notificacao("Usuario ou Senha Incorreto", HttpStatusCode.NotFound));
                return null;
            }
            if (result.IsLockedOut)
            {
                _notificador.Handle(new Notificacao("Usuario temporariamente bloqueado por tentativas inválidas"));
                return null;
            }


            var user = await _userManager.FindByNameAsync(request.Login);
            var token = await GerarJwt(user);

            var payload = new LoginAuthResponse
            {
                Token = token
            };


            return payload;
        }


        private async Task<string?> GerarJwt(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var usuario = await _usuarioRepository.ObterPorGuidIdAsync(user.Id);

            if (usuario == null)
            {
                _notificador.Handle(new Notificacao("Usuario_Id Não encontrado", HttpStatusCode.NotFound));
                return null;
            }

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            claims.Add(new("Id", usuario.Id.ToString()));


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

        public async Task<bool> CadastrarAsync(CadastrarAuthRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Login,
                EmailConfirmed = true,
                 
            };

            var result = await _userManager.CreateAsync(user, request.Senha);
            var userAspNet = await _userManager.FindByNameAsync(request.Login);
            
            var usuario = _mapper.Map<Usuario>(request.Usuario);
            usuario.Cpf = request.Login;
            usuario.AspNetUsers_Id = userAspNet.Id;

            await _commonRepository.AdicionarEntidadeAsync(usuario);

            await _commonRepository.SalvarAlteracoesAsync();


            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _notificador.Handle(new Notificacao(error.Description));
                }
                return false;
            }

            await _signInManager.SignInAsync(user, false);

            return true;
        }
    }
}