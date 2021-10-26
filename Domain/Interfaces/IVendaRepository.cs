using Infra.Models.Enum;
using Infra.Models.Table;
using Infra.Models.Temp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<Venda>> GetVendas();
        Task AddProducts(List<ProdutoVenda> venda);
        Task<Venda> Get(int Id);
        Task<List<Venda>> Get(List<int> idVendas);
        Task<Venda> Add(Venda venda);
        Task AddRange(List<Venda> vendas);
        Task Remove(List<Venda> vendas);
        Task<List<ProdutoVenda>> GetProdutosPorVenda(int idVenda);
        Task<List<Venda>> SearchByDate(DateTime initialDate, DateTime finalDate);
        Task<Venda> SearchByDateAndMode(DateTime initialDate, DateTime finalDate, EModoVenda modoVenda);
        Task<List<Venda>> SearchExistingSale(DateTime initialDate, DateTime finalDate, EModoVenda modoVenda, List<int> clientes);
        Task<List<Venda>> SearchByCliente(Cliente cliente);
        Task<List<Venda>> SearchByState(bool state);
        Task SwitchSaleState(int idVenda, bool state);
        Task Save();
        Task<List<Venda>> Pay(List<Venda> vendas);
    }
}
