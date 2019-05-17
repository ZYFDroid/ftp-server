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
        public static Icon FTP_IDLE;
        public static Icon FTP_ACTIVE1;
        public static Icon FTP_ACTIVE2;
        [STAThread]
        static void Main(string[] args)
        {
            System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            AppIcon = Properties.Resources.icon_ftp;
            FTP_IDLE = Properties.Resources.icon_ftp_idle;
            FTP_ACTIVE1 = Properties.Resources.icon_ftp_active2;
            FTP_ACTIVE2 = Properties.Resources.icon_ftp_active1;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new FrmMain());
        }
    }
}
