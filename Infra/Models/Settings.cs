using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Infra.Models
{
    [Serializable]
    public record Settings
    {
        [JsonProperty("SMS KEY")]
        public string Key { get; init; }
        [JsonProperty("NOME DO NEGÓCIO")]
        public string NomeNegocio { get; init; }
        [JsonProperty("PIX")]
        public string PIX { get; init; }
        [JsonProperty("PICPAY")]
        public string PicPay { get; init; }
        [JsonProperty("REGISTROS EM TABELA")]
        public int RegistrosEmTabela { get; init; }

        public Settings()
        {
            var settings = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("./Configuração.json"));

            this.Key = settings["SMS KEY"].ToObject<string>();
            this.NomeNegocio = settings["NOME DO NEGÓCIO"].ToObject<string>();
            this.PIX = settings["PIX"].ToObject<string>();
            this.PicPay = settings["PICPAY"].ToObject<string>();
            this.RegistrosEmTabela = settings["REGISTROS EM TABELA"].ToObject<int>();
        }
    }
}
