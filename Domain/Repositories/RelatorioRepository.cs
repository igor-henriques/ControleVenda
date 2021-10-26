using Domain.Interfaces;
using Infra.Data;
using Infra.Models.Enum;
using Infra.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ApplicationDbContext _context;
        public RelatorioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Venda>> RelatorioPorDataCliente(DateTime dtInicio, DateTime dtFinal, List<Cliente> clientes, EVendaEstado estadoVenda)
        {
            var vendas = await _context.Venda
                        .Include(x => x.Cliente)
                        .Include(x => x.Produtos)
                        .ThenInclude(x => x.Produto)
                        .Where(venda => venda.Data >= dtInicio && venda.Data <= dtFinal.AddDays(1)
                        && clientes.Select(cliente => cliente.Identificador).Contains(venda.Cliente.Identificador))
                        .ToListAsync();

            var vendasFiltradas = estadoVenda switch
            {
                EVendaEstado.Pago => vendas.Where(x => x.VendaPaga).ToList(),
                EVendaEstado.Pendente => vendas.Where(x => !x.VendaPaga).ToList(),
                _ => vendas
            };

            return vendasFiltradas;
        }
    }
}
