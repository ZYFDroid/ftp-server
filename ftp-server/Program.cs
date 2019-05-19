using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public static List<Icon> FTP_ACTIVE = new List<Icon>();
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            AppIcon = Properties.Resources.icon_ftp;
            FTP_IDLE = Properties.Resources.icon_ftp_idle;

            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active1);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active2);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active3);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active4);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active5);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active6);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active7);
            FTP_ACTIVE.Add(Properties.Resources.icon_ftp_active8);

            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new FrmMain());
           
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            CurrentDomain_UnhandledException(sender, new UnhandledExceptionEventArgs(e.Exception, false));
        }
        public static void ClearExceptionState() {
            File.Delete(AppCrashFlagFile);
        }
        const string AppCrashFlagFile = "AppCrash.Flag";

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (!File.Exists(AppCrashFlagFile))
                {
                    System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    File.WriteAllText(AppCrashFlagFile, "");
                }
                else
                {
                    if (MessageBox.Show("FTP服务器发生重大错误，一个日志文件已写入应用程序根目录可供查看", "应用程序错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    }
                }
                writeException(e.ExceptionObject);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        const string CrashFileName = "crash.log";
        private static void writeException(object o) {
            if (null == o) {
                WriteAppend(CrashFileName, "Null");
                return;
            }
            if (o is Exception)
            {
                Exception ex = o as Exception;
                WriteAppend(CrashFileName, ex.ToString() + "\r\n"+ex.Message+"\r\n"+ex.StackTrace);
            }
            else {
                WriteAppend(CrashFileName, o.ToString());
            }
        }
        private static void WriteAppend(string filename, string message) {
            FileStream fs = new FileStream(CrashFileName, FileMode.Append, FileAccess.Write);
            byte[] msg = Encoding.Default.GetBytes(message+"\r\n============================================================\r\n");
            fs.Write(msg,0,msg.Length);
            fs.Close();
        }
    }
}
