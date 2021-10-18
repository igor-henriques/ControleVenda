using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models.Enum;
using Infra.Models.Table;
using Infra.SMS.Request;
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
                    sms.Cliente.Telefone,
                    sms.Descricao,
                    sms.Mensagem.Substring(0, 20) + "...",
                    CreateGridButton()
                }));
            }

            dgvSms.ClearSelection();
        }
        private async void dgvSms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (dgvSms.RowCount > 0 && e.RowIndex >= 0)
                {
                    long idSms = (long)senderGrid.SelectedRows[0].Cells["Id"].Value;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        await RetrySendSMS(idSms);
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task RetrySendSMS(long id)
        {
            ReloadSaldo();

            if (lblSaldo.Text.Equals("0"))
            {
                MessageBox.Show("Não há saldo de SMS para realizar a operação. Considere realizar uma recarga clicando no botão inferior.", "Re-envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (new ControlManager(this.Controls))
            {
                var responseSituacao = _smsContext.CheckSituationSMS(new RequestSituacaoSMS()
                {
                    Id = id.ToString()
                });                                

                var dbSms = await _smsContext.Get(id);
                
                if (responseSituacao.Situacao.Equals(ESituacaoResponseSMS.OK))
                {
                    MessageBox.Show("A mensagem atual já foi entregue ao cliente.", "Re-envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await _smsContext.Update(dbSms with
                    {
                        Descricao = responseSituacao.Descricao,
                        Situacao = responseSituacao.Situacao,
                        Codigo = responseSituacao.Codigo
                    });

                    await _smsContext.Save();

                    await FillGrid();

                    return;
                }

                var sms = new RequestSendSMS()
                {
                    Type = 9,
                    Msg = dbSms.Mensagem,
                    Number = dbSms.Cliente.Telefone,
                };

                var responseSMS = _smsContext.SendSMS(sms);

                await _smsContext.Update(new SMS
                {
                    Id = responseSMS.Id,
                    Situacao = responseSMS.Situacao,
                    IdCliente = dbSms.IdCliente,
                    Mensagem = sms.Msg,
                    Codigo = responseSMS.Codigo,
                    Descricao = responseSMS.Descricao
                });
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                ReloadSaldo();
                MessageBox.Show("SMS atualizado", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void MessageServiceForm_Load(object sender, EventArgs e)
        {
            using (new ControlManager(this.Controls))
            {
                ReloadSaldo();

                await FillGrid();
            }
        }
        private void ReloadSaldo()
        {
            this.lblSaldo.Text = $"{_smsContext.GetSaldo().SaldoSMS}";
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
