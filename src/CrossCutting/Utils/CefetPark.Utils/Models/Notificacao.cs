
using CefetPark.Utils.Enums;
using CefetPark.Utils.Helpers;
using System.ComponentModel;
using System.Net;

namespace CefetPark.Utils.Models
{
    public class Notificacao
    {
        public int HttpStatusCode { get; }
        public string Mensagem { get; }
        public Notificacao(string mensagem, HttpStatusCode httpStatusCode = System.Net.HttpStatusCode.BadRequest)
        {
            Mensagem = mensagem;
            HttpStatusCode = (int)httpStatusCode;

        }
        public Notificacao(EMensagemNotificacao mensagem, HttpStatusCode httpStatusCode = System.Net.HttpStatusCode.BadRequest)
        {
            Mensagem = EnumHelper.ObterDescricao(mensagem);
            HttpStatusCode = (int)httpStatusCode;

        }
        
    }
    
}
