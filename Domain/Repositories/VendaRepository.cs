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
            var response = await _context.Venda.FindAsync(Id);
            
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

        public async Task Remove(int IdVenda)
        {
            var vendaToRemove = await Get(IdVenda);

            if (vendaToRemove != null)
            {
                _context.ProdutoVenda.RemoveRange(await _context.ProdutoVenda.Where(x => x.IdVenda.Equals(vendaToRemove.Id)).ToListAsync());
                _context.Venda.Remove(vendaToRemove);
            }
                
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Venda venda)
        {
            var entry = _context.Venda.FirstOrDefault(e => e.Id == venda.Id);

            if (entry != null)
            {
                await Task.Run(() => _context.Entry(entry).CurrentValues.SetValues(venda));
            }
        }
    }
}
