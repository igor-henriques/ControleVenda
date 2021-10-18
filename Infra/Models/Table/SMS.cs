using Infra.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Models.Table
{
    public record SMS
    {
        [Key]
        public long Id { get; init; }
        public ESituacaoResponseSMS Situacao { get; init; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; init; }
        public Cliente Cliente { get; init; }
        public int Codigo { get; init; }        
        public string Descricao { get; init; }
        public string Mensagem { get; init; }
    }
}