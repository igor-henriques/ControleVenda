using Infra.Models.Table;
using Infra.SMS.Request;
using Infra.SMS.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISMSRepository
    {
        Task<ResponseSendSMS> SendSMS(RequestSendSMS sms);
        Task<ResponseSaldoSMS> GetSaldo();
        Task<ResponseSituacaoSMS> CheckSituationSMS(RequestSituacaoSMS situacaoSMS);
        List<KeyValuePair<Cliente, string>> BuildMessageSMS(List<Venda> sales);
        Task<List<SMS>> Get();
        Task<SMS> Get(long Id);
        Task<List<SMS>> GetPendingSMS();
        Task Add(SMS sms);
        Task Add(List<SMS> sms);
        Task Save();
        Task Update(SMS sms);
    }
}
