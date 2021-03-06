using Infra.Models.Enum;
using Newtonsoft.Json;
using System;

namespace Infra.SMS.Response
{
    [Serializable]
    public record ResponseSituacaoSMS
    {
        public ESituacaoResponseSMS Situacao { get; init; }
        public int Codigo { get; init; }
        [JsonProperty("data_envio")]
        public string DataEnvio { get; init; }
        public string Operadora { get; init; }
        public string Descricao { get; init; }
    }
}
