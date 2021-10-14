using Infra.Models.Table;
using Infra.Models.Temp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<Venda>> GetVendas();
        Task AddProducts(VendaViewModel venda);
        Task<Venda> Get(int Id);
        Task<Venda> Add(Venda venda);
        Task Remove(int Id);
        Task Update(Venda venda);
        Task<List<ProdutoVenda>> GetProdutosPorVenda(int idVenda);
        Task Save();
    }
}
