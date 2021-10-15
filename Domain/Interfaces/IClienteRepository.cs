using Infra.Models.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientes();
        Task<List<Venda>> ChecarVendasComCliente(List<Cliente> clientes);
        Task<Cliente> Get(int Id);
        Task<Cliente> Get(string Identificador);
        Task<Cliente> Add(Cliente cliente);
        Task Remove(int Id);
        Task Remove(List<Cliente> clientes);
        Task Update(Cliente cliente);
        Task Save();
        Task<IEnumerable<Cliente>> Pesquisar(string campo, string conteudo);
        Task<List<Venda>> VendasPorCliente(Cliente cliente);
    }
}
