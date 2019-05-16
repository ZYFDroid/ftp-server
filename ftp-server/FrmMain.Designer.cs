namespace ftp_server
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.logText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPermList = new System.Windows.Forms.CheckBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listUser = new System.Windows.Forms.ListBox();
            this.infoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.chkPermRead = new System.Windows.Forms.CheckBox();
            this.chkPermWrite = new System.Windows.Forms.CheckBox();
            this.chkPermDelete = new System.Windows.Forms.CheckBox();
            this.btnAnonymous = new System.Windows.Forms.Button();
            this.btnChooseRoot = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnDelUser = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.valMaxUser = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnKickAll = new System.Windows.Forms.Button();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出配置信息EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入配置信息IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valMaxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // logText
            // 
            this.logText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logText.BackColor = System.Drawing.Color.Black;
            this.logText.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.logText.ForeColor = System.Drawing.Color.Lime;
            this.logText.Location = new System.Drawing.Point(6, 37);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logText.Size = new System.Drawing.Size(359, 358);
            this.logText.TabIndex = 5;
            this.logText.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnDelUser);
            this.groupBox1.Controls.Add(this.btnSaveUser);
            this.groupBox1.Controls.Add(this.btnChooseRoot);
            this.groupBox1.Controls.Add(this.btnAnonymous);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkPermDelete);
            this.groupBox1.Controls.Add(this.chkPermWrite);
            this.groupBox1.Controls.Add(this.chkPermRead);
            this.groupBox1.Controls.Add(this.chkPermList);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPw);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 212);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "编辑用户(已登入的用户不受影响)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "权限";
            // 
            // chkPermList
            // 
            this.chkPermList.AutoSize = true;
            this.chkPermList.Location = new System.Drawing.Point(12, 120);
            this.chkPermList.Name = "chkPermList";
            this.chkPermList.Size = new System.Drawing.Size(96, 16);
            this.chkPermList.TabIndex = 2;
            this.chkPermList.Text = "查看文件列表";
            this.chkPermList.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(57, 72);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(115, 21);
            this.txtPath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "根目录";
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(57, 45);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(156, 21);
            this.txtPw.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码";
            // 
            // txtUn
            // 
            this.txtUn.Location = new System.Drawing.Point(57, 18);
            this.txtUn.Name = "txtUn";
            this.txtUn.Size = new System.Drawing.Size(115, 21);
            this.txtUn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名";
            // 
            // listUser
            // 
            this.listUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listUser.FormattingEnabled = true;
            this.listUser.ItemHeight = 12;
            this.listUser.Location = new System.Drawing.Point(14, 101);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(221, 112);
            this.listUser.TabIndex = 1;
            // 
            // infoUpdateTimer
            // 
            this.infoUpdateTimer.Enabled = true;
            this.infoUpdateTimer.Interval = 1000;
            this.infoUpdateTimer.Tick += new System.EventHandler(this.infoUpdateTimer_Tick);
            // 
            // chkPermRead
            // 
            this.chkPermRead.AutoSize = true;
            this.chkPermRead.Location = new System.Drawing.Point(12, 142);
            this.chkPermRead.Name = "chkPermRead";
            this.chkPermRead.Size = new System.Drawing.Size(72, 16);
            this.chkPermRead.TabIndex = 2;
            this.chkPermRead.Text = "下载文件";
            this.chkPermRead.UseVisualStyleBackColor = true;
            // 
            // chkPermWrite
            // 
            this.chkPermWrite.AutoSize = true;
            this.chkPermWrite.Location = new System.Drawing.Point(12, 164);
            this.chkPermWrite.Name = "chkPermWrite";
            this.chkPermWrite.Size = new System.Drawing.Size(120, 16);
            this.chkPermWrite.TabIndex = 2;
            this.chkPermWrite.Text = "上传文件，重命名";
            this.chkPermWrite.UseVisualStyleBackColor = true;
            // 
            // chkPermDelete
            // 
            this.chkPermDelete.AutoSize = true;
            this.chkPermDelete.Location = new System.Drawing.Point(12, 186);
            this.chkPermDelete.Name = "chkPermDelete";
            this.chkPermDelete.Size = new System.Drawing.Size(72, 16);
            this.chkPermDelete.TabIndex = 2;
            this.chkPermDelete.Text = "删除文件";
            this.chkPermDelete.UseVisualStyleBackColor = true;
            // 
            // btnAnonymous
            // 
            this.btnAnonymous.Location = new System.Drawing.Point(170, 18);
            this.btnAnonymous.Name = "btnAnonymous";
            this.btnAnonymous.Size = new System.Drawing.Size(43, 21);
            this.btnAnonymous.TabIndex = 4;
            this.btnAnonymous.Text = "匿名";
            this.btnAnonymous.UseVisualStyleBackColor = true;
            // 
            // btnChooseRoot
            // 
            this.btnChooseRoot.Location = new System.Drawing.Point(170, 71);
            this.btnChooseRoot.Name = "btnChooseRoot";
            this.btnChooseRoot.Size = new System.Drawing.Size(43, 21);
            this.btnChooseRoot.TabIndex = 4;
            this.btnChooseRoot.Text = "...";
            this.btnChooseRoot.UseVisualStyleBackColor = true;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(138, 179);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUser.TabIndex = 5;
            this.btnSaveUser.Text = "保存";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            // 
            // btnDelUser
            // 
            this.btnDelUser.Location = new System.Drawing.Point(138, 149);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(75, 23);
            this.btnDelUser.TabIndex = 5;
            this.btnDelUser.Text = "删除";
            this.btnDelUser.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnKickAll);
            this.groupBox2.Controls.Add(this.lblUserCount);
            this.groupBox2.Controls.Add(this.logText);
            this.groupBox2.Location = new System.Drawing.Point(241, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 401);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息流";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(624, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Location = new System.Drawing.Point(7, 19);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(53, 12);
            this.lblUserCount.TabIndex = 6;
            this.lblUserCount.Text = "在线人数";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.valMaxUser);
            this.groupBox3.Location = new System.Drawing.Point(12, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 51);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务器管理";
            // 
            // valMaxUser
            // 
            this.valMaxUser.Location = new System.Drawing.Point(71, 20);
            this.valMaxUser.Name = "valMaxUser";
            this.valMaxUser.Size = new System.Drawing.Size(142, 21);
            this.valMaxUser.TabIndex = 0;
            this.valMaxUser.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "最大人数";
            // 
            // btnKickAll
            // 
            this.btnKickAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKickAll.Location = new System.Drawing.Point(264, 14);
            this.btnKickAll.Name = "btnKickAll";
            this.btnKickAll.Size = new System.Drawing.Size(101, 23);
            this.btnKickAll.TabIndex = 2;
            this.btnKickAll.Text = "断开所有用户";
            this.btnKickAll.UseVisualStyleBackColor = true;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出配置信息EToolStripMenuItem,
            this.导入配置信息IToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出XToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem1});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.关于AToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem1
            // 
            this.关于AToolStripMenuItem1.Name = "关于AToolStripMenuItem1";
            this.关于AToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.关于AToolStripMenuItem1.Text = "关于(&A)";
            // 
            // 导出配置信息EToolStripMenuItem
            // 
            this.导出配置信息EToolStripMenuItem.Name = "导出配置信息EToolStripMenuItem";
            this.导出配置信息EToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.导出配置信息EToolStripMenuItem.Text = "导出配置信息(&E)";
            // 
            // 导入配置信息IToolStripMenuItem
            // 
            this.导入配置信息IToolStripMenuItem.Name = "导入配置信息IToolStripMenuItem";
            this.导入配置信息IToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.导入配置信息IToolStripMenuItem.Text = "导入配置信息(&I)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FTP服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valMaxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer infoUpdateTimer;
        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkPermList;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPermDelete;
        private System.Windows.Forms.CheckBox chkPermWrite;
        private System.Windows.Forms.CheckBox chkPermRead;
        private System.Windows.Forms.Button btnChooseRoot;
        private System.Windows.Forms.Button btnAnonymous;
        private System.Windows.Forms.Button btnDelUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKickAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown valMaxUser;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出配置信息EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入配置信息IToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem1;
    }
}