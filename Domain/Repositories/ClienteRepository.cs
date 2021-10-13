﻿using Domain.Interfaces;
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

        public async Task<Cliente> Get(int Id)
        {
            return await _context.Cliente.FindAsync(Id);
        }

        public async Task<Cliente> Get(string Nome)
        {
            return await _context.Cliente.Where(x => x.Nome.Equals(Nome)).FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
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

            await Task.Run(() => _context.Cliente.RemoveRange(clientsToRemove));
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
    }
}