﻿using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models.Table;
using Infra.SMS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ClienteForm : Form
    {
        private readonly IClienteRepository _clienteContext;
        public ClienteForm(IClienteRepository clienteContext)
        {
            InitializeComponent();

            this._clienteContext = clienteContext;            
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
            if (string.IsNullOrEmpty(tbNome.Text.Trim()) | string.IsNullOrEmpty(tbIdentificador.Text.Trim()) | string.IsNullOrEmpty(mtbTelefone.Text))
                return false;

            return true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!CheckTextbox())
            {
                MessageBox.Show("Há campos vazios", "Salvar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var produto = BuildCliente();

            using (new ControlManager(this.Controls))
            {
                await _clienteContext.Add(produto);
                await _clienteContext.Save();

                await LoadGrid();
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
                }

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;
                dgvClientes.Enabled = true;
                tbPesquisa.Enabled = true;

                btnEditar.Text = "  Editar";

                Clear();
            }
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
                    using (new ControlManager(this.Controls))
                    {
                        await _clienteContext.Remove(selectedClients);
                        await _clienteContext.Save();

                        await LoadGrid();
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
    }
}