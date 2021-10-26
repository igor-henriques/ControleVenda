using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models.Enum;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ConsultaVendaForm : Form
    {
        private readonly IClienteRepository _clienteContext;
        private readonly IVendaRepository _vendaContext;
        private readonly ILogRepository _log;
        public ConsultaVendaForm(IClienteRepository clienteContext, IVendaRepository vendaContext, ILogRepository logRepository)
        {
            InitializeComponent();

            this._clienteContext = clienteContext;
            this._vendaContext = vendaContext;
            this._log = logRepository;
        }

        private void dtiPicker_MouseDown(object sender, MouseEventArgs e)
        {
            rbData.Checked = true;
        }

        private void cbClientePesquisa_MouseDown(object sender, MouseEventArgs e)
        {
            rbCliente.Checked = true;
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!rbCliente.Checked && !rbData.Checked && !rbID.Checked && !rbEstadoVenda.Checked)
            {
                MessageBox.Show("Selecione algum método de pesquisa", "Consultar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (new ControlManager(this.Controls))
            {
                Dictionary<RadioButton, Func<Task>> searchOptions = new Dictionary<RadioButton, Func<Task>>
                {
                    { rbData,        async () => await FillGrid(await SearchByDate(dtiPicker.Value, dtfPicker.Value))                },
                    { rbCliente,     async () => await FillGrid(await SearchByCliente(cbClientePesquisa.SelectedItem as Cliente))    },
                    { rbID,          async () => await FillGrid(await SearchByID(int.Parse(tbPesquisa.Text)))                        },
                    { rbEstadoVenda, async () => await FillGrid(await SearchByState(cbEstadoVenda.SelectedIndex is 0 ? false : true))}
                };

                var searchResponse = searchOptions.Where(x => x.Key.Checked).Select(x => x.Value).FirstOrDefault();

                if (searchResponse != null)
                {
                    await searchResponse.Invoke();
                    FormatColumns();
                }
            }
        }

        private async Task<List<Venda>> SearchByDate(DateTime initialDate, DateTime finalDate)
        {
            var response = await _vendaContext.SearchByDate(initialDate, finalDate);
            return response;
        }
        private async Task<List<Venda>> SearchByCliente(Cliente cliente)
        {
            var response = await _vendaContext.SearchByCliente(cliente);
            return response;
        }
        private async Task<List<Venda>> SearchByState(bool pago)
        {
            var response = await _vendaContext.SearchByState(pago);
            return response;
        }
        private async Task<List<Venda>> SearchByID(int Id)
        {
            List<Venda> response = new();

            var record = await _vendaContext.Get(Id);
            if (record != null)
                response.Add(record);

            return response;
        }
        private async Task<List<Cliente>> GetClients()
        {
            return (await _clienteContext.GetClientes()).OrderBy(x => x.Nome).ToList();
        }
        private async Task FillGrid(List<Venda> vendas = null)
        {
            dgvVendas.Rows.Clear();

            vendas = vendas ?? await _vendaContext.GetVendas();

            if (vendas != null)
            {
                foreach (var venda in vendas)
                {
                    dgvVendas.Rows.Add(new object[]
                    {
                        venda.Id,
                        $"({venda.Cliente.Identificador}) {venda.Cliente.Nome}",
                        venda.Data.ToShortDateString(),
                        venda.TotalVenda.ToString("c"),
                        venda.Acrescimo.ToString("c"),
                        venda.Desconto.ToString("c"),
                        venda.ModoVenda.ToString(),
                        venda.VendaPaga,
                        CreateGridButton()
                    });
                }

                FormatColumns();
            }
        }
        private DataGridViewButtonCell CreateGridButton()
        {
            DataGridViewButtonCell dgvButton = new DataGridViewButtonCell();

            dgvButton.Value = "Verificar";
            dgvButton.UseColumnTextForButtonValue = true;
            dgvButton.FlatStyle = FlatStyle.Flat;

            return dgvButton;
        }
        private async void dgvCautelas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (dgvVendas.RowCount > 0 && e.RowIndex >= 0)
                {
                    int idVenda = (int)senderGrid.SelectedRows[0].Cells["Id"].Value;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        ProdutoVendaForm produtosPorVenda = new ProdutoVendaForm(await _vendaContext.GetProdutosPorVenda(idVenda));
                        produtosPorVenda.ShowDialog();
                    }
                    else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        if (MessageBox.Show("Deseja alterar o estado de pagamento dessa venda?", "Alterar Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            using (new ControlManager(this.Controls))
                            {
                                await _vendaContext.SwitchSaleState(idVenda, !(bool)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                                await _vendaContext.Save();

                                await FillGrid();
                            }
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task LoadForm()
        {
            using (new ControlManager(this.Controls))
            {
                cbClientePesquisa.DataSource = await GetClients();
                cbClientePesquisa.DisplayMember = "Nome";
                cbEstadoVenda.SelectedIndex = 0;

                await FillGrid();
            }
        }
        private void FormatColumns()
        {
            for (int i = 0; i < dgvVendas.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvVendas.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvVendas.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dgvVendas.ClearSelection();
        }

        private async void ConsultaVendaForm_Load(object sender, EventArgs e)
        {
            await LoadForm();
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

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvVendas.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma linha para excluir", "Excluir Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir {dgvVendas.SelectedRows.Count} registro(s) de Venda?", "Excluir Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                return;

            using (new ControlManager(this.Controls))
            {
                var vendasSelecionadas = await GetSelectedVendas();

                if (vendasSelecionadas.Count > 0)
                {
                    await _vendaContext.Remove(vendasSelecionadas);
                    await _vendaContext.Save();

                    foreach (var venda in vendasSelecionadas)
                    {
                        await _log.Add($"Venda Nº {venda.Id} em nome do cliente {venda.Cliente.Nome} no valor de {venda.TotalVenda.ToString("c")} foi REMOVIDA do sistema");
                    }

                    await FillGrid();

                }
            }
        }
        private async Task<List<Venda>> GetSelectedVendas()
        {
            List<int> idVendas = new();

            foreach (DataGridViewRow row in dgvVendas.SelectedRows)
            {
                int idVenda = int.Parse(row.Cells["Id"].Value.ToString());

                idVendas.Add(idVenda);
            }

            return await _vendaContext.Get(idVendas);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            rbCliente.Checked = false;
            rbData.Checked = false;
            rbID.Checked = false;
            rbEstadoVenda.Checked = false;

            tbPesquisa.Clear();

            cbClientePesquisa.SelectedItem = null;

            using (new ControlManager(this.Controls))
                await FillGrid();
        }

        private void tbPesquisa_MouseDown(object sender, MouseEventArgs e)
        {
            rbID.Checked = true;
        }

        private void tbPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnPesquisar.PerformClick();
        }

        private void tbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) || !int.TryParse(tbPesquisa.Text.Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }

        private void cbEstadoVenda_MouseDown(object sender, MouseEventArgs e)
        {
            rbEstadoVenda.Checked = true;
        }

        private async void btnQuitarPendencia_Click(object sender, EventArgs e)
        {
            try
            {
                using (new ControlManager(this.Controls))
                {
                    if (dgvVendas.SelectedRows.Count <= 0)
                    {
                        MessageBox.Show("Selecione ao menos uma venda para quitar", "Quitar Pendência", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show($"Deseja realmente quitar {dgvVendas.SelectedRows.Count} vendas selecionadas?", "Quitar Pendência", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))
                        return;

                    var vendasSelecionadas = await GetSelectedVendas();

                    var vendasQuitadas = await _vendaContext.Pay(vendasSelecionadas);

                    await _vendaContext.Save();

                    MessageBox.Show($"{vendasQuitadas} venda(s) quitada(s)", "Quitar Pendência", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (var venda in vendasQuitadas)
                    {
                        await _log.Add($"Venda Nº {venda.Id} no nome do cliente {venda.Cliente.Nome}({venda.Cliente.Identificador}) QUITADA. Valor: {venda.TotalVenda.ToString("c")}");
                    }

                    await FillGrid();
                }                
            }
            catch (Exception ex) 
            {
                LogWriter.Write(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }
    }
}