    using CefetPark.Ioc.DependeciesInjection;
using CefetPark.WebApi.Configurations;



var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ResolveDependencies();
builder.Services.AddApiConfig(builder.Configuration);
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();

var app = builder.Build();

app.UseApiConfig(app.Environment);
app.UseSwaggerConfig(app);


app.Run();
