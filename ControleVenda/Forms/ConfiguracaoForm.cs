using Infra.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class ConfiguracaoForm : Form
    {
        public ConfiguracaoForm()
        {
            InitializeComponent();
        }

        private void ConfiguracaoForm_Load(object sender, EventArgs e)
        {
            var settings = new Settings();

            if (settings != null)
            {
                tbNomeNegocio.Text = settings.NomeNegocio;
                tbPicPay.Text = settings.PicPay;
                tbPIX.Text = settings.PIX;
                tbSmsKey.Text = settings.Key;
                tbRegistros.Text = settings.RegistrosEmTabela.ToString();
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                MessageBox.Show("Preencha todos os campos antes de retornar", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Close();
        }

        /// <summary>
        /// Retorna true caso haja algum textbox vazio
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            foreach (Control control in this.Controls)
            {
                if (!control.Name.Contains("tb"))
                    continue;

                if (control.Text.Trim().Length <= 0)
                    return true;
            }

            return false;
        }

        private void ConfiguracaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckFields())
            {
                MessageBox.Show("Preencha todos os campos antes de retornar", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                MessageBox.Show("Preencha todos os campos antes de salvar", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var config = new Settings() with
            {
                Key = tbSmsKey.Text,
                NomeNegocio = tbNomeNegocio.Text,
                PicPay = tbPicPay.Text,
                PIX = tbPIX.Text,
                RegistrosEmTabela = int.Parse(tbRegistros.Text)
            };

            await File.WriteAllTextAsync("./Configuração.json", JsonConvert.SerializeObject(config));

            MessageBox.Show("Configurações salvas. Reiniciando a aplicação.", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Restart();
        }
        private void tbRegistros_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;

            if ((!ch.Equals((char)Keys.Back)) && (!char.IsDigit(ch) || !int.TryParse(tbRegistros.Text.Trim() + ch, out _)))
            {
                e.Handled = true;
            }
        }
    }
}