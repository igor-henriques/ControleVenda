using Infra.Models.Enum;
using Newtonsoft.Json;
using System;

namespace Infra.SMS.Response
{
    [Serializable]
    public class ResponseSaldoSMS
    {
        public ESituacaoResponseSMS Situacao { get; set; }
        [JsonProperty("saldo_sms")]
        public int SaldoSMS { get; set; }
        public string Descricao { get; set; }
    }
}
