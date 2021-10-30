
using System;

namespace ControleVenda.Forms
{
    partial class RelatorioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtiPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtfPicker = new System.Windows.Forms.DateTimePicker();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.ClienteSelecionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCheckAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAgrupamento = new System.Windows.Forms.ComboBox();
            this.cbEstadoVenda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(12, 18);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(37, 34);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 70;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(566, 68);
            this.lblDescription.TabIndex = 69;
            this.lblDescription.Text = "EMISSÃO DE RELATÓRIOS";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtiPicker
            // 
            this.dtiPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtiPicker.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtiPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtiPicker.Location = new System.Drawing.Point(137, 79);
            this.dtiPicker.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtiPicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtiPicker.Name = "dtiPicker";
            this.dtiPicker.Size = new System.Drawing.Size(399, 24);
            this.dtiPicker.TabIndex = 99;
            this.dtiPicker.Value = DateTime.Today.AddMonths(-1);
            this.dtiPicker.ValueChanged += new System.EventHandler(this.dtiPicker_ValueChanged);            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 100;
            this.label1.Text = "Data Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 102;
            this.label2.Text = "Data Final:";
            // 
            // dtfPicker
            // 
            this.dtfPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtfPicker.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtfPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfPicker.Location = new System.Drawing.Point(137, 120);
            this.dtfPicker.Name = "dtfPicker";            
            this.dtfPicker.Size = new System.Drawing.Size(399, 24);
            this.dtfPicker.TabIndex = 101;
            this.dtfPicker.Value = DateTime.Today;
            this.dtfPicker.ValueChanged += new System.EventHandler(this.dtfPicker_ValueChanged);
            // 
            // btnEmitir
            // 
            this.btnEmitir.BackColor = System.Drawing.Color.White;
            this.btnEmitir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEmitir.FlatAppearance.BorderSize = 0;
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitir.Font = new System.Drawing.Font("Roboto", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEmitir.Image = ((System.Drawing.Image)(resources.GetObject("btnEmitir.Image")));
            this.btnEmitir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmitir.Location = new System.Drawing.Point(0, 595);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(566, 53);
            this.btnEmitir.TabIndex = 110;
            this.btnEmitir.Text = "   Emitir Relatório";
            this.btnEmitir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmitir.UseVisualStyleBackColor = false;
            this.btnEmitir.Click += async (obj, e) => await this.btnEmitir_Click(obj, e);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClienteSelecionado,
            this.Identificador,
            this.Nome,
            this.Telefone});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvClientes.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvClientes.GridColor = System.Drawing.Color.White;
            this.dgvClientes.Location = new System.Drawing.Point(0, 244);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvClientes.RowTemplate.Height = 25;
            this.dgvClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.ShowCellErrors = false;
            this.dgvClientes.ShowEditingIcon = false;
            this.dgvClientes.ShowRowErrors = false;
            this.dgvClientes.Size = new System.Drawing.Size(566, 351);
            this.dgvClientes.TabIndex = 111;
            // 
            // ClienteSelecionado
            // 
            this.ClienteSelecionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClienteSelecionado.HeaderText = "";
            this.ClienteSelecionado.Name = "ClienteSelecionado";
            this.ClienteSelecionado.Width = 5;
            // 
            // Identificador
            // 
            this.Identificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Identificador.HeaderText = "Identificador";
            this.Identificador.Name = "Identificador";
            this.Identificador.ReadOnly = true;
            this.Identificador.Width = 120;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Telefone
            // 
            this.Telefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            this.Telefone.Width = 91;
            // 
            // cbCheckAll
            // 
            this.cbCheckAll.AutoSize = true;
            this.cbCheckAll.BackColor = System.Drawing.Color.Transparent;
            this.cbCheckAll.Location = new System.Drawing.Point(3, 251);
            this.cbCheckAll.Name = "cbCheckAll";
            this.cbCheckAll.Size = new System.Drawing.Size(15, 14);
            this.cbCheckAll.TabIndex = 113;
            this.cbCheckAll.UseVisualStyleBackColor = false;
            this.cbCheckAll.CheckedChanged += new System.EventHandler(this.cbCheckAll_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 114;
            this.label4.Text = "Agrupamento:";
            // 
            // cbAgrupamento
            // 
            this.cbAgrupamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAgrupamento.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbAgrupamento.FormattingEnabled = true;
            this.cbAgrupamento.Items.AddRange(new object[] {
            "Data",
            "Cliente"});
            this.cbAgrupamento.Location = new System.Drawing.Point(137, 159);
            this.cbAgrupamento.Name = "cbAgrupamento";
            this.cbAgrupamento.Size = new System.Drawing.Size(399, 23);
            this.cbAgrupamento.TabIndex = 115;
            // 
            // cbEstadoVenda
            // 
            this.cbEstadoVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoVenda.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbEstadoVenda.FormattingEnabled = true;
            this.cbEstadoVenda.Items.AddRange(new object[] {
            "Todos",
            "Pago",
            "Pendente"});
            this.cbEstadoVenda.Location = new System.Drawing.Point(137, 195);
            this.cbEstadoVenda.Name = "cbEstadoVenda";
            this.cbEstadoVenda.Size = new System.Drawing.Size(399, 23);
            this.cbEstadoVenda.TabIndex = 117;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 116;
            this.label3.Text = "Estado:";
            // 
            // RelatorioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 648);
            this.Controls.Add(this.cbEstadoVenda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAgrupamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCheckAll);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtfPicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtiPicker);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatorioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Venda - Relatórios";
            this.Load += async (obj, e) => await this.RelatorioForm_Load(obj, e);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtiPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtfPicker;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.CheckBox cbCheckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClienteSelecionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAgrupamento;
        private System.Windows.Forms.ComboBox cbEstadoVenda;
        private System.Windows.Forms.Label label3;
    }
}