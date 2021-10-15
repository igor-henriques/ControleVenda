
namespace ControleVenda.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormMenu = new System.Windows.Forms.MenuStrip();
            this.VendaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultaVendaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClienteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProdutoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RelatorioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.DateDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.DateStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LogsDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.LogsStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LogsUpdateDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.LogsUpdateCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.oneSecond = new System.Windows.Forms.Timer(this.components);
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SmsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // MainFormMenu
            // 
            this.MainFormMenu.BackColor = System.Drawing.Color.White;
            this.MainFormMenu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MainFormMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainFormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VendaMenuItem,
            this.ConsultaVendaMenuItem,
            this.ClienteMenuItem,
            this.ProdutoMenuItem,
            this.RelatorioMenuItem,
            this.SmsMenuItem});
            this.MainFormMenu.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenu.Name = "MainFormMenu";
            this.MainFormMenu.Size = new System.Drawing.Size(1350, 26);
            this.MainFormMenu.TabIndex = 2;
            this.MainFormMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainFormMenu_ItemClicked);
            // 
            // VendaMenuItem
            // 
            this.VendaMenuItem.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.VendaMenuItem.ForeColor = System.Drawing.Color.Black;
            this.VendaMenuItem.Image = global::ControleVenda.Properties.Resources.shopping_bag;
            this.VendaMenuItem.Name = "VendaMenuItem";
            this.VendaMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.VendaMenuItem.Size = new System.Drawing.Size(148, 22);
            this.VendaMenuItem.Tag = "Venda";
            this.VendaMenuItem.Text = "LANÇAR VENDA";
            // 
            // ConsultaVendaMenuItem
            // 
            this.ConsultaVendaMenuItem.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ConsultaVendaMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ConsultaVendaMenuItem.Image = global::ControleVenda.Properties.Resources.search__1_;
            this.ConsultaVendaMenuItem.Name = "ConsultaVendaMenuItem";
            this.ConsultaVendaMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ConsultaVendaMenuItem.Tag = "ConsultaVenda";
            this.ConsultaVendaMenuItem.Text = "CONSULTAR VENDA";
            // 
            // ClienteMenuItem
            // 
            this.ClienteMenuItem.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ClienteMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ClienteMenuItem.Image = global::ControleVenda.Properties.Resources.people;
            this.ClienteMenuItem.Name = "ClienteMenuItem";
            this.ClienteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ClienteMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ClienteMenuItem.Tag = "Cliente";
            this.ClienteMenuItem.Text = "CLIENTE";
            // 
            // ProdutoMenuItem
            // 
            this.ProdutoMenuItem.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ProdutoMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ProdutoMenuItem.Image = global::ControleVenda.Properties.Resources.burger;
            this.ProdutoMenuItem.Name = "ProdutoMenuItem";
            this.ProdutoMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.ProdutoMenuItem.Size = new System.Drawing.Size(105, 22);
            this.ProdutoMenuItem.Tag = "Produto";
            this.ProdutoMenuItem.Text = "PRODUTO";
            // 
            // RelatorioMenuItem
            // 
            this.RelatorioMenuItem.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RelatorioMenuItem.ForeColor = System.Drawing.Color.Black;
            this.RelatorioMenuItem.Image = global::ControleVenda.Properties.Resources.report;
            this.RelatorioMenuItem.Name = "RelatorioMenuItem";
            this.RelatorioMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.RelatorioMenuItem.Size = new System.Drawing.Size(114, 22);
            this.RelatorioMenuItem.Tag = "Relatorio";
            this.RelatorioMenuItem.Text = "RELATÓRIO";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DateDesc,
            this.DateStatus,
            this.lblSeparator,
            this.TimeDesc,
            this.TimeStatus,
            this.lblSeparator2,
            this.LogsDesc,
            this.LogsStatusCount,
            this.toolStripStatusLabel1,
            this.LogsUpdateDesc,
            this.LogsUpdateCount,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 701);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 44;
            this.statusStrip.Text = "statusStrip";
            // 
            // DateDesc
            // 
            this.DateDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateDesc.ForeColor = System.Drawing.Color.Black;
            this.DateDesc.Name = "DateDesc";
            this.DateDesc.Size = new System.Drawing.Size(37, 17);
            this.DateDesc.Text = "Data";
            // 
            // DateStatus
            // 
            this.DateStatus.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateStatus.ForeColor = System.Drawing.Color.Black;
            this.DateStatus.Name = "DateStatus";
            this.DateStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSeparator
            // 
            this.lblSeparator.ForeColor = System.Drawing.Color.Black;
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(17, 17);
            this.lblSeparator.Text = " | ";
            // 
            // TimeDesc
            // 
            this.TimeDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeDesc.ForeColor = System.Drawing.Color.Black;
            this.TimeDesc.Name = "TimeDesc";
            this.TimeDesc.Size = new System.Drawing.Size(38, 17);
            this.TimeDesc.Text = "Hora";
            // 
            // TimeStatus
            // 
            this.TimeStatus.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimeStatus.ForeColor = System.Drawing.Color.Black;
            this.TimeStatus.Name = "TimeStatus";
            this.TimeStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.ForeColor = System.Drawing.Color.Black;
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(17, 17);
            this.lblSeparator2.Text = " | ";
            // 
            // LogsDesc
            // 
            this.LogsDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LogsDesc.ForeColor = System.Drawing.Color.Black;
            this.LogsDesc.Name = "LogsDesc";
            this.LogsDesc.Size = new System.Drawing.Size(37, 17);
            this.LogsDesc.Text = "Logs";
            // 
            // LogsStatusCount
            // 
            this.LogsStatusCount.ForeColor = System.Drawing.Color.Black;
            this.LogsStatusCount.Name = "LogsStatusCount";
            this.LogsStatusCount.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // LogsUpdateDesc
            // 
            this.LogsUpdateDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LogsUpdateDesc.ForeColor = System.Drawing.Color.Black;
            this.LogsUpdateDesc.Name = "LogsUpdateDesc";
            this.LogsUpdateDesc.Size = new System.Drawing.Size(137, 17);
            this.LogsUpdateDesc.Text = "Atualizando logs em";
            // 
            // LogsUpdateCount
            // 
            this.LogsUpdateCount.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogsUpdateCount.ForeColor = System.Drawing.Color.Black;
            this.LogsUpdateCount.Name = "LogsUpdateCount";
            this.LogsUpdateCount.Size = new System.Drawing.Size(22, 17);
            this.LogsUpdateCount.Text = "61";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel2.Text = "segundos";
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(0, 26);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(1350, 98);
            this.lblDescription.TabIndex = 46;
            this.lblDescription.Text = "MOVIMENTOS DO DIA 00/00/0000";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oneSecond
            // 
            this.oneSecond.Enabled = true;
            this.oneSecond.Interval = 1000;
            this.oneSecond.Tick += new System.EventHandler(this.oneSecond_Tick);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMain.GridColor = System.Drawing.Color.White;
            this.dgvMain.Location = new System.Drawing.Point(0, 127);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMain.RowTemplate.Height = 25;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(1350, 545);
            this.dgvMain.TabIndex = 47;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(9, 679);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSearch.Location = new System.Drawing.Point(35, 678);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderText = "Pesquisar";
            this.tbSearch.Size = new System.Drawing.Size(1264, 20);
            this.tbSearch.TabIndex = 49;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.Black;
            this.pictureBox6.Location = new System.Drawing.Point(35, 699);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1264, 1);
            this.pictureBox6.TabIndex = 50;
            this.pictureBox6.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(1314, 681);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(20, 20);
            this.btnUpdate.TabIndex = 48;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // SmsMenuItem
            // 
            this.SmsMenuItem.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.SmsMenuItem.ForeColor = System.Drawing.Color.Black;
            this.SmsMenuItem.Image = global::ControleVenda.Properties.Resources.sms;
            this.SmsMenuItem.Name = "SmsMenuItem";
            this.SmsMenuItem.Size = new System.Drawing.Size(67, 22);
            this.SmsMenuItem.Tag = "SMS";
            this.SmsMenuItem.Text = "SMS";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 723);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.MainFormMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Venda - Principal";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.MainFormMenu.ResumeLayout(false);
            this.MainFormMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainFormMenu;
        private System.Windows.Forms.ToolStripMenuItem VendaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClienteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProdutoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RelatorioMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel DateDesc;
        private System.Windows.Forms.ToolStripStatusLabel DateStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator;
        private System.Windows.Forms.ToolStripStatusLabel TimeDesc;
        private System.Windows.Forms.ToolStripStatusLabel TimeStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel LogsDesc;
        private System.Windows.Forms.ToolStripStatusLabel LogsStatusCount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Timer oneSecond;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem ConsultaVendaMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LogsUpdateDesc;
        private System.Windows.Forms.ToolStripStatusLabel LogsUpdateCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem SmsMenuItem;
    }
}

