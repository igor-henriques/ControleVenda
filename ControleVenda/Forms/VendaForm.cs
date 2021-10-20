using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Infra.Models.Temp;
using Infra.Models.Enum;

namespace ControleVenda.Forms
{
    public partial class VendaForm : Form
    {
        private readonly IVendaRepository _vendaContext;
        private readonly IProdutoRepository _produtoContext;
        private readonly IClienteRepository _clienteContext;
        private readonly ILogRepository _log;

        public VendaForm(IVendaRepository vendaRepository, IProdutoRepository produtoRepository, IClienteRepository clienteRepository, ILogRepository logRepository)
        {
            InitializeComponent();

            this._vendaContext = vendaRepository;
            this._produtoContext = produtoRepository;
            this._clienteContext = clienteRepository;
            this._log = logRepository;
        }

        private async void VendaForm_Load(object sender, EventArgs e)
        {
            await LoadForm();
        }
        private async Task LoadForm()
        {
            using (new ControlManager(this.Controls))
            {
                var clientes = await GetClientes();

                cbClientes.DisplayMember = "Nome";
                cbClientes.DataSource = clientes;
                cbClientes.AutoCompleteCustomSource = GetClientesAutoComplete(clientes);

                cbModoVenda.SelectedIndex = 0;

                await FillGrid();
            }

            this.dgvProdutos.CellValueChanged += dgvProdutos_CellValueChanged;
            this.dgvProdutos.EditingControlShowing += dgvProdutos_EditingControlShowing;
        }
        private async Task FillGrid(List<ProdutoViewModel> produtosComQuantia = null)
        {
            dgvProdutos.Rows.Clear();

            if (produtosComQuantia is null)
            {
                var produtos = await GetProdutos();

                produtos.ForEach(p => dgvProdutos.Rows.Add(new object[]
                {
                    p.Id,
                    p.Nome,
                    0,
                    p.Preco.ToString("c")
                }));
            }
            else
            {
                produtosComQuantia.ForEach(p => dgvProdutos.Rows.Add(new object[]
                {
                    p.Produto.Id,
                    p.Produto.Nome,
                    p.Quantidade,
                    p.Produto.Preco.ToString("c"),
                }));
            }

            FormatColumns();
        }
        private AutoCompleteStringCollection GetClientesAutoComplete(List<Cliente> clientes)
        {
            AutoCompleteStringCollection autoComplete = new();

            foreach (var cliente in clientes)
            {
                autoComplete.Add(cliente.Nome);
            }

            return autoComplete;
        }
        private async Task<List<Produto>> GetProdutos()
        {
            return await _produtoContext.GetProdutos();
        }
        private async Task<List<Cliente>> GetClientes()
        {
            return await _clienteContext.GetClientes();
        }

        private void FormatColumns()
        {
            for (int i = 0; i < dgvProdutos.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvProdutos.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvProdutos.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dgvProdutos.ClearSelection();
        }

        private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(2))
            {
                CalcularTotalVenda();
            }
        }

        private void CalcularTotalVenda()
        {
            decimal total = 0M;

            foreach (var produto in GetProdutosOnVenda())
            {
                total += produto.Quantidade * produto.Produto.Preco;
            }

            total -= decimal.Parse(tbDesconto.Text.Length > 0 ? tbDesconto.Text.Replace("R$", default).Trim() : "0");
            total += decimal.Parse(tbTaxa.Text.Length > 0 ? tbTaxa.Text.Replace("R$", default).Trim() : "0");

            lblTotal.Text = total.ToString("c");
        }
        private List<ProdutoViewModel> GetProdutosOnVenda()
        {
            List<ProdutoViewModel> produtosOnVenda = new();

            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                var rowQuantia = row.Cells["Quantia"].Value?.ToString();

                if (!string.IsNullOrEmpty(rowQuantia) && int.Parse(rowQuantia) > 0)
                {
                    var rowPrice = decimal.Parse(row.Cells["Preco"].Value.ToString().Replace("R$", default).Trim());
                    var rowId = int.Parse(row.Cells["Id"].Value.ToString());
                    var rowName = row.Cells["Nome"].Value.ToString();

                    produtosOnVenda.Add(new()
                    {
                        Produto = new()
                        {
                            Id = rowId,
                            Nome = rowName,
                            Preco = rowPrice,
                        },

                        Quantidade = int.Parse(rowQuantia)
                    });
                }
            }

