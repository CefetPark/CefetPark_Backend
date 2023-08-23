using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Models;
using CefetPark.Application.Services;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;
using CefetPark.Infra.Repositories;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CefetPark.Ioc.DependeciesInjection
{
    public static class DependenciesInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<DataContext>();
           

            #region Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEstacionamentoService, EstacionamentoService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<ICorService, CorService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IRegistroEntradaSaidaService, RegistroEntradaSaidaService>();
            #endregion

            #region Repositories
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRegistroEntradaSaidaRepository, RegistroEntradaSaidaRepository>();
            services.AddScoped<ICarroRepository, CarroRepository>();
            #endregion

            #region Models
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();
            #endregion


            return services;
        }
    }
}
