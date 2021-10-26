using Domain.Interfaces;
using Infra.Data;
using Infra.Models;
using Infra.Models.Enum;
using Infra.Models.Table;
using Infra.Models.Temp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly Settings _settings;

        public VendaRepository(ApplicationDbContext context, Settings settings)
        {
            this._settings = settings;
            this._context = context;
        }

        public async Task<Venda> Add(Venda venda)
        {
            EntityEntry<Venda> response = default;

            await Task.Run(() =>
            {
                response = _context.Venda.Add(venda);
            });

            return response?.Entity;
        }

        public async Task AddRange(List<Venda> vendas)
        {
            await Task.Run(() =>
            {
                _context.Venda.AddRange(vendas);
            });
        }

        public async Task AddProducts(List<ProdutoVenda> venda)
        {
            await Task.Run(() =>
            {
                _context.ProdutoVenda.AddRange(venda);
            });
        }

        public async Task<List<Venda>> Pay(List<Venda> vendas)
        {
            var vendasParaProcessar = await _context.Venda.Where(x => vendas.Select(x => x.Id).Contains(x.Id) & x.VendaPaga.Equals(false)).ToListAsync();

            if (vendasParaProcessar?.Count > 0)
                foreach (var venda in vendasParaProcessar)
                {
                    _context.Entry(venda).CurrentValues.SetValues(venda with { VendaPaga = true });
                }

            return vendasParaProcessar;
        }

        public async Task<Venda> Get(int Id)
        {
            return await _context.Venda.Include(x => x.Cliente).Include(x => x.Produtos).AsNoTracking().Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Venda>> Get(List<int> idVendas)
        {
            return await _context.Venda.Where(x => idVendas.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<ProdutoVenda>> GetProdutosPorVenda(int idVenda)
        {
            var response = await _context.Venda.FindAsync(idVenda);

            var produtosResponse = await (from i in _context.ProdutoVenda.Include(x => x.Produto)
                                          where i.IdVenda.Equals(response.Id)
                                          select new ProdutoVenda() { Produto = i.Produto, Quantidade = i.Quantidade }).ToListAsync();

            return produtosResponse;
        }

        public async Task<List<Venda>> GetVendas()
        {
            return await _context.Venda.Include(x => x.Cliente).Include(x => x.Produtos).OrderByDescending(x => x.Data).ThenByDescending(x => x.Id).Take(_settings.RegistrosEmTabela).ToListAsync();
        }

        public async Task Remove(List<Venda> vendas)
        {
            List<Venda> vendasToRemove = await Get(vendas.Select(x => x.Id).ToList());

            if (vendasToRemove != null)
            {
                _context.ProdutoVenda.RemoveRange(await _context.ProdutoVenda.Where(x => vendasToRemove.Select(x => x.Id).Contains(x.Id)).ToListAsync());
                _context.Venda.RemoveRange(vendasToRemove);
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Venda>> SearchByCliente(Cliente cliente)
        {
            return await _context.Venda.Include(x => x.Cliente).Where(x => x.IdCliente.Equals(cliente.Id)).ToListAsync();
        }

        public async Task<List<Venda>> SearchByDate(DateTime initialDate, DateTime finalDate)
        {
            return await _context.Venda.Include(x => x.Cliente).Where(x => x.Data >= initialDate && x.Data <= finalDate).ToListAsync();
        }
        public async Task<List<Venda>> SearchByState(bool state)
        {
            return await _context.Venda.Include(x => x.Cliente).Where(x => x.VendaPaga.Equals(state)).ToListAsync();
        }

        public async Task<Venda> SearchByDateAndMode(DateTime initialDate, DateTime finalDate, EModoVenda modoVenda)
        {
            return await _context.Venda.Where(x => x.Data >= initialDate && x.Data <= finalDate && x.ModoVenda.Equals(modoVenda)).FirstOrDefaultAsync();
        }

        public async Task<List<Venda>> SearchExistingSale(DateTime initialDate, DateTime finalDate, EModoVenda modoVenda, List<int> clientes)
        {
            return await _context.Venda.Include(x => x.Cliente).Where(x => x.Data >= initialDate && x.Data <= finalDate && x.ModoVenda.Equals(modoVenda) && clientes.Contains(x.IdCliente)).ToListAsync();
        }

        public async Task SwitchSaleState(int idVenda, bool state)
        {
            var venda = await _context.Venda.FindAsync(idVenda);

            var vendaAlterada = venda with { VendaPaga = state };

            _context.Entry<Venda>(venda).CurrentValues.SetValues(vendaAlterada);
        }
    }
}
