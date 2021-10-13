using Domain.Interfaces;
using Infra.Data;
using Infra.Models.Table;
using Infra.Models.Temp;
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

        public Task<Venda> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Venda>> GetVendas()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}
