using System.ComponentModel.DataAnnotations;

namespace Infra.Models.Table
{
    public record Cliente
    {
        [Key]
        public int Id { get; init; }
        [MaxLength(10)]
        public string Identificador { get; init; }
        [MaxLength(50)]
        public string Nome { get; init; }
        public ushort NumeroCurso { get; init; }
        public ushort Pelotao { get; init; }
        [MaxLength(20)]
        public string Telefone { get; init; }
    }
}