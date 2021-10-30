using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClipboardSetter
{
    public class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
                Clipboard.SetText(string.Join(" ", args));

            Process.GetCurrentProcess().Kill();
        }
    }
}
