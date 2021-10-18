using Domain.Interfaces;
using Infra.Data;
using Infra.Models;
using Infra.Models.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Cliente> Add(Cliente cliente)
        {
            EntityEntry<Cliente> response = default;

            await Task.Run(() =>
            {
                response = _context.Cliente.Add(cliente);
            });

            return response?.Entity;
        }

        public async Task<List<Venda>> ChecarVendasComCliente(List<Cliente> clientes)
        {
            return await _context.Venda.Where(x => clientes.Select(y => y.Id).Contains(x.IdCliente)).ToListAsync();
        }

        public async Task<Cliente> Get(int Id)
        {
            return await _context.Cliente.FindAsync(Id);
        }

        public async Task<Cliente> Get(string Identificador)
        {
            return await _context.Cliente.Where(x => x.Identificador.Equals(Identificador)).FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Cliente.AsNoTracking().OrderByDescending(x => x.Identificador).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> Pesquisar(string campo, string conteudo)
        {
            IQueryable<Cliente> foundClients = default;

            await Task.Run(() =>
            {
                foundClients = campo switch
                {
                    string field when field.Equals("Telefone") => from i in _context.Cliente.AsNoTracking()
                                                                        where EF.Functions.Like(i.Telefone, $"%{conteudo.Trim()}%")
                                                                        select i,

                    string field when field.Equals("Nome") => from i in _context.Cliente.AsNoTracking()
                                                                    where EF.Functions.Like(i.Nome, $"%{conteudo.Trim()}%")
                                                                    select i,

                    string field when field.Equals("Identificador") => from i in _context.Cliente.AsNoTracking()
                                                                             where EF.Functions.Like(i.Identificador, $"%{conteudo.Trim()}%")
                                                                             select i,

                    _ => null
                };
            });

            return foundClients.Where(x => x != null).AsEnumerable();
        }

        public async Task Remove(int Id)
        {
            var clienteToRemove = await Get(Id);

            if (clienteToRemove != null)
                _context.Cliente.Remove(clienteToRemove);
        }

        public async Task Remove(List<Cliente> clientes)
        {            
            var clientsToRemove = await _context.Cliente.Where(x => clientes.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            foreach (var cliente in clientsToRemove)
            {
                var smsPorCliente = await _context.SMS.Where(x => x.IdCliente.Equals(cliente.Id)).ToListAsync();
                var vendasPorCliente = await _context.Venda.Where(x => x.IdCliente.Equals(cliente.Id)).ToListAsync();

                foreach (var venda in vendasPorCliente)
                {
                    var produtosPorVenda = await _context.ProdutoVenda.Where(x => x.IdVenda.Equals(venda.Id)).ToListAsync();
                    _context.ProdutoVenda.RemoveRange(produtosPorVenda);
                }

                _context.Venda.RemoveRange(vendasPorCliente);
                _context.SMS.RemoveRange(smsPorCliente);
            }

            _context.Cliente.RemoveRange(clientsToRemove);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            var entry = await _context.Cliente.FindAsync(cliente.Id);

            if (entry != null)
            {
                _context.Entry(entry).CurrentValues.SetValues(cliente);
            }
        }

        public async Task<List<Venda>> VendasPorCliente(Cliente cliente)
        {
            List<Venda> response = new();

            var vendas = await _context.Venda.Include(x => x.Cliente).Where(x => x.IdCliente.Equals(cliente.Id)).ToListAsync();

            foreach (var venda in vendas)
            {
                response.Add(venda with
                {
                    Produtos = await _context.ProdutoVenda
                    .Include(x => x.Produto)
                    .Where(x => x.IdVenda
                    .Equals(venda.Id))
                    .ToListAsync()
                });
            }

            return response;
        }
    }
}
