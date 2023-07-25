using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Models;
using CefetPark.Application.Services;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Domain.Interfaces.Repositories;
using CefetPark.Infra.Contexts;
using CefetPark.Infra.Models;
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
            #endregion

            #region Repositories
            services.AddScoped<ICommonRepository, CommonRepository>();
            #endregion

            #region Models
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();
            #endregion


            return services;
        }
    }
}
