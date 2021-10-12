using ControleVenda.Forms.Utility;
using ControleVenda.Utility;
using Infra.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda.Forms
{
    public partial class MainForm : Form
    {
        private readonly FormSelector _selector;
        public MainForm(FormSelector selector)
        {
            InitializeComponent();

            this._selector = selector;
            BuildStatusBar();
        }

        private async void MainFormMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Form selectedForm = null;

                using (new ControlManager(this.Controls))
                {                    
                    await Task.Run(() =>
                    {
                        selectedForm = _selector.GetForm($"{e.ClickedItem.Tag}");
                    });
                }


                if (IsFormOpened(selectedForm, out Form currentForm) != null)
                {
                    currentForm?.Activate();
                }
                else
                {
                    selectedForm?.Show();
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex.ToString());
                throw;
            }
        }
        private Form IsFormOpened(Form currentForm, out Form outForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals(currentForm.Name))
                {
                    outForm = form;

                    return form;
                }
            }

            outForm = null;

            return null;
        }
        private void BuildStatusBar()
        {
            lblDescription.Text = $"VENDAS DO DIA {DateTime.Today.ToString("dd/MM/yyyy")}";
            DateStatus.Text = DateTime.Now.ToLongDateString();
            TimeStatus.Text = DateTime.Now.ToLongTimeString();
        }

        private void oneSecond_Tick(object sender, EventArgs e)
        {
            TimeStatus.Text = DateTime.Now.ToLongTimeString();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Saindo", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
            {
                e.Cancel = true;
            }
        }
    }
}
