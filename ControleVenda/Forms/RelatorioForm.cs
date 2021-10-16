using ClosedXML.Excel;
using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models;
using Infra.Models.Enum;
using Infra.Models.Table;
using Infra.SMS;
using Infra.SMS.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class RelatorioForm : Form
    {
        private readonly IClienteRepository _clienteContext;
        private readonly IRelatorioRepository _relatorioContext;
        private readonly ISMSRepository _smsContext;
        private readonly Settings _definitions;
        public RelatorioForm(IClienteRepository clienteRepository, IRelatorioRepository relatorioRepository, ISMSRepository smsContext, Settings defs)
        {
            InitializeComponent();

            this._clienteContext = clienteRepository;
            this._relatorioContext = relatorioRepository;
            this._smsContext = smsContext;
            this._definitions = defs;
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtfPicker_ValueChanged(object sender, EventArgs e)
        {
            if (dtfPicker.Value < dtiPicker.Value)
            {
                MessageBox.Show("A data final não pode ser menor que a data inicial.", "Consultar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtfPicker.Value = dtiPicker.Value.AddDays(1);
            }
        }

        private void dtiPicker_ValueChanged(object sender, EventArgs e)
        {
            if (dtfPicker.Value < dtiPicker.Value)
            {
                MessageBox.Show("A data inicial não pode ser maior que a data final.", "Consultar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtiPicker.Value = dtfPicker.Value.AddDays(-1);
            }
        }

        private async void RelatorioForm_Load(object sender, EventArgs e)
        {
            await FillGrid();
        }
        private async Task FillGrid(List<Cliente> clientes = null)
        {
            using (new ControlManager(this.Controls))
            {
                clientes = clientes ?? await _clienteContext.GetClientes();

                if (clientes != null)
                {
                    dgvClientes.Rows.Clear();

                    foreach (var cliente in clientes)
                    {
                        dgvClientes.Rows.Add(new object[]
                        {
                        false,
                        cliente.Identificador,
                        cliente.Nome,
                        cliente.Telefone
                        });
                    }
                }
            }
        }

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.Cells["ClienteSelecionado"].Value = cbCheckAll.Checked;
            }
        }

        private async void btnEmitir_Click(object sender, EventArgs e)
        {
            if (cbAgrupamento.SelectedItem is null)
            {
                MessageBox.Show("Selecione algum método de agrupamento", "Emitir Relatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEstadoVenda.SelectedItem is null)
            {
                MessageBox.Show("Selecione algum estado de venda", "Emitir Relatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientesSelecionados = GetSelectedClientsOnGrid();

            if (clientesSelecionados.Count <= 0)
            {
                MessageBox.Show("Selecione algum cliente para continuar", "Emitir Relatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (new ControlManager(this.Controls))
            {
                var sales = await _relatorioContext.RelatorioPorDataCliente(dtiPicker.Value, dtfPicker.Value, clientesSelecionados, Enum.Parse<EVendaEstado>(cbEstadoVenda.SelectedItem.ToString()));

                var clientesDistintos = sales.Select(x => x.Cliente).Distinct().ToList();

                if (sales.Count <= 0)
                {
                    MessageBox.Show("Não foi encontrado registro de venda com os filtros", "Emitir Relatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbAgrupamento.SelectedItem.ToString().Equals("Data"))
                {
                    var vendasAgrupadasPorData = from venda in sales
                                                 group venda by venda.Data into vendasAgrupadas
                                                 orderby vendasAgrupadas.Key
                                                 select vendasAgrupadas;

                    BuildTXT(vendasAgrupadasPorData);
                }
                else
                {
                    var vendasAgrupadasPorCliente = from venda in sales
                                                    group venda by venda.Cliente into vendasAgrupadas
                                                    orderby vendasAgrupadas.Key.Identificador
                                                    select vendasAgrupadas;

                    BuildTXT(vendasAgrupadasPorCliente);
                }

                if (MessageBox.Show($"O relatório foi salvo na pasta Relatórios. Deseja enviar SMS de cobrança a todos os {clientesDistintos.Count} clientes?", "Exportado", MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                {
                    await SendSMS(clientesDistintos, sales);
                }
            }
        }
        private async Task SendSMS(List<Cliente> clientesDistintos, List<Venda> sales)
        {
            foreach (var cliente in clientesDistintos)
            {
                StringBuilder sb = new StringBuilder();

                var vendasPorCliente = sales.Where(x => x.Cliente.Id.Equals(cliente.Id)).ToList();

                var vendasPagas = vendasPorCliente.Where(x => x.VendaPaga).ToList();
                if (vendasPagas.Count > 0)
                {
                    MessageBox.Show($"Há {vendasPagas.Count} compra(s) já paga(s) pelo cliente {cliente.Nome}. Filtrando envio de cobrança somente das compras não-pagas, caso ainda houver.", "Envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vendasPorCliente = vendasPorCliente.Except(vendasPagas).ToList();

                    if (vendasPorCliente.Count <= 0)
                        return;
                }

                var produtosSeparadosPorVenda = vendasPorCliente.Select(x => x.Produtos.ToList()).ToList();
                decimal totalDevedor = vendasPorCliente.Sum(x => x.TotalVenda);

                sb.AppendLine($"Olá, {cliente.Nome}! Como vai? {_definitions.NomeNegocio} aqui!");
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

                if (_definitions.PIX.Length > 0) sb.AppendLine($"PIX:    {_definitions.PIX}");
                if (_definitions.PicPay.Length > 0) sb.AppendLine($"PICPAY: {_definitions.PicPay}");

                var responseSMS = _smsContext.SendSMS(new RequestSendSMS
                {
                    Number = cliente.Telefone,
                    Msg = sb.ToString()
                });

                await _smsContext.Add(new SMS
                {
                    Id = responseSMS.Id,
                    Situacao = responseSMS.Situacao,
                    TelefoneDestino = cliente.Telefone,
                    Mensagem = sb.ToString(),
                    Codigo = responseSMS.Codigo,
                    Descricao = responseSMS.Descricao
                });
            }

            await _smsContext.Save();

            MessageBox.Show("Todas as SMS foram enviadas. Cheque a situação das mesmas no gerenciamento de SMS.", "Envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BuildTXT(IOrderedEnumerable<IGrouping<Cliente, Venda>> vendasAgrupadasPorCliente)
        {
            var totalFinal = 0M;

            StringBuilder sb = new StringBuilder();

            foreach (var vendasPorCliente in vendasAgrupadasPorCliente)
            {
                decimal totalPorCliente = 0M;

                sb.AppendLine($"{vendasPorCliente.Key.Nome} ({vendasPorCliente.Key.Identificador})");

                foreach (var venda in vendasPorCliente)
                {
                    sb.AppendLine($"\nVenda {venda.ModoVenda} Nº {venda.Id} ; Data: {venda.Data.ToShortDateString()} ; Total: {venda.TotalVenda.ToString("c")} ; Acréscimo: {venda.Acrescimo.ToString("c")} ; Desconto: {venda.Desconto.ToString("c")}");
                    sb.AppendLine("Produtos: ");

                    foreach (var produto in venda.Produtos)
                    {
                        sb.AppendLine($"Nome: {produto.Produto.Nome} ; Preço: {produto.Produto.Preco.ToString("c")} ; Quantidade: {produto.Quantidade} ; Subtotal do Produto: {(produto.Quantidade * produto.Produto.Preco).ToString("c")}");
                    }

                    totalPorCliente += venda.TotalVenda;                    
                }

                sb.AppendLine("\n\n\n");

                totalFinal += vendasPorCliente.Sum(x => x.TotalVenda);

                sb.AppendLine($"Total do Cliente: {totalPorCliente.ToString("c")}\n\n");
            }

            sb.AppendLine($"Total final: {totalFinal.ToString("c")}");

            File.WriteAllTextAsync($"./Relatórios/{DateTime.Today.ToLongDateString()} - REL N{Directory.GetFiles("./Relatórios/").Count() + 1} - Vendas por Cliente.txt", sb.ToString());
        }
        private void BuildTXT(IOrderedEnumerable<IGrouping<DateTime, Venda>> vendasAgrupadasPorData)
        {
            var totalFinal = 0M;

            StringBuilder sb = new StringBuilder();

            foreach (var vendasPorData in vendasAgrupadasPorData)
            {
                decimal totalPorData = 0M;

                sb.AppendLine($"Dia: {vendasPorData.Key.ToShortDateString()}");

                foreach (var venda in vendasPorData)
                {
                    sb.AppendLine($"\nVenda Nº {venda.Id} ; Cliente: {venda.Cliente.Nome} ({venda.Cliente.Identificador}) ; Total: {venda.TotalVenda.ToString("c")} ; Acréscimo: {venda.Acrescimo.ToString("c")} ; Desconto: {venda.Desconto.ToString("c")}");
                    sb.AppendLine("Produtos: ");

                    foreach (var produto in venda.Produtos)
                    {
                        sb.AppendLine($"Nome: {produto.Produto.Nome} ; Preço: {produto.Produto.Preco.ToString("c")} ; Quantidade: {produto.Quantidade}");
                    }

                    totalPorData += venda.TotalVenda;
                }

                sb.AppendLine("\n\n\n");

                totalFinal += vendasPorData.Sum(x => x.TotalVenda);

                sb.AppendLine($"Total da Período: {totalPorData.ToString("c")}\n\n");
            }

            sb.AppendLine($"Total final: {totalFinal.ToString("c")}");

            File.WriteAllTextAsync($"./Relatórios/{DateTime.Today.ToLongDateString()} - REL N{Directory.GetFiles("./Relatórios/").Count() + 1} - Vendas por Data.txt", sb.ToString());
        }
        private List<Cliente> GetSelectedClientsOnGrid()
        {
            List<Cliente> clientes = new();

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if ((bool)row.Cells["ClienteSelecionado"].Value)
                {
                    clientes.Add(new()
                    {
                        Identificador = row.Cells["Identificador"].Value.ToString(),
                        Nome = row.Cells["Nome"].Value.ToString()
                    });
                }
            }

            return clientes;
        }
    }
}