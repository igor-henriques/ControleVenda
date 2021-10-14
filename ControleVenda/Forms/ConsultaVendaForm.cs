using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models.Enum;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ConsultaVendaForm : Form
    {
        private readonly IClienteRepository _clienteContext;
        private readonly IVendaRepository _vendaContext;
        public ConsultaVendaForm(IClienteRepository clienteContext, IVendaRepository vendaContext)
        {
            InitializeComponent();

            this._clienteContext = clienteContext;
            this._vendaContext = vendaContext;
        }

        private void dtiPicker_MouseDown(object sender, MouseEventArgs e)
        {
            rbData.Checked = true;
        }

        private void cbClientePesquisa_MouseDown(object sender, MouseEventArgs e)
        {
            rbCliente.Checked = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!rbCliente.Checked | !rbData.Checked)
            {
                MessageBox.Show("Selecione algum método de pesquisa", "Consultar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private async Task<List<Cliente>> GetClients()
        {
            return await _clienteContext.GetClientes();
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

                if (dgvVendas.RowCount > 0)
                {
                    int idVenda = (int)senderGrid.SelectedRows[0].Cells["Id"].Value;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        ProdutoVendaForm produtosPorVenda = new ProdutoVendaForm((await _vendaContext.GetProdutosPorVenda(idVenda)));
                        produtosPorVenda.ShowDialog();
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
    }
}
