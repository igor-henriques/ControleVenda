using Domain.Interfaces;
using Infra.Data;
using Infra.Helpers;
using Infra.Models;
using Infra.Models.Table;
using Infra.SMS.Request;
using Infra.SMS.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class SMSRepository : ISMSRepository
    {
        private RestClient restClient;
        private RestRequest request;

        private readonly Settings _settings;

        private readonly ApplicationDbContext _context;
        public SMSRepository(Settings settings, ApplicationDbContext context)
        {
            this._settings = settings;
            this.restClient = new RestClient();
            this.request = new RestRequest();
            this._context = context;
        }
        public ResponseSituacaoSMS CheckSituationSMS(RequestSituacaoSMS situacaoSMS)
        {
            try
            {
                situacaoSMS = situacaoSMS with { Key = _settings.Key };

                var jsonSms = JsonConvert.SerializeObject(situacaoSMS);

                this.restClient = new RestClient($"https://api.smsdev.com.br");

                this.request = new RestRequest("v1/dlr", Method.POST);

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
            return await _context.SMS.Include(x => x.Cliente).OrderByDescending(x => x.Id).ToListAsync();
        }

        public ResponseSaldoSMS GetSaldo()
        {
            try
            {
                this.restClient = new RestClient($"https://api.smsdev.com.br/v1/balance?key={_settings.Key}");

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
            sms = RequestSendSMS.TratarNumero(sms with { Key = this._settings.Key });

            var jsonSms = JsonConvert.SerializeObject(sms);

            this.restClient = new RestClient("https://api.smsdev.com.br");

            this.request = new RestRequest("v1/send", Method.POST);

            this.request.RequestFormat = DataFormat.Json;

            this.request.AddJsonBody(jsonSms);

            var response = restClient.Execute(request);

            return JsonConvert.DeserializeObject<ResponseSendSMS>(response.Content);
        }
        public List<KeyValuePair<Cliente, string>> BuildMessageSMS(List<Venda> sales)
        {
            List<KeyValuePair<Cliente, string>> response = new();

            var clientesDistintos = sales.Select(x => x.Cliente).Distinct().ToList();

            foreach (var cliente in clientesDistintos)
            {
                StringBuilder sb = new StringBuilder();

                var vendasPorCliente = sales.Where(x => x.Cliente.Id.Equals(cliente.Id)).ToList();

                var vendasPagas = vendasPorCliente.Where(x => x.VendaPaga).ToList();

                if (vendasPagas.Count > 0)
                {                    
                    vendasPorCliente = vendasPorCliente.Except(vendasPagas).ToList();

                    if (vendasPorCliente.Count <= 0)
                        return null;
                }

                var produtosSeparadosPorVenda = vendasPorCliente.Select(x => x.Produtos.ToList()).ToList();

                decimal totalDevedor = vendasPorCliente.Sum(x => x.TotalVenda);

                sb.AppendLine($"Olá, {cliente.Nome}! Como vai? {_settings.NomeNegocio} aqui!");
                sb.AppendLine($"Sua conta do mês de {DateTime.Today.ToString("MMMM").ToUpper()}: {totalDevedor.ToString("c")}");
                sb.AppendLine("Produtos consumidos:\n");

                Dictionary<Produto, int> produtoQuantidade = new Dictionary<Produto, int>();

                foreach (var produtosVenda in produtosSeparadosPorVenda)
                {
                    foreach (var produto in produtosVenda)
                    {
                        var keyProduto = produtoQuantidade.Where(x => x.Key.Id.Equals(produto.Produto.Id)).Select(x => x.Key).FirstOrDefault();

                        if (keyProduto is null)
                        {
                            produtoQuantidade.Add(produto.Produto, produto.Quantidade);
                        }
                        else
                        {
                            produtoQuantidade[produto.Produto] += produto.Quantidade;
                        }
                    }
                }

                foreach (var produto in produtoQuantidade)
                    sb.AppendLine($"Produto: {produto.Key.Nome} - Preço: {produto.Key.Preco.ToString("c")} - Quantidade: {produto.Value} - Total por produto: {(produto.Key.Preco * produto.Value).ToString("c")}\n");

                if (_settings.PIX.Length > 0) sb.AppendLine($"CHAVE P1X: {_settings.PIX}");
                if (_settings.PicPay.Length > 0) sb.AppendLine($"PICPAY: {_settings.PicPay}");

                response.Add(new KeyValuePair<Cliente, string>(cliente, sb.ToString()));
            }

            return response;
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

        public async Task<SMS> Get(long Id)
        {
            return await _context.SMS.FindAsync(Id);
        }
    }
}