using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftp_server
{
    class Program
    {
        public static Icon AppIcon;
        [STAThread]
        static void Main(string[] args)
        {
            System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new FrmMain());
        }
    }
}
