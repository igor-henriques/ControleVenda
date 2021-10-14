using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILogRepository
    {
        Task<bool> Add(string description);
        Task<List<Log>> Get();
        Task Remove(List<Log> logs);
        Task<List<Log>> Search(string description);
    }
}
