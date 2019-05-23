using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftp_server
{
    public partial class FrmMain : Form
    {

        public static bool WriteLogToFile = false;

        public FrmMain()
        {
            InitializeComponent();
        }
        FtpServer ftpserver;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ftpserver = new FtpServer();
            Configuration.instance = ftpserver;
            logmethod = new LogText(onLog);
            ftpserver.OnConsoleWriteLine += Ftpserver_OnConsoleWriteLine;
            onLog("Load Configurations:\r\n"+Configuration.InterpreteConfigurations(Configuration.GetConfigurations()));
            System.Net.Sockets.SocketError code;
            if (!ftpserver.Start(out code)) {
                switch (code){
                    case System.Net.Sockets.SocketError.AddressAlreadyInUse:
                        MessageBox.Show("当前的FTP端口已被占用，请检查是否有已开启的FTP服务器，或者更换端口号后重启服务器。", "开启服务器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("无法开启服务器，请检查日志", "开启服务器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            btnNewUser.Enabled = true;
            loadUserList();
            if (WriteLogToFile)
            {
                String logpath = Path.GetFullPath(string.Format("ftptrace-{0:yyyy\\-MM\\-dd\\-HH\\-mm\\-ss\\-fff}.log", DateTime.Now));
                logFileStream = new FileStream(logpath, FileMode.Append, FileAccess.Write);
                foreach (String before in logs) {
                    writeLogLine(before);
                }
            }
        }

        FileStream logFileStream;

        private void writeLogLine(String line) {
            if (WriteLogToFile && null != logFileStream) {
                byte[] b = Encoding.Default.GetBytes(line+"\r\n");
                logFileStream.Write(b, 0, b.Length);
                logFileStream.Flush();
            }
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

        public static int maxlog = 160;
        List<string> logs = new List<string>();

        private void onLog(string log) {
            log = string.Format("[{0:yy\\-MM\\-dd\\ HH\\:mm\\:ss}] {1}", DateTime.Now, log);
            logs.Add(log);
            if (logs.Count > maxlog / 2 * 3)
            {
                while (logs.Count > maxlog) { logs.RemoveAt(0); }
            }
            logText.AppendText(log + "\r\n");
            writeLogLine(log);
            if (logText.Lines.Length > 2 * maxlog) { logText.Lines = logs.ToArray(); logText.AppendText("\r\n"); }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason==CloseReason.TaskManagerClosing) {
                fullExit();
                return;
            }
            if (MessageBox.Show("是否退出服务器?\r\n您的配置将会保存", "是否退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes) {
                fullExit();
            }
            e.Cancel = true;
        }

        private void fullExit() {
            Configuration.PutConfigurations();
            notifyIcon.Icon = null;
            notifyIcon.Visible = false;
            ftpserver.Dispose();
            if (null != logFileStream)
            {
                logFileStream.Close();
                logFileStream.Dispose();
            }
            Program.ClearExceptionState();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        int iconframe = 0;
        private void infoUpdateTimer_Tick(object sender, EventArgs e)
        {
            int userCount= ftpserver.UserCount;
            lblUserCount.Text = "在线人数：" + userCount;
            if (userCount > 0)
            {
                notifyIcon.Icon = Program.FTP_ACTIVE[iconframe];
                iconframe++;
                if (iconframe >= Program.FTP_ACTIVE.Count) {
                    iconframe = 0;
                } 
            }
            else {
                notifyIcon.Icon = Program.FTP_IDLE;
            }
            if (hideCd >= 0) {
                hideCd--; if (hideCd < 0) {
                    this.ShowInTaskbar=!(this.WindowState == FormWindowState.Minimized) ;
                }
            }
            if (showCd >= 0)
            {
                showCd--; if (showCd < 0)
                {
                    this.WindowState = FormWindowState.Normal ;
                }
            }
        }

        private string oldSelectedUser = "";
        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUser.SelectedIndex < 0)
            {
                userEditBox.Enabled = false;
            }
            else
            {
                userEditBox.Enabled = true;
                User user = Login.userList[listUser.SelectedItem.ToString()];
                txtUn.Text = user.Username;
                txtPw.Text = user.Password;
                txtPath.Text = user.Root;
                chkPermRead.Checked = user.CanRead;
                chkPermWrite.Checked = user.CanWrite;
                chkPermDelete.Checked = user.CanDelete;
                chkPermList.Checked = user.CanList;
                oldSelectedUser = user.Username;
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!Directory.Exists(txtPath.Text))
                {
                    Directory.CreateDirectory(txtPath.Text);
                }
            }
            catch {
                MessageBox.Show("无效的根目录:\r\n"+txtPath.Text, "无效根目录");
                return;
            }
            if (txtUn.Text.Length < 1) {
                MessageBox.Show("用户名不能为空", "无效输入");
                return;
            }
            Login.userList.Remove(oldSelectedUser);
            User user = new User(
                txtUn.Text,
                txtPw.Text,
                "",
                txtPath.Text, true
                );
            user.CanRead = chkPermRead.Checked;
            user.CanWrite = chkPermWrite.Checked;
            user.CanDelete = chkPermDelete.Checked;
            user.CanList = chkPermList.Checked;
            Login.AddUser(user);
            loadUserList();
        }

        private void btnAnonymous_Click(object sender, EventArgs e)
        {
            txtUn.Text = "anonymous";
            txtPw.Text = "";
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除用户:"+oldSelectedUser, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Login.userList.Remove(oldSelectedUser);
                loadUserList();
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            string un = "user"+SysClock.Mill;
            Login.AddUser(new User(un, "password", "lr", Path.GetFullPath("." + Path.DirectorySeparatorChar + "FtpDir"), true));
            loadUserList();
            listUser.SelectedItem = un;
        }

        private void loadUserList() {
            listUser.ClearSelected();
            listUser.Items.Clear();
            listUser.Items.AddRange(Login.userList.Keys.ToArray());
        }

        private void btnChooseRoot_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                txtPath.Text= folderBrowserDialog.SelectedPath;
            }
        }

        private void btnKickAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否断开所有用户? 如果有用户正在传输数据,则用户的数据可能会丢失.", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ftpserver.KickAll();
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration.PutConfigurations();
            }
            catch (Exception ex) {
                MessageBox.Show("无法保存配置:\r\n"+ex.Message, "保存失败");
            }
            finally
            {
                MessageBox.Show("配置保存成功.", "保存配置");
            }
            
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.FrmMain_FormClosing(sender, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog(this);
        }

        private void btnCancelSave_Click(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        int showCd = -1;
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            showCd = 1;
            ShowInTaskbar = true;
        }
        int hideCd = -1;
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                hideCd = 1;
            }
            else {
                ShowInTaskbar = true;
            }
        }

        private void trayMnuExit_Click(object sender, EventArgs e)
        {
            this.FrmMain_FormClosing(sender, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
        }

        private void trayMnuMain_Click(object sender, EventArgs e)
        {
            notifyIcon_DoubleClick(sender, e);
        }

        private void testexceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new InvalidOperationException();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmConfig().ShowDialog();
        }
    }
}
