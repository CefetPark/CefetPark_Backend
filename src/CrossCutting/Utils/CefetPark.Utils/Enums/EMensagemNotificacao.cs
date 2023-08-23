using System.ComponentModel;


namespace CefetPark.Utils.Enums
{
    public enum EMensagemNotificacao
    {
        [Description("Entidade não encontrada!")]
        ENTIDADE_NAO_ENCONTRADA,
        [Description("Esse Usuario possui um registro de entrada no estacionamento e a sua data de saida não foi registrada")]
        USUARIO_JA_ESTACIONADO,
        [Description("Esse Carro possui um registro de entrada no estacionamento e a sua data de saida não foi registrada")]
        CARRO_JA_ESTACIONADO

    }
}
