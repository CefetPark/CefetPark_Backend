using CefetPark.Application.Interfaces.Services;
using CefetPark.Application.Services;
using CefetPark.Domain.Interfaces.Models;
using CefetPark.Infra.Contexts;
using CefetPark.Infra.Models;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
