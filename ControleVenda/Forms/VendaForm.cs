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
using Infra.Helpers;

namespace ControleVenda.Forms
{
    public partial class VendaForm : Form
    {
        private readonly Size originalFormSize = new Size(800, 631);
        private readonly Size openedFormSize = new Size(800, 710);
        private readonly List<Tuple<Control, Point>> originalPositions = new();
        private readonly List<Tuple<Control, Point>> openedPositions = new();
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

            originalPositions.Add(new Tuple<Control, Point>(lblModoVendaDescricao, new Point(10, 107)));
            originalPositions.Add(new Tuple<Control, Point>(cbModoVenda, new Point(139, 104)));
            originalPositions.Add(new Tuple<Control, Point>(lblDataVendaDescricao, new Point(10, 139)));
            originalPositions.Add(new Tuple<Control, Point>(dtPicker, new Point(139, 135)));
            originalPositions.Add(new Tuple<Control, Point>(cbVendaPaga, new Point(644, 138)));

            openedPositions.Add(new Tuple<Control, Point>(lblModoVendaDescricao, new Point(10, 184)));
            openedPositions.Add(new Tuple<Control, Point>(cbModoVenda, new Point(139, 181)));
            openedPositions.Add(new Tuple<Control, Point>(lblDataVendaDescricao, new Point(10, 216)));
            openedPositions.Add(new Tuple<Control, Point>(dtPicker, new Point(139, 212)));
            openedPositions.Add(new Tuple<Control, Point>(cbVendaPaga, new Point(644, 215)));
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

                clientes = clientes.OrderBy(x => int.Parse(x.Identificador)).ToList();

                this.cbClientesID.DataSource = clientes;
                this.cbClientesID.DisplayMember = "Identificador";
                this.cbClientesID.AutoCompleteCustomSource = GetClientesAutoComplete(clientes);

                clientes = clientes.OrderBy(x => x.Nome).ToList();

                this.cbClientesNome.DataSource = clientes;
                this.cbClientesNome.DisplayMember = "Nome";
                this.cbClientesNome.AutoCompleteCustomSource = GetClientesAutoComplete(clientes);

                this.cbClientesNome.SelectedItem = ((List<Cliente>)cbClientesID.DataSource).Where(x => x.Identificador.Equals(cbClientesID.Text)).FirstOrDefault();

                this.cbClientesNome.SelectedIndexChanged += new System.EventHandler(this.cbClientesNome_SelectedIndexChanged);
                this.cbClientesNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClientesNome_KeyDown);

