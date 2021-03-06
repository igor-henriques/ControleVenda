using Domain.Interfaces;
using Infra.Data;
using Infra.Models;
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
        private readonly Settings _settings;
        public ProdutoRepository(ApplicationDbContext context, Settings settings)
        {
            this._settings = settings;
            this._context = context;
        }
        public async Task Add(Produto produto)
        {
            await Task.Run(() =>
            {
                _context.Produto.Add(produto);
            });
        }

        public async Task<List<Venda>> ChecarVendasComProduto(List<Produto> produtos)
        {
            return await _context.ProdutoVenda.Include(x => x.Venda).Where(x => produtos.Select(x => x.Id).Contains(x.IdProduto)).Select(x => x.Venda).ToListAsync();
        }

        public async Task<Produto> Get(int Id)
        {
            return await _context.Produto.FindAsync(Id);
        }

        public async Task<Produto> Get(string nome)
        {
            return await _context.Produto.Where(x => x.Nome.Equals(nome)).FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produto.AsNoTracking().Take(_settings.RegistrosEmTabela).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> Pesquisar(string campo, string conteudo)
        {
            IQueryable<Produto> foundProducts = default;

            await Task.Run(() =>
            {
                foundProducts = campo switch
                {
                    "Nome"  => from i in _context.Produto.AsNoTracking()
                               where EF.Functions.Like(i.Nome, $"%{conteudo.Trim()}%")
                               select i,

                    "Preco" => from i in _context.Produto.AsNoTracking()
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

            foreach (var product in productsToRemove)
            {
                var vendasComProduto = await _context.ProdutoVenda.Include(x => x.Venda).Where(x => x.IdProduto.Equals(product.Id)).Select(x => x.Venda).ToListAsync();

                _context.Venda.RemoveRange(vendasComProduto);
            }

            await Task.Run(() => _context.Produto.RemoveRange(productsToRemove));
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
