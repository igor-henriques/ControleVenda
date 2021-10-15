using Infra.Models.Enum;
using System;

namespace Infra.SMS.Response
{
    [Serializable]
    public record ResponseSendSMS
    {
        public ESituacaoResponseSMS Situacao { get; init; }
        public int Codigo { get; init; }
        public long Id { get; init; }
        public string Descricao { get; init; }
    }
}