            return produtosOnVenda;
        }
        private List<ProdutoViewModel> GetProdutosOnGrid()
        {
            List<ProdutoViewModel> produtosOnVenda = new();

            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                var rowQuantia = row.Cells["Quantia"].Value?.ToString();
                var rowPrice = decimal.Parse(row.Cells["Preco"].Value.ToString().Replace("R$", default).Trim());
                var rowId = int.Parse(row.Cells["Id"].Value.ToString());
                var rowName = row.Cells["Nome"].Value.ToString();

                produtosOnVenda.Add(new()
                {
                    Produto = new()
                    {
                        Id = rowId,
                        Nome = rowName,
                        Preco = rowPrice,
                    },

                    Quantidade = int.Parse(rowQuantia)
                });
            }

            return produtosOnVenda;
        }
        private void tbDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) && ch != ',' || !decimal.TryParse(tbDesconto.Text.Replace("R$", default).Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }
        private void tbTaxa_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) && ch != ',' || !decimal.TryParse(tbTaxa.Text.Replace("R$", default).Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }
        private void tbTaxa_Leave(object sender, EventArgs e)
        {
            if (tbTaxa.Text.Trim() != string.Empty && decimal.TryParse(tbTaxa.Text.Replace("R$ ", "").Trim(), out decimal result))
                tbTaxa.Text = result.ToString("c");
            else
                tbTaxa.Text = 0.ToString("c");

            CalcularTotalVenda();
        }
        private void tbDesconto_Leave(object sender, EventArgs e)
        {
            if (tbDesconto.Text.Trim() != string.Empty && decimal.TryParse(tbDesconto.Text.Replace("R$ ", "").Trim(), out decimal result))
                tbDesconto.Text = result.ToString("c");
            else
                tbDesconto.Text = 0.ToString("c");

            CalcularTotalVenda();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedItem is null)
            {
                MessageBox.Show("Cliente selecionado não existe", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientes.Focus();
                return;
            }

            if (cbModoVenda.SelectedItem is null | cbModoVenda.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um modo de venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbModoVenda.Focus();
                return;
            }

            if (GetProdutosOnVenda().Count <= 0)
            {
                MessageBox.Show("Não foi selecionado nenhum produto para venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbVendaPaga.Checked && MessageBox.Show($"A venda está sendo finalizada já como status de PAGO. Tem certeza que já está paga?", "Finalizar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))
            {
                return;
            }                

            if (Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString()) is not EModoVenda.Dia)
            {
                var entrada = Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString());

                var dataOrigem = entrada switch
                {
                    EModoVenda.Semana =>   DateTime.Now.AddDays(-7),
                    EModoVenda.Mes =>      DateTime.Now.AddMonths(-1),
                    EModoVenda.Semestre => DateTime.Now.AddMonths(-6),
                    EModoVenda.Ano =>      DateTime.Now.AddYears(-1),
                    _ => new DateTime()
                };

                if (dataOrigem != new DateTime())
                {
                    var result = await _vendaContext.SearchByDateAndMode(dataOrigem, DateTime.Today, entrada);

                    if (result != null)
                    {
                        if (MessageBox.Show($"Foi encontrado registro de venda de {entrada.ToString().ToUpper()} no mesmo período. Deseja realmente lançar novamente?", "Finalizar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))                       
                            return;                        
                    }
                }                
            }

            CalcularTotalVenda();

            if (decimal.TryParse(lblTotal.Text.Replace("R$", default).Trim(), out decimal totalVenda) && totalVenda > 0)
            {
                using (new ControlManager(this.Controls))
                {
                    Venda venda = new()
                    {
                        Data = dtPicker.Value,
                        Acrescimo = decimal.Parse(tbTaxa.Text.Replace("R$", default).Trim()),
                        Desconto = decimal.Parse(tbDesconto.Text.Replace("R$", default).Trim()),
                        ModoVenda = Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString()),
                        TotalVenda = totalVenda,
                        IdCliente = (cbClientes.SelectedItem as Cliente).Id,
                        VendaPaga = cbVendaPaga.Checked
                    };

                    var vendaProcessada = await _vendaContext.Add(venda);

                    await _vendaContext.Save();

                    await _vendaContext.AddProducts(new VendaViewModel()
                    {
                        Produtos = GetProdutosOnVenda(),
                        Venda = vendaProcessada
                    });

                    await _vendaContext.Save();

                    await _log.Add($"Venda Nº {venda.Id} finalizada no sistema em nome do cliente {(cbClientes.SelectedItem as Cliente).Nome} no valor total de {venda.TotalVenda.ToString("c")}");

                    MessageBox.Show("Venda finalizada com sucesso. Abra a tela de Consultar Venda para verificar o registro.", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Clear();

                await LoadForm();
            }
            else
            {
                MessageBox.Show("O valor da venda não pode ser 0", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void Clear()
        {
            tbDesconto.Text = 0.ToString("c");
            tbTaxa.Text = 0.ToString("c");
            lblTotal.Text = 0.ToString("c");
            cbVendaPaga.Checked = false;            
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void cbClientes_Leave(object sender, EventArgs e)
        {
            if (cbClientes.SelectedItem is null)
            {
                MessageBox.Show("Cliente selecionado não existe", "Selecionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientes.Focus();
            }
        }

        private void cbModoVenda_Leave(object sender, EventArgs e)
        {
            if (cbModoVenda.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um modo de venda", "Selecionar Modo de Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbModoVenda.Focus();
            }
        }

        private void dgvProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) | !int.TryParse(dgvProdutos
                .SelectedRows[0]
                .Cells["Quantia"]
                .Value
                .ToString()
                .Replace("R$", default)
                .Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }

        private void dgvProdutos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(PriceColumn_KeyPress);
            if (dgvProdutos.CurrentCell.ColumnIndex == 2) 
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(PriceColumn_KeyPress);
                }
            }
        }

        private void PriceColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvProdutos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dgvProdutos.Rows[e.RowIndex].Cells["Quantia"].Value;

                if ((bool)(row is null | row?.ToString().Equals("0")))
                {
                    dgvProdutos.Rows[e.RowIndex].Cells["Quantia"].Value = "0";
                    dgvProdutos.UpdateCellValue(e.ColumnIndex, e.RowIndex);
                }
            }
        }

        private void dgvProdutos_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow currentRow in dgvProdutos.Rows)
            {
                var rowValue = currentRow.Cells["Quantia"].Value;

                if ((bool)(rowValue is null | rowValue?.ToString().Equals("0")))
                {
                    currentRow.Cells["Quantia"].Value = "0";
                }
            }
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {
            if (dtPicker.Value > DateTime.Today)
            {
                MessageBox.Show("Não é possível realizar venda com data maior que a atual. Faça o controle através do Modo de Venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtPicker.Value = DateTime.Today;
                return;
            }                
        }
    }
}
