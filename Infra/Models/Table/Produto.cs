using System;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models.Table
{
    public record Produto
    {
        [Key]
        public int Id { get; init; }
        [MaxLength(50)]
        public string Nome { get; init; }
        public decimal Preco { get; init; }
    }
}
