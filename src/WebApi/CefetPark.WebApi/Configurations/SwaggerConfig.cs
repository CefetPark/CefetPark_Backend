using Microsoft.OpenApi.Models;

namespace CefetPark.WebApi.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new()
                    {
                        Title = "Cefet Park",
                        Version = "v1",
                        Description = "",
                        Contact = new() { Name = "Cefet Park" },
                        License = new() { Name = "MIT", Url = new("https://opensource.org/licenses/MIT") }
                    }
                    );

                c.AddSecurityDefinition("Bearer", new()
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new()
                {
                    {
                        new()
                        {
                            Reference = new()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, WebApplication webApplication)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}

