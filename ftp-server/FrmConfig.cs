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
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }
        
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            try { numPort.Value = FtpServer.Port; } catch { }
            try { numUserLimit.Value = FtpServer.MaxUserCount; } catch { }
            try { txtEncoding.Text = FtpServer.Encodings; } catch { }
            try { numFileSizeLimit.Value = FtpServer.limitedFileSizeMB; } catch { }
            try { numTransferBufferSize.Value = FtpServer.transferBufferSize; } catch { }

            try { chkNocheckUn.Checked = !Login.CheckUser; } catch { }
            try { numLoginDelay.Value = Login.AuthDelayTime; } catch { }

            try { chkAllowFakeUser.Checked = Login.AllowFakeUser; } catch { }
            try { numFakeUserTrigger.Value = Login.FakeUserTrigger; } catch { }

            try { numUnloginTimeout.Value = FtpServer.UnloginedTimeout; } catch { }
            try { numInactiveTimeout.Value = FtpServer.DisconnectInactiveTimeout; } catch { }

            try { chkSmartBanIp.Checked = FtpServer.enableSmartBanIp; } catch { }
            try { numBanIpTrigger.Value = FtpServer.BanIpTrigger; } catch { }
            try { numBanIpTime.Value = FtpServer.BanIpDuration; } catch { }

            try { numLogCount.Value = FrmMain.maxlog; } catch { }
            try { chkWriteLog.Checked = FrmMain.WriteLogToFile; } catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FtpServer.Port = (int)numPort.Value;
            FtpServer.MaxUserCount = (int)numUserLimit.Value;
            FtpServer.Encodings = txtEncoding.Text;
            FtpServer.limitedFileSizeMB = (int)numFileSizeLimit.Value;
            FtpServer.transferBufferSize = (int)numTransferBufferSize.Value;

            Login.CheckUser = !chkNocheckUn.Checked;
            Login.AuthDelayTime = (int)numLoginDelay.Value;

            Login.AllowFakeUser = chkAllowFakeUser.Checked;
            Login.FakeUserTrigger = (int)numFakeUserTrigger.Value;

            FtpServer.UnloginedTimeout = (int)numUnloginTimeout.Value;
            FtpServer.DisconnectInactiveTimeout = (int)numInactiveTimeout.Value;

            FtpServer.enableSmartBanIp = chkSmartBanIp.Checked;
            FtpServer.BanIpTrigger = (int)numBanIpTrigger.Value;
            FtpServer.BanIpDuration = (int)numBanIpTime.Value;

            FrmMain.maxlog = (int)numLogCount.Value;
            FrmMain.WriteLogToFile = chkWriteLog.Checked;

            try
            {
                Configuration.PutConfigurations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法保存配置:\r\n" + ex.Message, "保存失败");
            }
            finally
            {
                MessageBox.Show("配置保存成功.", "保存配置");
                DialogResult = DialogResult.OK;
            }
        }
    }
}
