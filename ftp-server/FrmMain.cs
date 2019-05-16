using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftp_server
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        FtpServer ftpserver;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ftpserver = new FtpServer(21);
            Login.AddUser(new User("anonymous", "", "lr", "D:\\新智能家居"));
            Login.AddUser(new User("bizideal", "uploader", "lrw", "D:\\新智能家居"));
            logmethod = new LogText(onLog);
            ftpserver.OnConsoleWriteLine += Ftpserver_OnConsoleWriteLine;
            ftpserver.Start();
        }

        delegate void LogText(String s);
        LogText logmethod;
        private void Ftpserver_OnConsoleWriteLine(object sender, string e)
        {
            if (logText.InvokeRequired)
            {
                logText.Invoke(logmethod,e);
            }
            else {
                onLog(e);
            }
        }

        int maxlog = 480;
        List<string> logs = new List<string>();

        private void onLog(string log) {
            logs.Add(log);
            while (logs.Count > maxlog) { logs.RemoveAt(0); }
            logText.AppendText(log + "\r\n");
            if (logText.Lines.Length > 2 * maxlog) { logText.Lines = logs.ToArray(); logText.AppendText("\r\n"); }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出服务器", "是否退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes) {
                ftpserver.Dispose();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            e.Cancel = true;
        }

        private void infoUpdateTimer_Tick(object sender, EventArgs e)
        {
            lblUserCount.Text = "在线人数：" + ftpserver.UserCount;
        }
    }
}
