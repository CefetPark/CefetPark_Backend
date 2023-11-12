using CefetPark.Application.Models;
using CefetPark.Infra.Contexts;
using CefetPark.WebApi.Extensions;
using CefetPark.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CefetPark.WebApi.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(options =>
            {
                string defaultConnection = configuration.GetConnectionString("DefaultConnection");

                options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
            });

            var redisConnectionSection = configuration.GetSection("RedisConnection");
            services.Configure<RedisConnection>(redisConnectionSection);

            var redisConnection = redisConnectionSection.Get<RedisConnection>();
            services.AddStackExchangeRedisCache(o =>
            {
                o.InstanceName = redisConnection.InstanceName;
                o.Configuration = redisConnection.Configuration;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
                options.InvalidModelStateResponseFactory = context =>
                {
                    var erros = context.ModelState.Values.SelectMany(e => e.Errors);
                    var errosResult = erros.Select(x => x.ErrorMessage);

                    var result = new CustomResponseError(errosResult);

                    return new UnprocessableEntityObjectResult(result);
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
