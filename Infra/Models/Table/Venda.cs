using Infra.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models.Table
{
    public record Venda
    {
        [Key]
        public int Id { get; init; }
        [DataType(DataType.Date)]
        public DateTime Data { get; init; }
        public decimal TotalVenda { get; init; }
        public decimal Acrescimo { get; init; }
        public decimal Desconto { get; init; }
        public EModoVenda ModoVenda { get; init; }
        public List<Produto> Produtos { get; init; }
    }
}
