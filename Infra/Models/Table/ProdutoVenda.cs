using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Models.Table
{
    public record ProdutoVenda
    {
        [Key]
        public int Id { get; init; }
        [ForeignKey("Venda")]
        public int IdVenda { get; init; }
        public virtual Venda Venda { get; init; }
        [ForeignKey("Produto")]
        public int IdProduto { get; init; }
        public virtual Produto Produto { get; init; }
        public int Quantidade { get; init; }
    }
}
