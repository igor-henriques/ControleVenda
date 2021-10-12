using Domain.Interfaces;
using Infra.Data;
using Infra.Models.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public async Task<Produto> Add(Produto produto)
        {
            EntityEntry<Produto> response = default;

            await Task.Run(() =>
            {
                if (!_context.Produto.Select(x => x.Id).Contains(produto.Id))
                    response = _context.Produto.Add(produto);
            });            

            return response?.Entity;
        }

        public async Task<Produto> Get(int Id)
        {
            return await _context.Produto.FindAsync(Id);
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
            var productToRemove = await _context.Produto.AsNoTracking().Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();

            if (productToRemove != null)
                _context.Produto.Remove(productToRemove);
        }

        public async Task Remove(List<Produto> produtos)
        {
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
