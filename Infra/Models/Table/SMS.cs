using Infra.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models.Table
{
    public record SMS
    {
        [Key]
        public long Id { get; init; }
        public ESituacaoResponseSMS Situacao { get; init; }
        public string TelefoneDestino { get; init; }
        public int Codigo { get; init; }        
        public string Descricao { get; init; }
        public string Mensagem { get; init; }
    }
}