using Infra.Models.Table;
using System.Collections.Generic;

namespace Infra.Models.Temp
{
    public class VendaViewModel
    {
        public Venda Venda { get; set; }
        public List<ProdutoViewModel> Produtos { get; set; }
    }
}
