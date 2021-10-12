using Infra.Models.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente> Get(int Id);
        Task<Cliente> Add(Cliente cliente);
        Task Remove(int Id);
        Task Update(Cliente cliente);
        Task Save();
    }
}