                this.cbClientesID.SelectedIndexChanged += new System.EventHandler(this.cbClientesID_SelectedIndexChanged);
                this.cbClientesID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClientesID_KeyDown);

                this.cbClientesID.Leave += new System.EventHandler(this.cbClientesID_Leave);
                this.cbClientesNome.Leave += new System.EventHandler(this.cbClientesNome_Leave);

                this.cbModoVenda.SelectedIndex = 1;

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

            foreach (var produto in GetProdutosOnVenda(false))
            {
                total += produto.Quantidade * produto.Produto.Preco;
            }

            total -= decimal.Parse(tbDesconto.Text.Length > 0 ? tbDesconto.Text.Replace("R$", default).Trim() : "0");
            total += decimal.Parse(tbTaxa.Text.Length > 0 ? tbTaxa.Text.Replace("R$", default).Trim() : "0");

            lblTotal.Text = total.ToString("c");
        }
        private List<ProdutoVenda> GetProdutosOnVenda(bool querying)
        {
            List<ProdutoVenda> produtosOnVenda = new();

            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                var rowQuantia = row.Cells["Quantia"].Value?.ToString();

                if (!string.IsNullOrEmpty(rowQuantia) & int.TryParse(rowQuantia, out int quantia) & quantia > 0)
                {
                    var rowPrice = decimal.Parse(row.Cells["Preco"].Value.ToString().Replace("R$", default).Trim());
                    var rowId = int.Parse(row.Cells["Id"].Value.ToString());
                    var rowName = row.Cells["Nome"].Value.ToString();

                    ProdutoVenda produtoVenda = new()
                    {
                        Quantidade = quantia,
                        IdProduto = rowId
                    };

                    produtosOnVenda.Add(querying ? produtoVenda : produtoVenda with
                    {
                        Produto = new()
                        {
                            Id = rowId,
                            Nome = rowName,
                            Preco = rowPrice
                        },
                    });
                }
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
            Task venda = cbVendaMultipla.Checked ? VendaClienteMultiplo() : VendaClienteUnico();

            await venda;
        }

        public async Task VendaClienteUnico()
        {
            if (cbClientesID.SelectedItem is null | cbClientesNome.SelectedItem is null)
            {
                MessageBox.Show("Cliente selecionado não existe", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientesID.Focus();
                return;
            }

            if (cbModoVenda.SelectedItem is null | cbModoVenda.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um modo de venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbModoVenda.Focus();
                return;
            }

            if (GetProdutosOnVenda(false).Count <= 0)
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
                    EModoVenda.Semana => DateTime.Now.AddDays(-7),
                    EModoVenda.Mes => DateTime.Now.AddMonths(-1),
                    EModoVenda.Semestre => DateTime.Now.AddMonths(-6),
                    EModoVenda.Ano => DateTime.Now.AddYears(-1),
                    _ => new DateTime()
                };

                if (dataOrigem != new DateTime())
                {
                    var result = await _vendaContext.SearchExistingSale(dataOrigem, DateTime.Today, entrada, new List<int>() { (cbClientesID.SelectedItem as Cliente).Id });

                    if (result?.Count > 0)
                    {
                        if (MessageBox.Show($"Foi encontrado registro de venda de {entrada.ToString().ToUpper()} no mesmo período para o(s) cliente(s) Nº {string.Join(", ", result.Select(x => x.Cliente.Identificador).Distinct())}. Deseja realmente lançar novamente?", "Finalizar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))
                            return;
                    }
                }
            }

            CalcularTotalVenda();

            if (decimal.TryParse(lblTotal.Text.Replace("R$", default).Trim(), out decimal totalVenda) && totalVenda > 0)
            {
                using (new ControlManager(this.Controls))
                {
                    var selectedClient = cbClientesID.SelectedItem as Cliente;

                    Venda venda = new()
                    {
                        Data = dtPicker.Value,
                        Acrescimo = decimal.Parse(tbTaxa.Text.Replace("R$", default).Trim()),
                        Desconto = decimal.Parse(tbDesconto.Text.Replace("R$", default).Trim()),
                        ModoVenda = Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString()),
                        TotalVenda = totalVenda,
                        IdCliente = selectedClient.Id,
                        VendaPaga = cbVendaPaga.Checked,
                        Produtos = GetProdutosOnVenda(true)
                    };

                    var vendaProcessada = await _vendaContext.Add(venda);

                    await _vendaContext.Save();

                    await _log.Add($"Venda Nº {vendaProcessada.Id} finalizada no sistema em nome do cliente {selectedClient.Nome}({selectedClient.Identificador}) no valor total de {vendaProcessada.TotalVenda.ToString("c")}");

                    MessageBox.Show("Venda finalizada com sucesso. Abra a tela de Consultar Venda para verificar o registro.", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Clear();
            }
            else
            {
                MessageBox.Show("O valor da venda não pode ser 0", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public async Task VendaClienteMultiplo()
        {
            var clientesSelecionados = GetClienteOnList();

            if (clientesSelecionados.Count <= 0)
            {
                MessageBox.Show("Inclua algum cliente na lista para finalizar a venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientesID.Focus();
                return;
            }

            if (cbModoVenda.SelectedItem is null | cbModoVenda.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um modo de venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbModoVenda.Focus();
                return;
            }

            if (GetProdutosOnVenda(false).Count <= 0)
            {
                MessageBox.Show("Não foi selecionado nenhum produto para venda", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbVendaPaga.Checked && MessageBox.Show($"A venda está sendo finalizada já como status de PAGO. Tem certeza que já está paga? OBS.: A VENDA SERÁ FINALIZADA COMO PAGO PARA *TODOS* OS CLIENTES", "Finalizar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))
            {
                return;
            }

            if (Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString()) is not EModoVenda.Dia)
            {
                var entrada = Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString());

                var dataOrigem = entrada switch
                {
                    EModoVenda.Semana => DateTime.Now.AddDays(-7),
                    EModoVenda.Mes => DateTime.Now.AddMonths(-1),
                    EModoVenda.Semestre => DateTime.Now.AddMonths(-6),
                    EModoVenda.Ano => DateTime.Now.AddYears(-1),
                    _ => new DateTime()
                };

                if (dataOrigem != new DateTime())
                {
                    var result = await _vendaContext.SearchExistingSale(dataOrigem, DateTime.Today, entrada, clientesSelecionados.Select(x => x.Id).ToList());

                    if (result?.Count > 0)
                    {
                        if (MessageBox.Show($"Foi encontrado registro de venda de {entrada.ToString().ToUpper()} no mesmo período para o(s) cliente(s) Nº {string.Join(", ", result.Select(x => x.Cliente.Identificador).Distinct())}. Deseja realmente lançar novamente?", "Finalizar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))
                            return;
                    }
                }
            }

            CalcularTotalVenda();

            if (decimal.TryParse(lblTotal.Text.Replace("R$", default).Trim(), out decimal totalVenda) && totalVenda > 0)
            {
                using (new ControlManager(this.Controls))
                {
                    List<Venda> vendas = new();

                    foreach (var cliente in clientesSelecionados)
                    {
                        vendas.Add(new()
                        {
                            Data = dtPicker.Value,
                            Acrescimo = decimal.Parse(tbTaxa.Text.Replace("R$", default).Trim()),
                            Desconto = decimal.Parse(tbDesconto.Text.Replace("R$", default).Trim()),
                            ModoVenda = Enum.Parse<EModoVenda>(cbModoVenda.SelectedItem.ToString()),
                            TotalVenda = totalVenda,
                            IdCliente = cliente.Id,
                            VendaPaga = cbVendaPaga.Checked,
                            Produtos = GetProdutosOnVenda(true)
                        });
                    }

                    await _vendaContext.AddRange(vendas);

                    await _vendaContext.Save();

                    await _log.Add($"Venda CONJUNTA finalizada no sistema em nome dos clientes {string.Join(", ", clientesSelecionados.Select(x => x.Identificador).Distinct())} no valor total de {totalVenda.ToString("c")}");

                    MessageBox.Show("Venda finalizada com sucesso. Abra a tela de Consultar Venda para verificar o registro.", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Clear();
            }
            else
            {
                MessageBox.Show("O valor da venda não pode ser 0", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public List<Cliente> GetClienteOnList()
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (var cliente in lbClientes.Items)
            {
                clientes.Add(cliente as Cliente);
            }

            return clientes;
        }

        public void Clear()
        {
            tbDesconto.Text = 0.ToString("c");
            tbTaxa.Text = 0.ToString("c");
            lblTotal.Text = 0.ToString("c");
            lbClientes.Items.Clear();

            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                row.Cells["Quantia"].Value = 0;
            }

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
            var selectedValue = ((List<Cliente>)cbClientesID.DataSource).Where(x => x.Identificador.Equals(cbClientesID.Text)).FirstOrDefault();

            if (selectedValue is null)
            {
                MessageBox.Show("Cliente selecionado não existe", "Selecionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientesID.Focus();
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
            if (!char.IsControl(e.KeyChar) & !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvProdutos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dgvProdutos.Rows[e.RowIndex].Cells["Quantia"].Value;

                if ((bool)(row is null | row?.ToString().Equals("0") | !int.TryParse(row?.ToString(), out _)))
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

                if ((bool)(rowValue is null | rowValue?.ToString().Equals("0") | !int.TryParse(rowValue?.ToString(), out _)))
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

        private void cbClientesID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientesNome.DataSource is null)
                return;

            var selectedValue = ((List<Cliente>)cbClientesID.DataSource).Where(x => int.Parse(x.Identificador).Equals(int.Parse(cbClientesID.Text))).FirstOrDefault();

            if (selectedValue != null)
            {
                cbClientesNome.SelectedItem = selectedValue;
                cbClientesNome.DisplayMember = "Nome";
            }
            else
            {
                MessageBox.Show("Não existe cliente com o identificador informado", "Selecionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientesID.Focus();
            }
        }

        private void cbClientesNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientesID.DataSource is null)
                return;

            var selectedValue = ((List<Cliente>)cbClientesNome.DataSource).Where(x => x.Nome.Equals(cbClientesNome.Text.ToUpper())).FirstOrDefault();

            if (selectedValue != null)
            {
                cbClientesID.SelectedItem = selectedValue;
                cbClientesID.DisplayMember = "Identificador";
            }
            else
            {
                MessageBox.Show("Não existe cliente com o nome informado", "Selecionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClientesNome.Focus();
            }
        }

        private void cbClientesID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                cbClientesID_SelectedIndexChanged(this, null);

                if (cbVendaMultipla.Checked)
                    btnAdicionarCliente.PerformClick();

                cbClientesID.Focus();
            }
        }

        private void cbClientesNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                cbClientesNome_SelectedIndexChanged(this, null);
            }
        }

        private void cbModoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                dtPicker.Focus();
            }
        }

        private void cbClientesID_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) || !int.TryParse(cbClientesID.Text.Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }
        private void AlternarVendaMultipla()
        {
            if (cbVendaMultipla.Checked)
            {
                openedPositions.ForEach(x => x.Item1.Location = x.Item2);
                this.Size = openedFormSize;

                btnAdicionarCliente.Visible = cbVendaMultipla.Checked;
                lbClientes.Visible = cbVendaMultipla.Checked;
                btnRetirarCliente.Visible = cbVendaMultipla.Checked;
            }
            else
            {
                originalPositions.ForEach(x => x.Item1.Location = x.Item2);
                this.Size = originalFormSize;

                btnAdicionarCliente.Visible = cbVendaMultipla.Checked;
                lbClientes.Visible = cbVendaMultipla.Checked;
                btnRetirarCliente.Visible = cbVendaMultipla.Checked;

                lbClientes.Items.Clear();
            }

            this.CenterToScreen();
        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            if (cbClientesID.SelectedItem is null)
                return;

            if (lbClientes.Items.Contains(cbClientesID.SelectedItem as Cliente))
                return;

            lbClientes.Items.Add(cbClientesID.SelectedItem as Cliente);
        }

        private void btnRetirarCliente_Click(object sender, EventArgs e)
        {
            if (lbClientes.SelectedIndex > -1)
                lbClientes.Items.RemoveAt(lbClientes.SelectedIndex);
        }

        private void cbClientesID_Leave(object sender, EventArgs e)
        {
            cbClientesID_SelectedIndexChanged(this, null);
        }

        private void cbClientesNome_Leave(object sender, EventArgs e)
        {
            cbClientesNome_SelectedIndexChanged(this, null);
        }

        private void cbVendaMultipla_CheckedChanged(object sender, EventArgs e)
        {
            AlternarVendaMultipla();
        }
    }
}
