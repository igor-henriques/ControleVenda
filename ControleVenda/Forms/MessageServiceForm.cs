using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class MessageServiceForm : Form
    {
        public readonly ISMSRepository _smsContext;
        public MessageServiceForm(ISMSRepository smsContext)
        {
            InitializeComponent();

            this._smsContext = smsContext;
        }
        public async Task FillGrid(List<SMS> sms = null)
        {
            sms = sms ?? await _smsContext.Get();

            if (sms != null)
            {
                dgvSms.Rows.Clear();

                sms.ForEach(sms => dgvSms.Rows.Add(new object[]
                {
                    sms.Id,
                    sms.Situacao,
                    sms.TelefoneDestino,
                    sms.Descricao,
                    sms.Mensagem.Substring(0, 20) + "...",
                    CreateGridButton()
                }));
            }
        }
        private DataGridViewButtonCell CreateGridButton()
        {
            DataGridViewButtonCell dgvButton = new DataGridViewButtonCell();

            dgvButton.Value = "Re-enviar";
            dgvButton.UseColumnTextForButtonValue = true;
            dgvButton.FlatStyle = FlatStyle.Flat;

            return dgvButton;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = "https://www.smsdev.com.br/definicao-de-precos/"
            });
        }

        private async void MessageServiceForm_Load(object sender, EventArgs e)
        {
            using (new ControlManager(this.Controls))
            {
                this.lblSaldo.Text = $"{_smsContext.GetSaldo().SaldoSMS} SMS";

                await FillGrid();
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
