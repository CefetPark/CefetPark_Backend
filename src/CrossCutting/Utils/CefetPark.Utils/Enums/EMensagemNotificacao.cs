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
        [Description("Esse Estacionamento Possui uma fila e ela deve ser respeitada!")]
        RESPEITE_A_FILA_DO_ESTACIONAMENTO,
        [Description("Esse Estacionamento Possui uma fila e ninguem foi chamado!")]
        FILA_NINGUEM_FOI_CHAMADO,
        [Description("Esse Estacionamento não está cheio, portanto não é necessário entrar na fila!")]
        SEM_NECESSIDADE_DE_FILA,
        [Description("Usuario já está na fila para esse estacionamento!")]
        USUARIO_JA_ESTA_NA_FILA,
        [Description("Usuario não está na fila para esse estacionamento!")]
        USUARIO_NAO_ESTA_NA_FILA,
        [Description("Esse carro não pertence a essa entidade")]
        ESSE_CARRO_NAO_PERTENCE_A_ESSA_ENTIDADE



    }
}
