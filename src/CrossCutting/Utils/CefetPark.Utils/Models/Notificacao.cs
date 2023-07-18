
using System.Net;

namespace CefetPark.Utils.Models
{
    public class Notificacao
    {
        public Notificacao(string mensagem, HttpStatusCode httpStatusCode = System.Net.HttpStatusCode.BadRequest)
        {
            Mensagem = mensagem;
            HttpStatusCode = (int)httpStatusCode;

        }
        public int HttpStatusCode { get; }
        public string Mensagem { get; }
    }
}
