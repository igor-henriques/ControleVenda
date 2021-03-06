using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models;
using Infra.Models.Table;
using Infra.SMS;
using Infra.SMS.Request;
using SendSMS.Interfaces;
using SendSMS.Models.Requests;
using SendSMS.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly ISMSRepository _smsContext;
        private readonly IServiceSMS serviceSMS;
        private readonly Settings settings;
        public ClienteForm(IClienteRepository clienteContext, ILogRepository logContext, IRelatorioRepository relatorioContext, ISMSRepository smsContext, Settings settings)
        {
            InitializeComponent();

            this.settings = settings;

            this.serviceSMS = new ServiceSMS(settings.Key);

            this._clienteContext = clienteContext;
            this._log = logContext;
            this._relatorioContext = relatorioContext;
            this._smsContext = smsContext;

            this.ctxEnviarSMS.Click += async (obj, e) => await this.ctxEnviarSMS_Click(obj, e);
            this.ctxQuitarPendencia.Click += async (obj, e) => await this.ctxQuitarPendencia_Click(obj, e);
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }
        private async Task LoadGrid()
        {
            try
            {
                dgvClientes.DataSource = await _clienteContext.GetClientes();

                FormatColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }

            return default;
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Selecione ao menos uma linha para excluir", "Excluir Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
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
            try
            {
                tbPesquisa.Clear();

                using (new ControlManager(this.Controls))
                    await LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }

        private async void ctxExportarPendencias_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }
        private void BuildTXT(IOrderedEnumerable<IGrouping<Cliente, Venda>> vendasAgrupadasPorCliente)
        {
            try
            {
                foreach (var vendasPorCliente in vendasAgrupadasPorCliente)
                {
                    StringBuilder sb = new StringBuilder();

                    decimal totalPorCliente = 0M;

                    sb.AppendLine($"{vendasPorCliente.Key.Nome} ({vendasPorCliente.Key.Identificador})");

                    foreach (var venda in vendasPorCliente.OrderBy(x => x.Data))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }
        private void CheckClientDirectory(string cliente)
        {
            try
            {
                if (!Directory.Exists($"./Pendências Clientes/{cliente}"))
                    Directory.CreateDirectory($"./Pendências Clientes/{cliente}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }

        private async Task ctxEnviarSMS_Click(object sender, EventArgs e)
        {
            try
            {
                using (new ControlManager(this.Controls))
                {
                    var clientes = GetSelectedClients();

                    var sales = await _relatorioContext.RelatorioPorDataCliente(DateTime.Today.AddYears(-1), DateTime.Today, clientes, Infra.Models.Enum.EVendaEstado.Pendente);

                    if (sales?.Count <= 0)
                    {
                        MessageBox.Show("Não há pendências aos clientes selecionados.", "Enviar SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var mensagensPorCliente = _smsContext.BuildMessageSMS(sales);

                    foreach (var mensagem in mensagensPorCliente)
                    {
                        var request = await _smsContext.SendSMS(new()
                        {
                            Type = 9,
                            Msg = mensagem.Value,
                            Number = mensagem.Key.Telefone
                        });                        

                        var situacao = await _smsContext.CheckSituationSMS(new()
                        {
                            Id = request.Id.ToString()
                        });

                        await _smsContext.Add(new SMS
                        {
                            Id = request.Id,
                            Descricao = situacao.Descricao,
                            Mensagem = $"{mensagem.Value}",
                            Situacao = situacao.Situacao,
                            Codigo = situacao.Codigo,
                            IdCliente = mensagem.Key.Id
                        });
                    }

                    await _smsContext.Save();

                    MessageBox.Show("SMS enviadas a todos os clientes selecionados", "Enviar SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }

        private void tbIdentificador_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClientes.RowCount > 0 & string.IsNullOrEmpty(tbIdentificador.Text))
                tbIdentificador.Text = (int.Parse(dgvClientes.Rows[0].Cells["Identificador"].Value.ToString()) + 1).ToString("D2");
        }

        private async Task ctxQuitarPendencia_Click(object sender, EventArgs e)
        {
            try
            {
                using (new ControlManager(this.Controls))
                {
                    if (dgvClientes.SelectedRows.Count <= 0)
                    {
                        MessageBox.Show("Selecione ao menos um cliente para quitar pendência", "Quitar Pendência", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show($"Deseja realmente quitar pendência de {dgvClientes.SelectedRows.Count} cliente(s)?", "Quitar Pendência", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.No))
                        return;

                    var clientes = GetSelectedClients();

                    if (clientes?.Count > 0)
                    {
                        var vendasQuitadas = await _clienteContext.Pay(clientes);

                        await _clienteContext.Save();

                        MessageBox.Show($"{vendasQuitadas.Count} venda(s) quitada(s) de {clientes.Count} cliente(s)", "Quitar Pendência", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (var venda in vendasQuitadas)
                        {
                            await _log.Add($"Venda Nº {venda.Id} no nome do cliente {venda.Cliente.Nome}({venda.Cliente.Identificador}) QUITADA. Valor: {venda.TotalVenda.ToString("c")}");
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }

        private async void ctxGerarTextoPendencia_Click(object sender, EventArgs e)
        {
            try
            {
                var clientes = GetSelectedClients();

                if (clientes?.Count > 0)
                {
                    var sales = await _relatorioContext.RelatorioPorDataCliente(DateTime.Today.AddYears(-1), DateTime.Today, clientes, Infra.Models.Enum.EVendaEstado.Pendente);

                    if (sales?.Count <= 0)
                    {
                        MessageBox.Show("Não há pendências aos clientes selecionados.", "Enviar SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var mensagensPorCliente = _smsContext.BuildMessageSMS(sales);

                    if (mensagensPorCliente?.Count > 0)
                        Infra.Helpers.Clipboard.SetText(mensagensPorCliente.FirstOrDefault().Value);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }

        private async void ctxEnviarWhatsapp_Click(object sender, EventArgs e)
        {
            try
            {
                var clientes = GetSelectedClients();

                if (clientes?.Count > 0)
                {
                    var sales = await _relatorioContext.RelatorioPorDataCliente(DateTime.Today.AddYears(-1), DateTime.Today, clientes, Infra.Models.Enum.EVendaEstado.Pendente);

                    if (sales?.Count <= 0)
                    {
                        MessageBox.Show("Não há pendências aos clientes selecionados.", "Enviar SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var mensagensPorCliente = _smsContext.BuildMessageSMS(sales);

                    if (mensagensPorCliente?.Count > 0)
                    {
                        string url = $"{settings.ModoWhatsapp.GetDescription()}send?phone=55@phone&text=@text";

                        string filteredText = mensagensPorCliente.FirstOrDefault().Value.Replace("\n", "%0D");

                        string phoneNumber = mensagensPorCliente.FirstOrDefault().Key.Telefone;

                        FilterPhoneNumber(ref phoneNumber);

                        Process.Start(new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = url.Replace("@phone", phoneNumber).Replace("@text", filteredText)
                        });
                    }                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }

        private void FilterPhoneNumber(ref string number)
        {
            number  .Replace(" ", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "")
                    .Trim();
        }
    }
}