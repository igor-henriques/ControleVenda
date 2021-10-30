
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblModoVendaDescricao = new System.Windows.Forms.Label();
            this.cbModoVenda = new System.Windows.Forms.ComboBox();
            this.cbClientesID = new System.Windows.Forms.ComboBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbVendaPaga = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.cbClientesNome = new System.Windows.Forms.ComboBox();
            this.cbVendaMultipla = new System.Windows.Forms.CheckBox();
            this.lblDataVendaDescricao = new System.Windows.Forms.Label();
            this.lbClientes = new System.Windows.Forms.ListBox();
            this.btnAdicionarCliente = new System.Windows.Forms.Button();
            this.btnRetirarCliente = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalDescricao = new System.Windows.Forms.Label();
            this.tbDesconto = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbTaxa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 87;
            this.label3.Text = "Selecione o cliente:";
            // 
            // lblModoVendaDescricao
            // 
            this.lblModoVendaDescricao.AutoSize = true;
            this.lblModoVendaDescricao.Font = new System.Drawing.Font("Roboto", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblModoVendaDescricao.Location = new System.Drawing.Point(12, 107);
            this.lblModoVendaDescricao.Name = "lblModoVendaDescricao";
            this.lblModoVendaDescricao.Size = new System.Drawing.Size(106, 17);
            this.lblModoVendaDescricao.TabIndex = 91;
            this.lblModoVendaDescricao.Text = "Modo de venda:";
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
            this.cbModoVenda.Location = new System.Drawing.Point(140, 104);
            this.cbModoVenda.Name = "cbModoVenda";
            this.cbModoVenda.Size = new System.Drawing.Size(490, 23);
            this.cbModoVenda.TabIndex = 1;
            this.cbModoVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbModoVenda_KeyDown);
            this.cbModoVenda.Leave += new System.EventHandler(this.cbModoVenda_Leave);
            // 
            // cbClientesID
            // 
            this.cbClientesID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbClientesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClientesID.FormattingEnabled = true;
            this.cbClientesID.Items.AddRange(new object[] {
            "Selecionar modo de venda",
            "Dia",
            "Semana",
            "Mes",
            "Semestre",
            "Ano"});
            this.cbClientesID.Location = new System.Drawing.Point(141, 74);
            this.cbClientesID.Name = "cbClientesID";
            this.cbClientesID.Size = new System.Drawing.Size(54, 23);
            this.cbClientesID.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbClientesID, "Selecionar por Identificador");
            this.cbClientesID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbClientesID_KeyPress);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.Quantia,
            this.Preco});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProdutos.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvProdutos.GridColor = System.Drawing.Color.White;
            this.dgvProdutos.Location = new System.Drawing.Point(0, 163);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvProdutos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProdutos.RowTemplate.Height = 25;
            this.dgvProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.ShowCellErrors = false;
            this.dgvProdutos.ShowEditingIcon = false;
            this.dgvProdutos.ShowRowErrors = false;
            this.dgvProdutos.Size = new System.Drawing.Size(784, 335);
            this.dgvProdutos.TabIndex = 94;
            this.dgvProdutos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellLeave);
            this.dgvProdutos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellLeave);
            this.dgvProdutos.Leave += new System.EventHandler(this.dgvProdutos_Leave);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quantia.DefaultCellStyle = dataGridViewCellStyle3;
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
            // cbVendaPaga
            // 
            this.cbVendaPaga.AutoSize = true;
            this.cbVendaPaga.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbVendaPaga.Location = new System.Drawing.Point(646, 138);
            this.cbVendaPaga.Name = "cbVendaPaga";
            this.cbVendaPaga.Size = new System.Drawing.Size(113, 23);
            this.cbVendaPaga.TabIndex = 111;
            this.cbVendaPaga.Text = "Venda paga";
            this.toolTip.SetToolTip(this.cbVendaPaga, "Marque caso o cliente já tenho pago essa compra");
            this.cbVendaPaga.UseVisualStyleBackColor = true;
            // 
            // dtPicker
            // 
            this.dtPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtPicker.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker.Location = new System.Drawing.Point(140, 135);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(488, 24);
            this.dtPicker.TabIndex = 112;
            this.toolTip.SetToolTip(this.dtPicker, "Data em que a venda foi feita");
            this.dtPicker.ValueChanged += new System.EventHandler(this.dtPicker_ValueChanged);
            // 
            // cbClientesNome
            // 
            this.cbClientesNome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbClientesNome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClientesNome.FormattingEnabled = true;
            this.cbClientesNome.Items.AddRange(new object[] {
            "Selecionar modo de venda",
            "Dia",
            "Semana",
            "Mes",
            "Semestre",
            "Ano"});
            this.cbClientesNome.Location = new System.Drawing.Point(201, 74);
            this.cbClientesNome.Name = "cbClientesNome";
            this.cbClientesNome.Size = new System.Drawing.Size(429, 23);
            this.cbClientesNome.TabIndex = 115;
            this.toolTip.SetToolTip(this.cbClientesNome, "Selecionar por Nome");
            this.cbClientesNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbClientes_KeyPress);
            // 
            // cbVendaMultipla
            // 
            this.cbVendaMultipla.AutoSize = true;
            this.cbVendaMultipla.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbVendaMultipla.Location = new System.Drawing.Point(646, 75);
            this.cbVendaMultipla.Name = "cbVendaMultipla";
            this.cbVendaMultipla.Size = new System.Drawing.Size(135, 23);
            this.cbVendaMultipla.TabIndex = 116;
            this.cbVendaMultipla.Text = "Venda múltipla";
            this.toolTip.SetToolTip(this.cbVendaMultipla, "Marque caso o cliente já tenho pago essa compra");
            this.cbVendaMultipla.UseVisualStyleBackColor = true;
            this.cbVendaMultipla.CheckedChanged += new System.EventHandler(this.cbVendaMultipla_CheckedChanged);
            // 
            // lblDataVendaDescricao
            // 
            this.lblDataVendaDescricao.AutoSize = true;
            this.lblDataVendaDescricao.Font = new System.Drawing.Font("Roboto", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDataVendaDescricao.Location = new System.Drawing.Point(12, 139);
            this.lblDataVendaDescricao.Name = "lblDataVendaDescricao";
            this.lblDataVendaDescricao.Size = new System.Drawing.Size(101, 17);
            this.lblDataVendaDescricao.TabIndex = 113;
            this.lblDataVendaDescricao.Text = "Data da venda:";
            // 
            // lbClientes
            // 
            this.lbClientes.DisplayMember = "Identificador";
            this.lbClientes.FormattingEnabled = true;
            this.lbClientes.ItemHeight = 15;
            this.lbClientes.Location = new System.Drawing.Point(140, 110);
            this.lbClientes.Name = "lbClientes";
            this.lbClientes.Size = new System.Drawing.Size(488, 64);
            this.lbClientes.TabIndex = 117;
            this.lbClientes.Visible = false;
            // 
            // btnAdicionarCliente
            // 
            this.btnAdicionarCliente.BackColor = System.Drawing.Color.White;
            this.btnAdicionarCliente.FlatAppearance.BorderSize = 0;
            this.btnAdicionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarCliente.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarCliente.Image")));
            this.btnAdicionarCliente.Location = new System.Drawing.Point(0, 110);
            this.btnAdicionarCliente.Name = "btnAdicionarCliente";
            this.btnAdicionarCliente.Size = new System.Drawing.Size(139, 64);
            this.btnAdicionarCliente.TabIndex = 118;
            this.btnAdicionarCliente.Text = " Adicionar";
            this.btnAdicionarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionarCliente.UseVisualStyleBackColor = false;
            this.btnAdicionarCliente.Visible = false;
            this.btnAdicionarCliente.Click += new System.EventHandler(this.btnAdicionarCliente_Click);
            // 
            // btnRetirarCliente
            // 
            this.btnRetirarCliente.BackColor = System.Drawing.Color.White;
            this.btnRetirarCliente.FlatAppearance.BorderSize = 0;
            this.btnRetirarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetirarCliente.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRetirarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirarCliente.Image")));
            this.btnRetirarCliente.Location = new System.Drawing.Point(629, 110);
            this.btnRetirarCliente.Name = "btnRetirarCliente";
            this.btnRetirarCliente.Size = new System.Drawing.Size(155, 64);
            this.btnRetirarCliente.TabIndex = 119;
            this.btnRetirarCliente.Text = " Retirar";
            this.btnRetirarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRetirarCliente.UseVisualStyleBackColor = false;
            this.btnRetirarCliente.Visible = false;
            this.btnRetirarCliente.Click += new System.EventHandler(this.btnRetirarCliente_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.label5);
            this.panelBottom.Controls.Add(this.label4);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Controls.Add(this.lblTotalDescricao);
            this.panelBottom.Controls.Add(this.tbDesconto);
            this.panelBottom.Controls.Add(this.pictureBox3);
            this.panelBottom.Controls.Add(this.tbTaxa);
            this.panelBottom.Controls.Add(this.pictureBox1);
            this.panelBottom.Controls.Add(this.btnSalvar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 498);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(784, 94);
            this.panelBottom.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(319, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 118;
            this.label5.Text = "Desconto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 117;
            this.label4.Text = "Taxa:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotal.Location = new System.Drawing.Point(657, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(115, 19);
            this.lblTotal.TabIndex = 116;
            this.lblTotal.Text = "R$ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDescricao
            // 
            this.lblTotalDescricao.AutoSize = true;
            this.lblTotalDescricao.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDescricao.Location = new System.Drawing.Point(595, 14);
            this.lblTotalDescricao.Name = "lblTotalDescricao";
            this.lblTotalDescricao.Size = new System.Drawing.Size(49, 19);
            this.lblTotalDescricao.TabIndex = 115;
            this.lblTotalDescricao.Text = "Total:";
            // 
            // tbDesconto
            // 
            this.tbDesconto.BackColor = System.Drawing.Color.White;
            this.tbDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDesconto.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbDesconto.Location = new System.Drawing.Point(400, 12);
            this.tbDesconto.Name = "tbDesconto";
            this.tbDesconto.PlaceholderText = "Adicionar Desconto";
            this.tbDesconto.Size = new System.Drawing.Size(189, 18);
            this.tbDesconto.TabIndex = 112;
            this.tbDesconto.Text = "R$ 0,00";
            this.tbDesconto.Leave += new System.EventHandler(this.tbDesconto_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(400, 32);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(189, 1);
            this.pictureBox3.TabIndex = 114;
            this.pictureBox3.TabStop = false;
            // 
            // tbTaxa
            // 
            this.tbTaxa.BackColor = System.Drawing.Color.White;
            this.tbTaxa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTaxa.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbTaxa.Location = new System.Drawing.Point(57, 12);
            this.tbTaxa.Name = "tbTaxa";
            this.tbTaxa.PlaceholderText = "Adicionar Taxa";
            this.tbTaxa.Size = new System.Drawing.Size(246, 18);
            this.tbTaxa.TabIndex = 111;
            this.tbTaxa.Text = "R$ 0,00";
            this.tbTaxa.Leave += new System.EventHandler(this.tbTaxa_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(57, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 1);
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(0, 33);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(784, 61);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "   Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // VendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 592);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.lblDataVendaDescricao);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.cbVendaPaga);
            this.Controls.Add(this.cbModoVenda);
            this.Controls.Add(this.lblModoVendaDescricao);
            this.Controls.Add(this.btnRetirarCliente);
            this.Controls.Add(this.btnAdicionarCliente);
            this.Controls.Add(this.lbClientes);
            this.Controls.Add(this.cbVendaMultipla);
            this.Controls.Add(this.cbClientesNome);
            this.Controls.Add(this.cbClientesID);
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
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblModoVendaDescricao;
        private System.Windows.Forms.ComboBox cbModoVenda;
        private System.Windows.Forms.ComboBox cbClientesID;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.CheckBox cbVendaPaga;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblDataVendaDescricao;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.ComboBox cbClientesNome;
        private System.Windows.Forms.CheckBox cbVendaMultipla;
        private System.Windows.Forms.ListBox lbClientes;
        private System.Windows.Forms.Button btnAdicionarCliente;
        private System.Windows.Forms.Button btnRetirarCliente;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalDescricao;
        private System.Windows.Forms.TextBox tbDesconto;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbTaxa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSalvar;
    }
}