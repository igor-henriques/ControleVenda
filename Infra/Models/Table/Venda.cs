using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models.Table
{
    public record Venda
    {
        [Key]
        public int Id { get; init; }
        public DateTime Data { get; init; }
        public decimal TotalVenda { get; init; }
        public List<Produto> Produtos { get; init; }

    }
}
