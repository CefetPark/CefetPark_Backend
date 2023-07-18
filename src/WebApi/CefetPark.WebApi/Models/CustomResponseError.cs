using CefetPark.Utils.Models;

namespace CefetPark.WebApi.Models
{
    public class CustomResponseError
    {
        public IEnumerable<string> Erros { get; set; }

        public CustomResponseError(IEnumerable<Notificacao> erros)
        {
            Erros = erros.Select(n => n.Mensagem);
        }
        public CustomResponseError(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
