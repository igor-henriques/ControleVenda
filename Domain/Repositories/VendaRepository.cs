using Domain.Interfaces;
using Infra.Data;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
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

        public Task<Venda> Add(Venda venda)
        {
            throw new NotImplementedException();
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
