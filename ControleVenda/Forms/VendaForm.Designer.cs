
namespace ControleVenda.Forms
{
    partial class VendaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbModoVenda = new System.Windows.Forms.ComboBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.tbPesquisa = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tbTaxa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbDesconto = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTotalDescricao = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(15, 16);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(37, 34);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 83;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(784, 68);
            this.lblDescription.TabIndex = 82;
            this.lblDescription.Text = "LANÇAMENTO DE VENDAS";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 87;
            this.label3.Text = "Selecione o cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(9, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 91;
            this.label2.Text = "Modo de venda:";
            // 
            // cbModoVenda
            // 
            this.cbModoVenda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbModoVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModoVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbModoVenda.FormattingEnabled = true;
            this.cbModoVenda.Items.AddRange(new object[] {
            "Selecionar modo de venda",
            "Dia",
            "Semana",
            "Mes",
            "Semestre",
            "Ano"});
            this.cbModoVenda.Location = new System.Drawing.Point(139, 107);
            this.cbModoVenda.Name = "cbModoVenda";
            this.cbModoVenda.Size = new System.Drawing.Size(630, 23);
            this.cbModoVenda.TabIndex = 1;
            this.cbModoVenda.Leave += new System.EventHandler(this.cbModoVenda_Leave);
            // 
            // cbClientes
            // 
            this.cbClientes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Items.AddRange(new object[] {
            "Selecionar modo de venda",
            "Dia",
            "Semana",
            "Mes",
            "Semestre",
            "Ano"});
            this.cbClientes.Location = new System.Drawing.Point(139, 75);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(630, 23);
            this.cbClientes.TabIndex = 0;
            this.cbClientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbClientes_KeyPress);
            this.cbClientes.Leave += new System.EventHandler(this.cbClientes_Leave);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.Quantia,
            this.Preco});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProdutos.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvProdutos.GridColor = System.Drawing.Color.White;
            this.dgvProdutos.Location = new System.Drawing.Point(-1, 170);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProdutos.RowTemplate.Height = 25;
            this.dgvProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.ShowCellErrors = false;
            this.dgvProdutos.ShowEditingIcon = false;
            this.dgvProdutos.ShowRowErrors = false;
            this.dgvProdutos.Size = new System.Drawing.Size(787, 295);
            this.dgvProdutos.TabIndex = 94;
            this.dgvProdutos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellLeave);
            this.dgvProdutos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellLeave);
            this.dgvProdutos.Leave += new System.EventHandler(this.dgvProdutos_Leave);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Quantia
            // 
            this.Quantia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quantia.DefaultCellStyle = dataGridViewCellStyle5;
            this.Quantia.HeaderText = "Quantidade";
            this.Quantia.Name = "Quantia";
            this.Quantia.Width = 112;
            // 
            // Preco
            // 
            this.Preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Preco.HeaderText = "Preço";
            this.Preco.Name = "Preco";
            this.Preco.ReadOnly = true;
            this.Preco.Width = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 95;
            this.label1.Text = "Pesquisar produto:";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.BackgroundImage")));
            this.btnAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Location = new System.Drawing.Point(749, 143);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(20, 20);
            this.btnAtualizar.TabIndex = 3;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // tbPesquisa
            // 
            this.tbPesquisa.BackColor = System.Drawing.Color.White;
            this.tbPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPesquisa.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPesquisa.Location = new System.Drawing.Point(141, 142);
            this.tbPesquisa.Name = "tbPesquisa";
            this.tbPesquisa.PlaceholderText = "Pesquisar";
            this.tbPesquisa.Size = new System.Drawing.Size(594, 18);
            this.tbPesquisa.TabIndex = 2;
            this.tbPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPesquisa_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(141, 162);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(594, 1);
            this.pictureBox2.TabIndex = 98;
            this.pictureBox2.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(0, 495);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(784, 68);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "   Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // tbTaxa
            // 
            this.tbTaxa.BackColor = System.Drawing.Color.White;
            this.tbTaxa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTaxa.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbTaxa.Location = new System.Drawing.Point(58, 474);
            this.tbTaxa.Name = "tbTaxa";
            this.tbTaxa.PlaceholderText = "Adicionar Taxa";
            this.tbTaxa.Size = new System.Drawing.Size(246, 18);
            this.tbTaxa.TabIndex = 4;
            this.tbTaxa.Text = "R$ 0,00";
            this.tbTaxa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTaxa_KeyPress);
            this.tbTaxa.Leave += new System.EventHandler(this.tbTaxa_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(58, 494);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 1);
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // tbDesconto
            // 
            this.tbDesconto.BackColor = System.Drawing.Color.White;
            this.tbDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDesconto.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbDesconto.Location = new System.Drawing.Point(401, 474);
            this.tbDesconto.Name = "tbDesconto";
            this.tbDesconto.PlaceholderText = "Adicionar Desconto";
            this.tbDesconto.Size = new System.Drawing.Size(189, 18);
            this.tbDesconto.TabIndex = 5;
            this.tbDesconto.Text = "R$ 0,00";
            this.tbDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDesconto_KeyPress);
            this.tbDesconto.Leave += new System.EventHandler(this.tbDesconto_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(401, 494);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(189, 1);
            this.pictureBox3.TabIndex = 106;
            this.pictureBox3.TabStop = false;
            // 
            // lblTotalDescricao
            // 
            this.lblTotalDescricao.AutoSize = true;
            this.lblTotalDescricao.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDescricao.Location = new System.Drawing.Point(596, 476);
            this.lblTotalDescricao.Name = "lblTotalDescricao";
            this.lblTotalDescricao.Size = new System.Drawing.Size(49, 19);
            this.lblTotalDescricao.TabIndex = 107;
            this.lblTotalDescricao.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotal.Location = new System.Drawing.Point(658, 475);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(115, 19);
            this.lblTotal.TabIndex = 108;
            this.lblTotal.Text = "R$ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 109;
            this.label4.Text = "Taxa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(320, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 110;
            this.label5.Text = "Desconto:";
            // 
            // VendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 563);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalDescricao);
            this.Controls.Add(this.tbDesconto);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbTaxa);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.tbPesquisa);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.cbModoVenda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Venda - Lançamento de Vendas";
            this.Load += new System.EventHandler(this.VendaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbModoVenda;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.TextBox tbPesquisa;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox tbTaxa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbDesconto;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTotalDescricao;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}