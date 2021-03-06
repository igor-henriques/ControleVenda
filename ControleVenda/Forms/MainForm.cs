using ControleVenda.Forms.Utility;
using ControleVenda.Utility;
using Domain.Interfaces;
using Infra.Helpers;
using Infra.Models;
using Infra.Models.Table;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class MainForm : Form
    {
        private readonly FormSelector _selector;
        private readonly ILogRepository _logContext;
        private readonly Settings _settings;
        public MainForm(FormSelector selector, ILogRepository logContext, Settings settings)
        {
            InitializeComponent();

            this._selector = selector;
            this._logContext = logContext;
            this._settings = settings;

            BuildStatusBar();
        }

        private async void MainFormMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_settings.NomeNegocio) && e.ClickedItem.Tag.ToString() != "Configuracao")
                {
                    MessageBox.Show("Configure a aplicação no menu Configuração antes de utilizar o programa.", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(e.ClickedItem.Tag.ToString()))
                {
                    Form selectedForm = null;

                    using (new ControlManager(this.Controls))
                    {
                        await Task.Run(() =>
                        {
                            selectedForm = _selector.GetForm($"{e.ClickedItem.Tag}");
                        });
                    }

                    if (IsFormOpened(selectedForm, out Form currentForm) & selectedForm.Name != "VendaForm")
                    {
                        currentForm?.Activate();
                    }
                    else
                    {
                        selectedForm?.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(ex.ToString());
            }
        }
        private bool IsFormOpened(Form currentForm, out Form outForm)
        {
            outForm = null;

            foreach (Form form in Application.OpenForms)
            {
                if (currentForm != null && form.Name.Equals(currentForm.Name))
                {
                    outForm = form;

                    return true;
                }
            }

            return false;
        }
        private void BuildStatusBar()
        {
            lblDescription.Text = $"MOVIMENTOS DO DIA {DateTime.Today.ToString("dd/MM/yyyy")}";
            DateStatus.Text = DateTime.Now.ToLongDateString();
            TimeStatus.Text = DateTime.Now.ToLongTimeString();
        }

        private async void oneSecond_Tick(object sender, EventArgs e)
        {
            TimeStatus.Text = DateTime.Now.ToLongTimeString();

            int currentLogUpdateCount = int.Parse(LogsUpdateCount.Text) - 1;

            if (currentLogUpdateCount < 0)
            {
                await FillGrid();
                LogsUpdateCount.Text = "60";
            }
            else
            {
                LogsUpdateCount.Text = currentLogUpdateCount.ToString();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                Application.Restart();
                Process.GetCurrentProcess().Kill();
            }

            if (MessageBox.Show("Tem certeza que deseja sair?", "Saindo", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
            {
                e.Cancel = true;
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await FillGrid();
        }
        private async Task FillGrid(List<Log> logs = null)
        {
            using (new ControlManager(this.Controls))
            {
                logs = logs ?? await _logContext.Get();

                if (logs != null)
                {
                    dgvMain.DataSource = logs;
                    FormatColumns();
                }
            }
        }
        private void FormatColumns()
        {
            dgvMain.Columns["Id"].Visible = false;
            dgvMain.Columns["Date"].HeaderText = "Data";
            dgvMain.Columns["Description"].HeaderText = "Descrição";

            dgvMain.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMain.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvMain.RowCount; i++)
            {

                if (i % 2 == 0)
                {
                    dgvMain.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvMain.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dgvMain.ClearSelection();
            LogsStatusCount.Text = dgvMain.RowCount.ToString();
        }

        private async void MainForm_Activated(object sender, EventArgs e)
        {
            //await FillGrid();
        }

        private async void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                    if (tbSearch.Text.Trim() != string.Empty)
                    {
                        var searchResult = await _logContext.Search(tbSearch.Text);

                        await FillGrid(searchResult);

                        if (dgvMain.RowCount > 0)
                            dgvMain.Rows[dgvMain.Rows.Count - 1].Selected = true;
                    }
                    else
                    {
                        btnUpdate.PerformClick();
                    }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await FillGrid();
        }
    }
}