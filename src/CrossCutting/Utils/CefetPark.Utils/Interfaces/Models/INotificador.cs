
using CefetPark.Utils.Models;

namespace CefetPark.Utils.Interfaces.Models
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
