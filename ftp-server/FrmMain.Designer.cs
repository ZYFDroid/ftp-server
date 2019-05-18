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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.logText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userEditBox = new System.Windows.Forms.GroupBox();
            this.btnCancelSave = new System.Windows.Forms.Button();
            this.btnDelUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnChooseRoot = new System.Windows.Forms.Button();
            this.btnAnonymous = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPermDelete = new System.Windows.Forms.CheckBox();
            this.chkPermWrite = new System.Windows.Forms.CheckBox();
            this.chkPermRead = new System.Windows.Forms.CheckBox();
            this.chkPermList = new System.Windows.Forms.CheckBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listUser = new System.Windows.Forms.ListBox();
            this.infoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKickAll = new System.Windows.Forms.Button();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.testexceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.valMaxUser = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMnuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userEditBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valMaxUser)).BeginInit();
            this.trayMenu.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.logText.Size = new System.Drawing.Size(378, 358);
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
            // userEditBox
            // 
            this.userEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userEditBox.Controls.Add(this.btnCancelSave);
            this.userEditBox.Controls.Add(this.btnDelUser);
            this.userEditBox.Controls.Add(this.btnSaveUser);
            this.userEditBox.Controls.Add(this.btnChooseRoot);
            this.userEditBox.Controls.Add(this.btnAnonymous);
            this.userEditBox.Controls.Add(this.label5);
            this.userEditBox.Controls.Add(this.chkPermDelete);
            this.userEditBox.Controls.Add(this.chkPermWrite);
            this.userEditBox.Controls.Add(this.chkPermRead);
            this.userEditBox.Controls.Add(this.chkPermList);
            this.userEditBox.Controls.Add(this.txtPath);
            this.userEditBox.Controls.Add(this.label4);
            this.userEditBox.Controls.Add(this.txtPw);
            this.userEditBox.Controls.Add(this.label3);
            this.userEditBox.Controls.Add(this.txtUn);
            this.userEditBox.Controls.Add(this.label2);
            this.userEditBox.Enabled = false;
            this.userEditBox.Location = new System.Drawing.Point(12, 218);
            this.userEditBox.Name = "userEditBox";
            this.userEditBox.Size = new System.Drawing.Size(204, 212);
            this.userEditBox.TabIndex = 2;
            this.userEditBox.TabStop = false;
            this.userEditBox.Text = "编辑用户(已登入的用户不受影响)";
            // 
            // btnCancelSave
            // 
            this.btnCancelSave.Location = new System.Drawing.Point(104, 176);
            this.btnCancelSave.Name = "btnCancelSave";
            this.btnCancelSave.Size = new System.Drawing.Size(42, 23);
            this.btnCancelSave.TabIndex = 6;
            this.btnCancelSave.Text = "取消";
            this.btnCancelSave.UseVisualStyleBackColor = true;
            this.btnCancelSave.Click += new System.EventHandler(this.btnCancelSave_Click);
            // 
            // btnDelUser
            // 
            this.btnDelUser.Location = new System.Drawing.Point(104, 148);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(42, 23);
            this.btnDelUser.TabIndex = 5;
            this.btnDelUser.Text = "删除";
            this.btnDelUser.UseVisualStyleBackColor = true;
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(150, 176);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(42, 23);
            this.btnSaveUser.TabIndex = 5;
            this.btnSaveUser.Text = "保存";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnChooseRoot
            // 
            this.btnChooseRoot.Location = new System.Drawing.Point(150, 93);
            this.btnChooseRoot.Name = "btnChooseRoot";
            this.btnChooseRoot.Size = new System.Drawing.Size(43, 22);
            this.btnChooseRoot.TabIndex = 4;
            this.btnChooseRoot.Text = "...";
            this.btnChooseRoot.UseVisualStyleBackColor = true;
            this.btnChooseRoot.Click += new System.EventHandler(this.btnChooseRoot_Click);
            // 
            // btnAnonymous
            // 
            this.btnAnonymous.Location = new System.Drawing.Point(150, 18);
            this.btnAnonymous.Name = "btnAnonymous";
            this.btnAnonymous.Size = new System.Drawing.Size(43, 21);
            this.btnAnonymous.TabIndex = 4;
            this.btnAnonymous.Text = "匿名";
            this.btnAnonymous.UseVisualStyleBackColor = true;
            this.btnAnonymous.Click += new System.EventHandler(this.btnAnonymous_Click);
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
            // chkPermDelete
            // 
            this.chkPermDelete.AutoSize = true;
            this.chkPermDelete.Location = new System.Drawing.Point(12, 182);
            this.chkPermDelete.Name = "chkPermDelete";
            this.chkPermDelete.Size = new System.Drawing.Size(72, 16);
            this.chkPermDelete.TabIndex = 2;
            this.chkPermDelete.Text = "删除文件";
            this.chkPermDelete.UseVisualStyleBackColor = true;
            // 
            // chkPermWrite
            // 
            this.chkPermWrite.AutoSize = true;
            this.chkPermWrite.Location = new System.Drawing.Point(12, 117);
            this.chkPermWrite.Name = "chkPermWrite";
            this.chkPermWrite.Size = new System.Drawing.Size(120, 16);
            this.chkPermWrite.TabIndex = 2;
            this.chkPermWrite.Text = "上传文件，重命名";
            this.chkPermWrite.UseVisualStyleBackColor = true;
            // 
            // chkPermRead
            // 
            this.chkPermRead.AutoSize = true;
            this.chkPermRead.Location = new System.Drawing.Point(12, 161);
            this.chkPermRead.Name = "chkPermRead";
            this.chkPermRead.Size = new System.Drawing.Size(72, 16);
            this.chkPermRead.TabIndex = 2;
            this.chkPermRead.Text = "下载文件";
            this.chkPermRead.UseVisualStyleBackColor = true;
            // 
            // chkPermList
            // 
            this.chkPermList.AutoSize = true;
            this.chkPermList.Location = new System.Drawing.Point(12, 139);
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
            this.txtPath.Size = new System.Drawing.Size(135, 21);
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
            this.txtPw.Size = new System.Drawing.Size(135, 21);
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
            this.txtUn.Size = new System.Drawing.Size(94, 21);
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
            this.listUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listUser.FormattingEnabled = true;
            this.listUser.ItemHeight = 12;
            this.listUser.Location = new System.Drawing.Point(2, 2);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(201, 108);
            this.listUser.TabIndex = 1;
            this.listUser.SelectedIndexChanged += new System.EventHandler(this.listUser_SelectedIndexChanged);
            // 
            // infoUpdateTimer
            // 
            this.infoUpdateTimer.Enabled = true;
            this.infoUpdateTimer.Interval = 500;
            this.infoUpdateTimer.Tick += new System.EventHandler(this.infoUpdateTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnKickAll);
            this.groupBox2.Controls.Add(this.lblUserCount);
            this.groupBox2.Controls.Add(this.logText);
            this.groupBox2.Location = new System.Drawing.Point(222, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 401);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息流";
            // 
            // btnKickAll
            // 
            this.btnKickAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKickAll.Location = new System.Drawing.Point(283, 13);
            this.btnKickAll.Name = "btnKickAll";
            this.btnKickAll.Size = new System.Drawing.Size(101, 23);
            this.btnKickAll.TabIndex = 2;
            this.btnKickAll.Text = "断开所有用户";
            this.btnKickAll.UseVisualStyleBackColor = true;
            this.btnKickAll.Click += new System.EventHandler(this.btnKickAll_Click);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.mnuExit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(152, 22);
            this.mnuSave.Text = "保存配置(&S)";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "退出(&X)";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.testexceptionToolStripMenuItem});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.关于AToolStripMenuItem.Text = "帮助(&H)";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(153, 22);
            this.mnuAbout.Text = "关于(&A)";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // testexceptionToolStripMenuItem
            // 
            this.testexceptionToolStripMenuItem.Name = "testexceptionToolStripMenuItem";
            this.testexceptionToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.testexceptionToolStripMenuItem.Text = "testexception";
            this.testexceptionToolStripMenuItem.Visible = false;
            this.testexceptionToolStripMenuItem.Click += new System.EventHandler(this.testexceptionToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.valMaxUser);
            this.groupBox3.Location = new System.Drawing.Point(12, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 51);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务器管理";
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
            // valMaxUser
            // 
            this.valMaxUser.Location = new System.Drawing.Point(71, 20);
            this.valMaxUser.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.valMaxUser.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valMaxUser.Name = "valMaxUser";
            this.valMaxUser.Size = new System.Drawing.Size(122, 21);
            this.valMaxUser.TabIndex = 0;
            this.valMaxUser.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.valMaxUser.ValueChanged += new System.EventHandler(this.valMaxUser_ValueChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "FTP服务器";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMnuMain,
            this.toolStripSeparator1,
            this.trayMnuExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.ShowImageMargin = false;
            this.trayMenu.Size = new System.Drawing.Size(112, 54);
            // 
            // trayMnuMain
            // 
            this.trayMnuMain.Name = "trayMnuMain";
            this.trayMnuMain.Size = new System.Drawing.Size(111, 22);
            this.trayMnuMain.Text = "打开主界面";
            this.trayMnuMain.Click += new System.EventHandler(this.trayMnuMain_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // trayMnuExit
            // 
            this.trayMnuExit.Name = "trayMnuExit";
            this.trayMnuExit.Size = new System.Drawing.Size(111, 22);
            this.trayMnuExit.Text = "退出";
            this.trayMnuExit.Click += new System.EventHandler(this.trayMnuExit_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewUser.Location = new System.Drawing.Point(162, 366);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(42, 23);
            this.btnNewUser.TabIndex = 6;
            this.btnNewUser.Text = "新建";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listUser);
            this.panel1.Location = new System.Drawing.Point(12, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 114);
            this.panel1.TabIndex = 7;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "服务器选项(&I)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.userEditBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FTP服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.userEditBox.ResumeLayout(false);
            this.userEditBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valMaxUser)).EndInit();
            this.trayMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer infoUpdateTimer;
        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.GroupBox userEditBox;
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
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelSave;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMnuMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayMnuExit;
        private System.Windows.Forms.ToolStripMenuItem testexceptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}