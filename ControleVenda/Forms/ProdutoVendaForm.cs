using Infra.Helpers;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ProdutoVendaForm : Form
    {
        public ProdutoVendaForm(List<ProdutoVenda> produtos)
        {
            InitializeComponent();

            FillGrid(produtos);
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FillGrid(List<ProdutoVenda> produtos)
        {
            var retorno = from p in produtos
                          select new
                          {
                              Produto = p.Produto.Nome,
                              Quantidade = p.Quantidade,
                              Preco = p.Produto.Preco,
                              Total = p.Quantidade * p.Produto.Preco
                          };

            dgvProdutos.DataSource = retorno.ToList();
            lblTotal.Text = retorno.Sum(x => x.Total).ToString("c");
            FormatColumns();
        }
        private void FormatColumns()
        {
            try
            {                
                dgvProdutos.Columns["Produto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProdutos.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;                                            
                dgvProdutos.Columns["Preco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;                                            
                dgvProdutos.Columns["Total"].DefaultCellStyle.Format = "c";
                dgvProdutos.Columns["Preco"].DefaultCellStyle.Format = "c";
                dgvProdutos.Columns["Quantidade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

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
    }
}
