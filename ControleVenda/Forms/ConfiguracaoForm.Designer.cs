
namespace ControleVenda.Forms
{
    partial class ConfiguracaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracaoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbNomeNegocio = new System.Windows.Forms.TextBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbSmsKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbPIX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tbPicPay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tbRegistros = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rbWppWeb = new System.Windows.Forms.RadioButton();
            this.rbWppDesktop = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 114;
            this.label1.Text = "Nome do Negócio:";
            this.toolTip.SetToolTip(this.label1, "O nome do seu negócio");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(149, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(271, 1);
            this.pictureBox2.TabIndex = 113;
            this.pictureBox2.TabStop = false;
            // 
            // tbNomeNegocio
            // 
            this.tbNomeNegocio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNomeNegocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNomeNegocio.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNomeNegocio.Location = new System.Drawing.Point(149, 86);
            this.tbNomeNegocio.Name = "tbNomeNegocio";
            this.tbNomeNegocio.Size = new System.Drawing.Size(271, 18);
            this.tbNomeNegocio.TabIndex = 112;
            this.toolTip.SetToolTip(this.tbNomeNegocio, "O nome do seu negócio");
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(11, 18);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(37, 34);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 116;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(446, 68);
            this.lblDescription.TabIndex = 115;
            this.lblDescription.Text = "CONFIGURAÇÕES";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 119;
            this.label2.Text = "SMS KEY:";
            this.toolTip.SetToolTip(this.label2, "A chave necessária para enviar SMS aos clientes");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(149, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 1);
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // tbSmsKey
            // 
            this.tbSmsKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSmsKey.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSmsKey.Location = new System.Drawing.Point(149, 128);
            this.tbSmsKey.Name = "tbSmsKey";
            this.tbSmsKey.Size = new System.Drawing.Size(271, 18);
            this.tbSmsKey.TabIndex = 117;
            this.toolTip.SetToolTip(this.tbSmsKey, "A chave necessária para enviar SMS aos clientes");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 122;
            this.label3.Text = "Chave PIX:";
            this.toolTip.SetToolTip(this.label3, "Sua chave PIX");
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(149, 192);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(271, 1);
            this.pictureBox3.TabIndex = 121;
            this.pictureBox3.TabStop = false;
            // 
            // tbPIX
            // 
            this.tbPIX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPIX.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPIX.Location = new System.Drawing.Point(149, 172);
            this.tbPIX.Name = "tbPIX";
            this.tbPIX.Size = new System.Drawing.Size(271, 18);
            this.tbPIX.TabIndex = 120;
            this.toolTip.SetToolTip(this.tbPIX, "Sua chave PIX");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 125;
            this.label4.Text = "PicPay:";
            this.toolTip.SetToolTip(this.label4, "Seu usuário do PicPay");
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(149, 232);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(271, 1);
            this.pictureBox4.TabIndex = 124;
            this.pictureBox4.TabStop = false;
            // 
            // tbPicPay
            // 
            this.tbPicPay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPicPay.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPicPay.Location = new System.Drawing.Point(149, 212);
            this.tbPicPay.Name = "tbPicPay";
            this.tbPicPay.Size = new System.Drawing.Size(271, 18);
            this.tbPicPay.TabIndex = 123;
            this.toolTip.SetToolTip(this.tbPicPay, "Seu usuário do PicPay");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(15, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 128;
            this.label5.Text = "Registros em tela:";
            this.toolTip.SetToolTip(this.label5, "Quantidade máxima de registros que as tabelas carregam por padrão");
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.pictureBox5.Location = new System.Drawing.Point(149, 275);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(271, 1);
            this.pictureBox5.TabIndex = 127;
            this.pictureBox5.TabStop = false;
            // 
            // tbRegistros
            // 
            this.tbRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRegistros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRegistros.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRegistros.Location = new System.Drawing.Point(149, 255);
            this.tbRegistros.Name = "tbRegistros";
            this.tbRegistros.Size = new System.Drawing.Size(271, 18);
            this.tbRegistros.TabIndex = 126;
            this.toolTip.SetToolTip(this.tbRegistros, "Quantidade máxima de registros que as tabelas carregam por padrão");
            this.tbRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRegistros_KeyPress);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(0, 325);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(446, 77);
            this.btnSalvar.TabIndex = 129;
            this.btnSalvar.Text = "   Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(16, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 132;
            this.label6.Text = "Whatsapp:";
            this.toolTip.SetToolTip(this.label6, "Quantidade máxima de registros que as tabelas carregam por padrão");
            // 
            // rbWppWeb
            // 
            this.rbWppWeb.AutoSize = true;
            this.rbWppWeb.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbWppWeb.Location = new System.Drawing.Point(149, 296);
            this.rbWppWeb.Name = "rbWppWeb";
            this.rbWppWeb.Size = new System.Drawing.Size(53, 21);
            this.rbWppWeb.TabIndex = 133;
            this.rbWppWeb.TabStop = true;
            this.rbWppWeb.Text = "Web";
            this.rbWppWeb.UseVisualStyleBackColor = true;
            // 
            // rbWppDesktop
            // 
            this.rbWppDesktop.AutoSize = true;
            this.rbWppDesktop.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbWppDesktop.Location = new System.Drawing.Point(208, 296);
            this.rbWppDesktop.Name = "rbWppDesktop";
            this.rbWppDesktop.Size = new System.Drawing.Size(77, 21);
            this.rbWppDesktop.TabIndex = 134;
            this.rbWppDesktop.TabStop = true;
            this.rbWppDesktop.Text = "Desktop";
            this.rbWppDesktop.UseVisualStyleBackColor = true;
            // 
            // ConfiguracaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(446, 402);
            this.Controls.Add(this.rbWppDesktop);
            this.Controls.Add(this.rbWppWeb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.tbRegistros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.tbPicPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbPIX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbSmsKey);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbNomeNegocio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Venda - Configuração";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfiguracaoForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfiguracaoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbNomeNegocio;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbSmsKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbPIX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tbPicPay;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox tbRegistros;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbWppWeb;
        private System.Windows.Forms.RadioButton rbWppDesktop;
    }
}