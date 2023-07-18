using CefetPark.WebApi.Models;
using System.Net;

namespace CefetPark.WebApi.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        private void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var mensagemErro = "Ops... Algo deu errado, Contate o Administrador do Sistema";

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.WriteAsJsonAsync(new CustomResponseError(new List<string> { mensagemErro }));

            this.EmitLogErrors(context, exception);
        }

        private void EmitLogErrors(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.StackTrace.ToString());
            _logger.LogError("QueryString = " + context.Request.QueryString.ToString());
            _logger.LogError("Path = " + context.Request.Path);
            _logger.LogError("Mensagem = " + exception.Message);

        }
    }
}
