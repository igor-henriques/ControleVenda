using Infra.Models.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<Venda>> GetVendas();
        Task<Venda> Get(int Id);
        Task<Venda> Add(Venda venda);
        Task Remove(int Id);
        Task Update(Venda venda);
        Task Save();
    }
}
