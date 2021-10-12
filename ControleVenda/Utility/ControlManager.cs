using System;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ControleVenda.Utility
{
    public class ControlManager : IDisposable
    {
        private ControlCollection _controls;

        public ControlManager(ControlCollection _control)
        {
            this._controls = _control;

            Disable(_controls);
        }

        public void Disable(ControlCollection form)
        {
            foreach (Control control in form)
            {
                control.Enabled = false;
            }
        }

        public void Enable(ControlCollection form)
        {
            foreach (Control control in form)
            {
                control.Enabled = true;
            }
        }

        public void Dispose()
        {
            Enable(_controls);
        }
    }
}
