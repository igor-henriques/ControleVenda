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
        private readonly ILogRepository _log;
        public ProdutoForm(IProdutoRepository produtoContext, ILogRepository logRepository)
        {
            InitializeComponent();

            this._produtoContext = produtoContext;
            this._log = logRepository;
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

            if (await _produtoContext.Get(produto.Nome) is not null)
            {
                MessageBox.Show("Já existe registro com esse nome", "Salvar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (new ControlManager(this.Controls))
            {
                await _produtoContext.Add(produto);
                await _produtoContext.Save();

                await LoadGrid();

                await _log.Add($"Produto {produto.Nome} ADICIONADO ao sistema");
            }

            Clear();
        }
        private Produto BuildProduct()
        {
            return new Produto
            {
                Nome = tbNome.Text.Trim(),
                Preco = decimal.Parse(tbPrice.Text.Length > 0 ? tbPrice.Text.Replace("R$", default).Trim() : "0")
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
            tbPrice.Text = 0.ToString("c");
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
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
                if (!CheckTextbox())
                {
                    MessageBox.Show("Há campos vazios", "Salvar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ReturnFromEditing();

                    return;
                }

                selectedProduct = selectedProduct with
                {
                    Nome = tbNome.Text,
                    Preco = decimal.Parse(tbPrice.Text.Replace("R$", default).Trim())
                };

                if (await _produtoContext.Get(selectedProduct.Nome) is not null)
                {
                    MessageBox.Show("Já existe registro com esse nome", "Salvar Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ReturnFromEditing();

                    return;
                }

                using (new ControlManager(this.Controls))
                {
                    await _produtoContext.Update(selectedProduct);
                    await _produtoContext.Save();

                    await LoadGrid();

                    await _log.Add($"Produto {selectedProduct.Nome} ATUALIZADO no sistema");
                }

                ReturnFromEditing();
            }
        }
        private void ReturnFromEditing()
        {
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            dgvProdutos.Enabled = true;

            btnEditar.Text = "  Editar";

            Clear();
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione ao menos uma linha para excluir", "Excluir Produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (MessageBox.Show($"Tem certeza que deseja excluir os {dgvProdutos.SelectedRows.Count} produtos?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                return;

            var selectedProducts = GetSelectedProducts();

            if (selectedProducts.Count > 0)
            {
                var vendasAfetadas = await _produtoContext.ChecarVendasComProduto(selectedProducts);
                if (vendasAfetadas?.Count > 0)
                {
                    if (MessageBox.Show($"Há {vendasAfetadas.Count} venda(s) realizada(s) com esse(s) produto(s). Caso opte por excluir, o(s) registro(s) de venda será(ão) deletados. DESEJA CONTINUAR?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk).Equals(DialogResult.No))
                        return;
                }

                using (new ControlManager(this.Controls))
                {
                    await _produtoContext.Remove(selectedProducts);
                    await _produtoContext.Save();

                    await LoadGrid();

                    foreach (var selectedProduct in selectedProducts)
                    {
                        await _log.Add($"Produto {selectedProduct.Nome} REMOVIDO do sistema");
                    }                    
                }

                Clear();
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

                    dgvProdutos.DataSource = resultados.ToList();

                    FormatColumns();
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                pbBack_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tbPrice_Leave(object sender, EventArgs e)
        {
            if (tbPrice.Text.Trim() != string.Empty)
                tbPrice.Text = decimal.Parse(tbPrice.Text.Replace("R$ ", "").Trim()).ToString("c");
        }
    }
}
