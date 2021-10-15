using Infra.Models.Enum;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<Venda>> RelatorioPorDataCliente(DateTime dtInicio, DateTime dtFinal, List<Cliente> clientes, EVendaEstado estadoVenda);
    }
}
