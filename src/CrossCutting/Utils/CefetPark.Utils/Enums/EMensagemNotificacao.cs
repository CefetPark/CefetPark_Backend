using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;


namespace CefetPark.Utils.Enums
{
    public enum EMensagemNotificacao
    {
        [Description("Entidade não encontrada!")]
        ENTIDADE_NAO_ENCONTRADA,
        [Description("Esse Usuario possui um registro de entrada no estacionamento e a sua data de saida não foi registrada")]
        USUARIO_JA_ESTACIONADO,
        [Description("Esse Carro possui um registro de entrada no estacionamento e a sua data de saida não foi registrada")]
        CARRO_JA_ESTACIONADO,
        [Description("Já existe um usuario com essa matricula!")]
        MATRICULA_JA_EXISTENTE,
        [Description("Já existe um usuario com esse cpf")]
        CPF_JA_EXISTENTE,
        [Description("Estacionamento Lotado")]
        ESTACIONAMENTO_LOTADO,
        [Description("Tipo usuario não encontrado!")]
        TIPO_USUARIO_NAO_ENCONTRADO,



    }
}
