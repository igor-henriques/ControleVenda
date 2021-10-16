using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models.Table;
using Infra.SMS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ClienteForm : Form
    {
        private readonly IClienteRepository _clienteContext;
        private readonly IRelatorioRepository _relatorioContext;
        private readonly ILogRepository _log;
        public ClienteForm(IClienteRepository clienteContext, ILogRepository logContext, IRelatorioRepository relatorioContext)
        {
            InitializeComponent();

            this._clienteContext = clienteContext;
            this._log = logContext;
            this._relatorioContext = relatorioContext;
        }

        private async void ClienteForm_Load(object sender, EventArgs e)
        {
            using (new ControlManager(this.Controls))
                await LoadGrid();

            this.Focus();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Cliente BuildCliente()
        {
            return new Cliente
            {
                Identificador = tbIdentificador.Text.Trim(),
                Nome = tbNome.Text.Trim(),
                NumeroCurso = ushort.Parse(tbNumeroCurso.Text.Length >= 1 ? tbNumeroCurso.Text.Trim() : "0"),
                Pelotao = ushort.Parse(tbNumeroPel.Text.Length >= 1 ? tbNumeroPel.Text.Trim() : "0"),
                Telefone = mtbTelefone.Text
            };
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                pbBack_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool CheckTextbox()
        {
            if (string.IsNullOrEmpty(tbNome.Text.Trim()) | string.IsNullOrEmpty(tbIdentificador.Text.Trim()) | !mtbTelefone.Text.Any(c => char.IsDigit(c)))
                return false;

            return true;
        }
        private void dgvClientes_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvClientes.HitTest(e.X, e.Y);

                    dgvClientes.Rows[hti.RowIndex <= -1 ? 0 : hti.RowIndex].Selected = true;

                    Point here = new Point((dgvClientes.Location.X) + e.X, (dgvClientes.Location.Y) + e.Y);
                    ctxMenu.Show(this, here);
                }
            }
            catch (Exception) { }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!CheckTextbox())
            {
                MessageBox.Show("Há campos vazios", "Salvar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = BuildCliente();

            if (await _clienteContext.Get(cliente.Identificador) is not null)
            {
                MessageBox.Show("Já existe registro com esse Identificador", "Salvar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (new ControlManager(this.Controls))
            {
                await _clienteContext.Add(cliente);
                await _clienteContext.Save();

                await LoadGrid();

                await _log.Add($"Cliente {cliente.Nome}({cliente.Identificador}) ADICIONADO ao sistema");
            }

            Clear();
        }
        private async Task LoadGrid()
        {
            dgvClientes.DataSource = await _clienteContext.GetClientes();

            FormatColumns();
        }
        private void FormatColumns()
        {
            try
            {
                dgvClientes.Columns["Id"].Visible = false;
                dgvClientes.Columns["Identificador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClientes.Columns["NumeroCurso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns["Pelotao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns["Telefone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvClientes.Columns["NumeroCurso"].HeaderText = "Nº de Curso";
                dgvClientes.Columns["Pelotao"].HeaderText = "Pelotão";

                for (int i = 0; i < dgvClientes.RowCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        dgvClientes.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        dgvClientes.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }

                dgvClientes.ClearSelection();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void Clear()
        {
            tbNome.Clear();
            tbIdentificador.Clear();
            tbNumeroCurso.Clear();
            tbNumeroPel.Clear();
            mtbTelefone.Clear();
        }

        private void tbIdentificador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tbNome.Focus();
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tbNumeroCurso.Focus();
        }

        private void tbNumeroCurso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tbNumeroPel.Focus();
        }

        private void tbNumeroPel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                mtbTelefone.Focus();
        }

        private void mtbTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && btnSalvar.Enabled)
                btnSalvar.PerformClick();
            else if (e.KeyCode.Equals(Keys.Enter) && !btnSalvar.Enabled)
                btnEditar.PerformClick();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var selectedClient = GetSelectedClients().FirstOrDefault();

            if (selectedClient is null)
            {
                MessageBox.Show("Selecione uma linha para atualizar", "Atualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnEditar.Text.Equals("  Editar"))
            {
                tbIdentificador.Text = selectedClient.Identificador.ToString();
                tbNome.Text = selectedClient.Nome;
                tbNumeroCurso.Text = selectedClient.NumeroCurso.ToString();
                tbNumeroPel.Text = selectedClient.Pelotao.ToString();
                mtbTelefone.Text = selectedClient.Telefone;

                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                dgvClientes.Enabled = false;
                tbPesquisa.Enabled = false;

                btnEditar.Text = "  Atualizar";
            }
            else
            {
                if (!CheckTextbox())
                {
                    MessageBox.Show("Há campos vazios", "Salvar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ReturnFromEditing();
                    return;
                }

                selectedClient = selectedClient with
                {
                    Nome = tbNome.Text,
                    Identificador = tbIdentificador.Text.Trim(),
                    NumeroCurso = ushort.Parse(tbNumeroCurso.Text.Length > 0 ? tbNumeroCurso.Text.Trim() : "0"),
                    Pelotao = ushort.Parse(tbNumeroPel.Text.Length > 0 ? tbNumeroPel.Text.Trim() : "0"),
                    Telefone = mtbTelefone.Text.Trim()
                };

                if (await _clienteContext.Get(selectedClient.Identificador) is not null)
                {
                    MessageBox.Show("Já existe registro com esse Identificador", "Salvar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ReturnFromEditing();
                    return;
                }

                using (new ControlManager(this.Controls))
                {
                    await _clienteContext.Update(selectedClient);
                    await _clienteContext.Save();

                    await LoadGrid();

                    await _log.Add($"Cliente {selectedClient.Nome}({selectedClient.Identificador}) ATUALIZADO no sistema");
                }

                ReturnFromEditing();
            }
        }
        private void ReturnFromEditing()
        {
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            dgvClientes.Enabled = true;
            tbPesquisa.Enabled = true;

            btnEditar.Text = "  Editar";

            Clear();
        }
        private List<Cliente> GetSelectedClients()
        {
            List<Cliente> response = new();

            foreach (DataGridViewRow row in dgvClientes.SelectedRows)
            {
                response.Add(new()
                {
                    Id = int.Parse(row.Cells["Id"].Value.ToString()),
                    Identificador = row.Cells["Identificador"].Value.ToString(),
                    Nome = row.Cells["Nome"].Value.ToString(),
                    NumeroCurso = ushort.Parse(row.Cells["NumeroCurso"].Value.ToString()),
                    Pelotao = ushort.Parse(row.Cells["Pelotao"].Value.ToString()),
                    Telefone = row.Cells["Telefone"].Value.ToString()
                });
            }

            return response;
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma linha para excluir", "Excluir Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir os {dgvClientes.SelectedRows.Count} clientes?", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                var selectedClients = GetSelectedClients();

                if (selectedClients.Count > 0)
                {
                    var vendasAfetadas = await _clienteContext.ChecarVendasComCliente(selectedClients);
                    if (vendasAfetadas?.Count > 0)
                    {
                        if (MessageBox.Show($"Há {vendasAfetadas.Count} venda(s) realizada(s) com esse(s) cliente(s). Caso opte por excluir, o(s) registro(s) de venda será(ão) deletados. DESEJA CONTINUAR?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk).Equals(DialogResult.No))
                            return;
                    }

                    using (new ControlManager(this.Controls))
                    {
                        await _clienteContext.Remove(selectedClients);
                        await _clienteContext.Save();

                        await LoadGrid();

                        foreach (var cliente in selectedClients)
                        {
                            await _log.Add($"Cliente {cliente.Nome}({cliente.Identificador}) REMOVIDO do sistema");
                        }
                    }

                    Clear();
                }
            }
        }

        private void tbNumeroCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) | !ushort.TryParse(tbNumeroCurso.Text.Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }

        private void tbNumeroPel_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) | !ushort.TryParse(tbNumeroPel.Text.Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }

        private void tbIdentificador_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) | !ushort.TryParse(tbIdentificador.Text.Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }

        private async void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbPesquisa.Text.Trim() != string.Empty)
                {
                    var resultados = await _clienteContext.Pesquisar(rbNome.Checked ? "Nome" : rbIdentificador.Checked ? "Identificador" : "Telefone", tbPesquisa.Text);

                    dgvClientes.DataSource = resultados.ToList();

                    FormatColumns();
                }
                else
                {
                    btnAtualizar.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            tbPesquisa.Clear();

            using (new ControlManager(this.Controls))
                await LoadGrid();
        }

        private async void ctxExportarPendencias_Click(object sender, EventArgs e)
        {
            using (new ControlManager(this.Controls))
            {
                var clientes = GetSelectedClients();

                var sales = await _relatorioContext.RelatorioPorDataCliente(DateTime.Today.AddYears(-1), DateTime.Today, clientes, Infra.Models.Enum.EVendaEstado.Pendente);                

                if (sales.Count <= 0)
                {
                    MessageBox.Show("Não foi encontrado registro de venda com a seleção especificada", "Emitir Relatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var vendasAgrupadasPorCliente = from venda in sales
                                                group venda by venda.Cliente into vendasAgrupadas
                                                orderby vendasAgrupadas.Key.Identificador
                                                select vendasAgrupadas;

                BuildTXT(vendasAgrupadasPorCliente);

                MessageBox.Show("Relatório exportado com sucesso na pasta Pendências Cliente", "Emitir Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        private void BuildTXT(IOrderedEnumerable<IGrouping<Cliente, Venda>> vendasAgrupadasPorCliente)
        {            
            foreach (var vendasPorCliente in vendasAgrupadasPorCliente)
            {
                StringBuilder sb = new StringBuilder();

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

                sb.AppendLine($"Total de Pendências do Cliente: {totalPorCliente.ToString("c")}");

                CheckClientDirectory(vendasPorCliente.Key.Nome);

                File.WriteAllTextAsync($"./Pendências Clientes/{vendasPorCliente.Key.Nome}/Relatório N{Directory.GetFiles($"./Pendências Clientes/{vendasPorCliente.Key.Nome}/").Count() + 1} - Cliente {vendasPorCliente.Key.Nome}({vendasPorCliente.Key.Identificador}).txt", sb.ToString());
            }
        }
        private void CheckClientDirectory(string cliente)
        {
            if (!Directory.Exists($"./Pendências Clientes/{cliente}"))
                Directory.CreateDirectory($"./Pendências Clientes/{cliente}");
        }

        private void ctxEnviarSMS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função ainda não implementada.", "Enviar SMS por Cliente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}