using System.Diagnostics;
using System.IO;

namespace Infra.Helpers
{
    public class Clipboard
    {
        public static void SetText(string text)
        {
            ProcessStartInfo pi = new ProcessStartInfo
            {
                Arguments = text,
                FileName = Path.Combine(Directory.GetCurrentDirectory(), "ClipboardSetter.exe"),
                UseShellExecute = true,
            };

            using (Process.Start(pi)) { }
        }
    }
}
