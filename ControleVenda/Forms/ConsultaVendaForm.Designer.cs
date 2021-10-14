
namespace ControleVenda.Forms
{
    partial class ConsultaVendaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaVendaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produtos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbClientePesquisa = new System.Windows.Forms.ComboBox();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.rbData = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtfPicker = new System.Windows.Forms.DateTimePicker();
            this.dtiPicker = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(12, 17);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(37, 34);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 85;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(834, 68);
            this.lblDescription.TabIndex = 84;
            this.lblDescription.Text = "CONSULTA DE VENDAS";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.AllowUserToResizeColumns = false;
            this.dgvVendas.AllowUserToResizeRows = false;
            this.dgvVendas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVendas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Cliente,
            this.Data,
            this.TotalVenda,
            this.Acrescimo,
            this.Desconto,
            this.ModoVenda,
            this.Produtos});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendas.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvVendas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVendas.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvVendas.GridColor = System.Drawing.Color.White;
            this.dgvVendas.Location = new System.Drawing.Point(0, 190);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvVendas.RowHeadersVisible = false;
            this.dgvVendas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVendas.RowTemplate.Height = 25;
            this.dgvVendas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.ShowCellErrors = false;
            this.dgvVendas.ShowEditingIcon = false;
            this.dgvVendas.ShowRowErrors = false;
            this.dgvVendas.Size = new System.Drawing.Size(834, 355);
            this.dgvVendas.TabIndex = 95;
            this.dgvVendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCautelas_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 63;
            // 
            // TotalVenda
            // 
            this.TotalVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalVenda.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalVenda.HeaderText = "Total";
            this.TotalVenda.Name = "TotalVenda";
            this.TotalVenda.ReadOnly = true;
            this.TotalVenda.Width = 66;
            // 
            // Acrescimo
            // 
            this.Acrescimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Acrescimo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Acrescimo.HeaderText = "Acréscimo";
            this.Acrescimo.Name = "Acrescimo";
            this.Acrescimo.ReadOnly = true;
            // 
            // Desconto
            // 
            this.Desconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Desconto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Desconto.HeaderText = "Desconto";
            this.Desconto.Name = "Desconto";
            this.Desconto.ReadOnly = true;
            this.Desconto.Width = 93;
            // 
            // ModoVenda
            // 
            this.ModoVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ModoVenda.DefaultCellStyle = dataGridViewCellStyle6;
            this.ModoVenda.HeaderText = "Modo";
            this.ModoVenda.Name = "ModoVenda";
            this.ModoVenda.ReadOnly = true;
            this.ModoVenda.Width = 69;
            // 
            // Produtos
            // 
            this.Produtos.HeaderText = "Produtos";
            this.Produtos.Name = "Produtos";
            this.Produtos.ReadOnly = true;
            this.Produtos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Produtos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Produtos.Text = "Verificar";
            this.Produtos.UseColumnTextForButtonValue = true;
            // 
            // cbClientePesquisa
            // 
            this.cbClientePesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbClientePesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientePesquisa.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbClientePesquisa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbClientePesquisa.FormattingEnabled = true;
            this.cbClientePesquisa.Items.AddRange(new object[] {
            "PENDENTE",
            "PROCESSADO"});
            this.cbClientePesquisa.Location = new System.Drawing.Point(428, 103);
            this.cbClientePesquisa.Name = "cbClientePesquisa";
            this.cbClientePesquisa.Size = new System.Drawing.Size(390, 26);
            this.cbClientePesquisa.TabIndex = 108;
            this.cbClientePesquisa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbClientePesquisa_MouseDown);
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbCliente.Location = new System.Drawing.Point(428, 71);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(118, 27);
            this.rbCliente.TabIndex = 102;
            this.rbCliente.Text = "Por cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            // 
            // rbData
            // 
            this.rbData.AutoSize = true;
            this.rbData.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbData.Location = new System.Drawing.Point(18, 71);
            this.rbData.Name = "rbData";
            this.rbData.Size = new System.Drawing.Size(99, 27);
            this.rbData.TabIndex = 103;
            this.rbData.Text = "Por data";
            this.rbData.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(220, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 19);
            this.label4.TabIndex = 98;
            this.label4.Text = "e";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 99;
            this.label2.Text = "Entre";
            // 
            // dtfPicker
            // 
            this.dtfPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtfPicker.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtfPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfPicker.Location = new System.Drawing.Point(248, 105);
            this.dtfPicker.Name = "dtfPicker";
            this.dtfPicker.Size = new System.Drawing.Size(150, 24);
            this.dtfPicker.TabIndex = 96;
            this.dtfPicker.ValueChanged += new System.EventHandler(this.dtfPicker_ValueChanged);
            this.dtfPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtiPicker_MouseDown);
            // 
            // dtiPicker
            // 
            this.dtiPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtiPicker.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtiPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtiPicker.Location = new System.Drawing.Point(68, 105);
            this.dtiPicker.Name = "dtiPicker";
            this.dtiPicker.Size = new System.Drawing.Size(140, 24);
            this.dtiPicker.TabIndex = 97;
            this.dtiPicker.ValueChanged += new System.EventHandler(this.dtiPicker_ValueChanged);
            this.dtiPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtiPicker_MouseDown);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(794, 150);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(24, 24);
            this.btnUpdate.TabIndex = 110;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.Location = new System.Drawing.Point(0, 135);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(776, 54);
            this.btnPesquisar.TabIndex = 109;
            this.btnPesquisar.Text = "   Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.Location = new System.Drawing.Point(566, 543);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(268, 71);
            this.btnExcluir.TabIndex = 112;
            this.btnExcluir.Text = " Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(0, 543);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(560, 71);
            this.btnEditar.TabIndex = 111;
            this.btnEditar.Text = "  Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // ConsultaVendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 610);
            this.Controls.Add(this.dgvVendas);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.cbClientePesquisa);
            this.Controls.Add(this.rbCliente);
            this.Controls.Add(this.rbData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtfPicker);
            this.Controls.Add(this.dtiPicker);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.lblDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaVendaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Venda - Consulta de Vendas";
            this.Load += new System.EventHandler(this.ConsultaVendaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.ComboBox cbClientePesquisa;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.RadioButton rbData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtfPicker;
        private System.Windows.Forms.DateTimePicker dtiPicker;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModoVenda;
        private System.Windows.Forms.DataGridViewButtonColumn Produtos;
    }
}