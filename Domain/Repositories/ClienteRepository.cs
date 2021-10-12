using Domain.Interfaces;
using Infra.Data;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Task<Cliente> Add(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> GetClientes()
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

        public Task Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
