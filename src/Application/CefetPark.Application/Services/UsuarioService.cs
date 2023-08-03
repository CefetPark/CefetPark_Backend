
using AutoMapper;
using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Models;
using CefetPark.Application.ViewModels.Request.Auth.Post;
using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Usuario.Post;
using CefetPark.Application.ViewModels.Response.Auth.Post;
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Application.ViewModels.Response.Usuario.Get;
using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Utils.Enums;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using Microsoft.AspNetCore.Identity;
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

        public Task<bool> AtualizarAsync(AtualizarCommonRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CadastrarAsync(CadastrarAuthRequest request)
        {
            var userRoleEntidade = await _commonRepository.ObterPorIdAsync<TipoUsuario>(request.Usuario.TipoUsuario_Id);
            
            if(userRoleEntidade == null)
            {
                _notificador.Handle(new Notificacao("TipoUsuario_Id não encontrado"));
                return false;
            }

            var user = new IdentityUser
            {
                UserName = request.Login,
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


            var userAspNet = await _userManager.FindByNameAsync(request.Login);
            

            var usuario = _mapper.Map<Usuario>(request.Usuario);
            
            usuario.Cpf = request.Login;
            usuario.AspNetUsers_Id = userAspNet.Id;

            await _commonRepository.AdicionarEntidadeAsync(usuario);

            await _commonRepository.SalvarAlteracoesAsync();




            await _signInManager.SignInAsync(user, false);

            return true;
        }

        public Task<bool> CadastrarAsync(CadastrarUsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DesativarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ObterCommonResponse?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ObterCommonResponse>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
