using Domain.Interfaces;
using Infra.Data;
using Infra.Helpers;
using Infra.Models.Table;
using Infra.SMS;
using Infra.SMS.Request;
using Infra.SMS.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class SMSRepository : ISMSRepository
    {
        private RestClient restClient;
        private RestRequest request;

        private readonly string key;

        private readonly ApplicationDbContext _context;
        public SMSRepository(ServiceKeySMS key, ApplicationDbContext context)
        {
            this.key = key.Key;
            this.restClient = new RestClient();
            this.request = new RestRequest();
            this._context = context;
        }
        public ResponseSituacaoSMS CheckSituationSMS(RequestSituacaoSMS situacaoSMS)
        {
            try
            {
                var jsonSms = JsonConvert.SerializeObject(situacaoSMS);

                this.restClient = new RestClient($"https://api.smsdev.com.br/v1/balance?key={key}");

                this.request = new RestRequest("", Method.POST);

                this.request.RequestFormat = DataFormat.Json;

                this.request.AddJsonBody(jsonSms);

                var response = restClient.Execute(request);

                return JsonConvert.DeserializeObject<ResponseSituacaoSMS>(response.Content);
            }
            catch (Exception e)
            {
                LogWriter.Write(e.ToString());
            }

            return default;
        }

        public async Task<List<SMS>> Get()
        {
            return await _context.SMS.ToListAsync();
        }

        public ResponseSaldoSMS GetSaldo()
        {
            try
            {
                this.restClient = new RestClient($"https://api.smsdev.com.br/v1/balance?key={key}");

                this.request = new RestRequest("", Method.GET);

                var response = restClient.Execute(request);

                return JsonConvert.DeserializeObject<ResponseSaldoSMS>(response.Content);
            }
            catch (Exception e)
            {
                LogWriter.Write(e.ToString());
            }

            return default;
        }

        public ResponseSendSMS SendSMS(RequestSendSMS sms)
        {
            sms = sms with { Key = this.key };

            var jsonSms = JsonConvert.SerializeObject(sms);

            this.restClient = new RestClient("https://api.smsdev.com.br");

            this.request = new RestRequest("v1/send", Method.POST);

            this.request.RequestFormat = DataFormat.Json;

            this.request.AddJsonBody(jsonSms);

            var response = restClient.Execute(request);

            return JsonConvert.DeserializeObject<ResponseSendSMS>(response.Content);
        }

        public async Task Add(SMS sms)
        {
            await Task.Run(() => _context.Add(sms));
        }

        public async Task Add(List<SMS> sms)
        {
            await Task.Run(() => _context.AddRange(sms));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(SMS sms)
        {
            var currentSMS = await _context.SMS.FindAsync(sms.Id);

            if (currentSMS != null)
            {
                await Task.Run(() => _context.Entry(currentSMS).CurrentValues.SetValues(sms));
            }
        }
    }
}
