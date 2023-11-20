
using CefetPark.Utils.Interfaces.External_Apis;
using CefetPark.Utils.Models;
using System.Net.Mail;
using System.Net;

namespace CefetPark.Utils.External_Apis
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
        }
        public async Task<bool> EnviarEmailAsync(EnviarEmailRequest request)
        {
            string fromAddress = "cefetrjpark@gmail.com";
            string toAddress = request.Email;
            string subject = "Redefinição de Senha Cefet Park";
            string body = $"Prezado {request.NomeUsuario},\r\n\r\nGostaríamos de informar que sua solicitação de redefinição de senha foi concluída com sucesso. Abaixo, você encontrará os detalhes da sua nova senha:\r\n\r\nNova Senha: {request.Senha}\r\n\r\nPedimos que faça login utilizando esta nova senha. Recomendamos que, após o login, altere a senha para uma de sua escolha através das configurações da sua conta.\r\n\r\nSe você não solicitou esta redefinição de senha ou tiver qualquer dúvida, entre em contato conosco imediatamente.\r\n\r\nAgradecemos pela sua compreensão e colaboração.\r\n\r\nCefet Park";

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false // Defina como true se o corpo for HTML
            })
            {
                using (var client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("cefetrjpark@gmail.com", "wzem kbxq arhc hyes"),
                    EnableSsl = true,
                })
                {
                    await client.SendMailAsync(message);
                }
            }

            return true;
        }
    }
}
