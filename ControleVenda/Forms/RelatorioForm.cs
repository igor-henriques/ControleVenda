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
        private readonly Settings _settings;
        public RelatorioForm(IClienteRepository clienteRepository, IRelatorioRepository relatorioRepository, ISMSRepository smsContext, Settings defs)
        {
            InitializeComponent();

            this._clienteContext = clienteRepository;
            this._relatorioContext = relatorioRepository;
            this._smsContext = smsContext;
            this._settings = defs;
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
                var estadoVenda = Enum.Parse<EVendaEstado>(cbEstadoVenda.SelectedItem.ToString());

                var sales = await _relatorioContext.RelatorioPorDataCliente(dtiPicker.Value, dtfPicker.Value, clientesSelecionados, estadoVenda);

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

                MessageBox.Show($"O relatório foi salvo na pasta Relatórios", "Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!estadoVenda.Equals(EVendaEstado.Pago) && MessageBox.Show($"Deseja enviar SMS de cobrança? Há {clientesDistintos.Count} cliente(s) com pendências.", "Envio de SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                {
                    if (_smsContext.GetSaldo().SaldoSMS < clientesDistintos.Count)
                    {
                        MessageBox.Show("Não há saldo de SMS para realizar a operação. Considere realizar uma recarga no Gerenciamento de SMS.", "Envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var mensagensPorCliente = _smsContext.BuildMessageSMS(sales.Where(x => !x.VendaPaga).ToList());

                    foreach (var mensagem in mensagensPorCliente)
                    {
                        var request = _smsContext.SendSMS(new RequestSendSMS
                        {
                            Type = 9,
                            Msg = mensagem.Value,
                            Number = mensagem.Key.Telefone
                        });

                        var situacao = _smsContext.CheckSituationSMS(new RequestSituacaoSMS()
                        {
                            Id = request.Id.ToString()
                        });

                        await _smsContext.Add(new SMS
                        {
                            Descricao = situacao.Descricao,
                            Mensagem = mensagem.Value,
                            Situacao = situacao.Situacao,
                            Codigo = situacao.Codigo,
                            IdCliente = mensagem.Key.Id
                        });
                    }

                    await _smsContext.Save();
                }
            }
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

                sb.AppendLine("\n\n");

                totalFinal += vendasPorCliente.Sum(x => x.TotalVenda);

                sb.AppendLine($"Total do Cliente: {totalPorCliente.ToString("c")}\n\n\n");
            }

            sb.AppendLine($"Total final: {totalFinal.ToString("c")}");

            File.WriteAllTextAsync($"./Relatórios/{DateTime.Today.ToLongDateString()} - REL N{Directory.GetFiles("./Relatórios/").Count() + 1} - Vendas por Cliente - {cbEstadoVenda.SelectedItem.ToString()}.txt", sb.ToString());
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

                sb.AppendLine("\n\n");

                totalFinal += vendasPorData.Sum(x => x.TotalVenda);

                sb.AppendLine($"Total da Período: {totalPorData.ToString("c")}\n\n\n");
            }

            sb.AppendLine($"Total final: {totalFinal.ToString("c")}");

            File.WriteAllTextAsync($"./Relatórios/{DateTime.Today.ToLongDateString()} - REL N{Directory.GetFiles("./Relatórios/").Count() + 1} - Vendas por Data - {cbEstadoVenda.SelectedItem.ToString()}.txt", sb.ToString());
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