using CefetPark.Utils.Models;

namespace CefetPark.Utils.Interfaces.External_Apis
{
    public interface IEmailService
    {
        public Task<bool> EnviarEmailAsync(EnviarEmailRequest request);
    }
}
