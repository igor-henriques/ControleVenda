using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ProdutoForm : Form
    {
        private readonly IProdutoRepository _produtoContext;
        public ProdutoForm(IProdutoRepository produtoContext)
        {
            InitializeComponent();

            this._produtoContext = produtoContext;
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) && ch != ',' || !decimal.TryParse(tbPrice.Text.Replace("R$", default).Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckTextbox())
            {
                MessageBox.Show("Há campos vazios", "Salvar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var produto = BuildProduct();

            using (new ControlManager(this.Controls))
            {
                await _produtoContext.Add(produto);
                await _produtoContext.Save();

                await LoadGrid();
            }

            Clear();
        }
        private Produto BuildProduct()
        {
            return new Produto
            {
                Nome = tbNome.Text.Trim(),
                Preco = decimal.Parse(tbPrice.Text.Replace("R$", default).Trim())
            };
        }
        private async Task LoadGrid()
        {
            dgvProdutos.DataSource = await _produtoContext.GetProdutos();

            FormatColumns();
        }
        private void FormatColumns()
        {
            try
            {
                dgvProdutos.Columns["Id"].Visible = false;
                dgvProdutos.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProdutos.Columns["Preco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvProdutos.Columns["Preco"].HeaderText = "Preço";
                dgvProdutos.Columns["Preco"].DefaultCellStyle.Format = "c";

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
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            tbPesquisa.Clear();

            using (new ControlManager(this.Controls))
                await LoadGrid();
        }

        private async void ProdutoForm_Load(object sender, EventArgs e)
        {
            using (new ControlManager(this.Controls))
                await LoadGrid();
        }

        private void Clear()
        {
            tbNome.Clear();
            tbPrice.Clear();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (!CheckTextbox())
            {
                MessageBox.Show("Há campos vazios", "Salvar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = GetSelectedProducts().FirstOrDefault();

            if (selectedProduct is null)
            {
                MessageBox.Show("Selecione uma linha para atualizar", "Atualizar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnEditar.Text.Equals("  Editar"))
            {
                tbNome.Text = selectedProduct.Nome;
                tbPrice.Text = selectedProduct.Preco.ToString("c");

                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                dgvProdutos.Enabled = false;

                btnEditar.Text = "  Atualizar";
            }
            else
            {
                var updatingProduct = new Produto()
                {
                    Id = selectedProduct.Id,
                    Nome = tbNome.Text,
                    Preco = decimal.Parse(tbPrice.Text.Replace("R$", default).Trim())
                };

                using (new ControlManager(this.Controls))
                {
                    await _produtoContext.Update(updatingProduct);
                    await _produtoContext.Save();

                    await LoadGrid();
                }

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;
                dgvProdutos.Enabled = true;

                btnEditar.Text = "  Editar";

                Clear();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma linha para excluir", "Excluir Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir os {dgvProdutos.SelectedRows.Count} produtos?", "Excluindo Produtos...", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                var selectedProducts = GetSelectedProducts();

                if (selectedProducts.Count > 0)
                {
                    using (new ControlManager(this.Controls))
                    {
                        await _produtoContext.Remove(selectedProducts);
                        await _produtoContext.Save();

                        await LoadGrid();
                    }

                    Clear();
                }
            }
        }
        private List<Produto> GetSelectedProducts()
        {
            List<Produto> response = new();

            foreach (DataGridViewRow row in dgvProdutos.SelectedRows)
            {
                response.Add(new()
                {
                    Id = int.Parse(row.Cells["Id"].Value.ToString()),
                    Nome = row.Cells["Nome"].Value.ToString(),
                    Preco = decimal.Parse(row.Cells["Preco"].Value.ToString().Replace("R$", default).Trim())
                });
            }

            return response;
        }

        private async void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbPesquisa.Text.Trim() != string.Empty)
                {
                    var resultados = await _produtoContext.Pesquisar(rbNome.Checked ? "Nome" : "Preco", tbPesquisa.Text);

                    if (resultados?.Count() > 0)
                    {
                        dgvProdutos.DataSource = null;
                        dgvProdutos.DataSource = resultados.ToList();
                        dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Selected = true;
                        FormatColumns();
                    }
                }
                else
                {
                    btnAtualizar.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private bool CheckTextbox()
        {
            if (string.IsNullOrEmpty(tbNome.Text.Trim()) | string.IsNullOrEmpty(tbPrice.Text.Trim()))
                return false;
            
            return true;
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                tbPrice.Focus();
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && btnSalvar.Enabled)
                btnSalvar.PerformClick();
            else if (e.KeyCode.Equals(Keys.Enter)! && btnSalvar.Enabled)
                btnEditar.PerformClick();
        }
    }
}
