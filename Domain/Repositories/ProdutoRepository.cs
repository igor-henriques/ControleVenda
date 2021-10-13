using Domain.Interfaces;
using Infra.Data;
using Infra.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task Add(Produto produto)
        {
            await Task.Run(() =>
            {
                _context.Produto.Add(produto);
            });
        }

        public async Task<Produto> Get(int Id)
        {
            return await _context.Produto.FindAsync(Id);
        }

        public Task<Produto> Get(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produto.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> Pesquisar(string campo, string conteudo)
        {
            IQueryable<Produto> foundProducts = default;

            await Task.Run(() =>
            {
                foundProducts = campo switch
                {
                    string field when field.Equals("Nome") => from i in _context.Produto.AsNoTracking()
                                                              where EF.Functions.Like(i.Nome, $"%{conteudo.Trim()}%")
                                                              select i,

                    string field when field.Equals("Preco") => from i in _context.Produto.AsNoTracking()
                                                               where EF.Functions.Like(i.Preco, $"%{conteudo.Trim()}%")
                                                               select i,

                    _ => null
                };
            });

            return foundProducts.Where(x => x != null).AsEnumerable();
        }

        public async Task Remove(int Id)
        {
            var productToRemove = await Get(Id);

            if (productToRemove != null)
                _context.Produto.Remove(productToRemove);
        }

        public async Task Remove(List<Produto> produtos)
        {
            var productsToRemove = await _context.Produto.Where(x => produtos.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            await Task.Run(() => _context.Produto.RemoveRange(produtos));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Produto produto)
        {
            var entry = _context.Produto.FirstOrDefault(e => e.Id == produto.Id);

            if (entry != null)
            {
                await Task.Run(() => _context.Entry(entry).CurrentValues.SetValues(produto));
            }
        }
    }
}
