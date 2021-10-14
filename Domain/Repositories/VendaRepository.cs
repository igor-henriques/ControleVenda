using Domain.Interfaces;
using Infra.Data;
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

        public VendaRepository(ApplicationDbContext context)
        {
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

        public async Task AddProducts(VendaViewModel venda)
        {
            await Task.Run(() =>
            {
                List<ProdutoVenda> produtosPorVenda = new();

                foreach (var produto in venda.Produtos)
                {
                    ProdutoVenda produtoNaVenda = new()
                    {
                        IdProduto = produto.Produto.Id,
                        IdVenda = venda.Venda.Id,
                        Quantidade = produto.Quantidade,
                    };

                    produtosPorVenda.Add(produtoNaVenda);
                }

                _context.ProdutoVenda.AddRange(produtosPorVenda);
            });            
        }

        public async Task<Venda> Get(int Id)
        {
            var response = await _context.Venda.Include(x => x.Cliente).AsNoTracking().Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
            
            response = response with
            {
                Produtos = await _context.ProdutoVenda
                    .Include(x => x.Produto)
                    .Where(x => x.IdVenda
                    .Equals(response.Id))
                    .Select(x => x.Produto)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<List<Venda>> Get(List<int> idVendas)
        {
            return await _context.Venda.Include(x => x.Cliente).Where(x => idVendas.Contains(x.Id)).ToListAsync();
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
            List<Venda> response = new();

            var vendas = await _context.Venda.Include(x => x.Cliente).ToListAsync();

            foreach (var venda in vendas)
            {
                response.Add(venda with
                {
                    Produtos = await _context.ProdutoVenda
                    .Include(x => x.Produto)
                    .Where(x => x.IdVenda
                    .Equals(venda.Id))
                    .Select(x => x.Produto)
                    .ToListAsync()
                });
            }

            return response;
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
    }
}
