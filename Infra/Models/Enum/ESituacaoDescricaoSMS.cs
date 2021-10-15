using System.ComponentModel;

namespace Infra.Models.Enum
{
    public enum ESituacaoDescricaoSMS
    {
        [Description("Mensagem entregue no aparelho do cliente")]
        RECEBIDA,
        [Description("Mensagem enviada à operadora")]
        ENVIADA,
        [Description("Erro de validação da mensagem")]
        ERRO,
        [Description("Mensagem aguardando processamento")]
        FILA,
        [Description("Mensagem cancelada pelo usuário")]
        CANCELADA,        
        [Description("Destinatário ativo no grupo ‘Black List’")]
        BLACK_LIST
    }
}
