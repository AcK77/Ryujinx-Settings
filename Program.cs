using System;
using System.Windows.Forms;

namespace Ryujinx_Settings
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConfig());
        }
    }
}
