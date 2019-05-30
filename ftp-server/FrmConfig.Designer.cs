namespace ftp_server
{
    partial class FrmConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numFileSizeLimit = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numUserLimit = new System.Windows.Forms.NumericUpDown();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.txtEncoding = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numLoginDelay = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkNocheckUn = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numFakeUserTrigger = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAllowFakeUser = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numInactiveTimeout = new System.Windows.Forms.NumericUpDown();
            this.numUnloginTimeout = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numBanIpTime = new System.Windows.Forms.NumericUpDown();
            this.numBanIpTrigger = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.chkSmartBanIp = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkWriteLog = new System.Windows.Forms.CheckBox();
            this.numLogCount = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.numTransferBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFileSizeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUserLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoginDelay)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFakeUserTrigger)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInactiveTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnloginTimeout)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBanIpTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBanIpTrigger)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogCount)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTransferBufferSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 318);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器选项(部分项目需要重启服务器程序生效)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 292);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(310, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "一般设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numFileSizeLimit);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.numUserLimit);
            this.groupBox2.Controls.Add(this.numPort);
            this.groupBox2.Controls.Add(this.txtEncoding);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 133);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "一般设置";
            // 
            // numFileSizeLimit
            // 
            this.numFileSizeLimit.Location = new System.Drawing.Point(171, 106);
            this.numFileSizeLimit.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numFileSizeLimit.Name = "numFileSizeLimit";
            this.numFileSizeLimit.Size = new System.Drawing.Size(120, 21);
            this.numFileSizeLimit.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "文件大小限制（0为无限制）";
            // 
            // numUserLimit
            // 
            this.numUserLimit.Location = new System.Drawing.Point(54, 46);
            this.numUserLimit.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numUserLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUserLimit.Name = "numUserLimit";
            this.numUserLimit.Size = new System.Drawing.Size(238, 21);
            this.numUserLimit.TabIndex = 3;
            this.numUserLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(54, 17);
            this.numPort.Maximum = new decimal(new int[] {
            65530,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(238, 21);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // txtEncoding
            // 
            this.txtEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEncoding.FormattingEnabled = true;
            this.txtEncoding.Items.AddRange(new object[] {
            "GBK",
            "UTF-8",
            "ASCII"});
            this.txtEncoding.Location = new System.Drawing.Point(54, 77);
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(238, 20);
            this.txtEncoding.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(310, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "登录设置";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numLoginDelay);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.chkNocheckUn);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 191);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "登录设置";
            // 
            // numLoginDelay
            // 
            this.numLoginDelay.Location = new System.Drawing.Point(8, 115);
            this.numLoginDelay.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.numLoginDelay.Name = "numLoginDelay";
            this.numLoginDelay.Size = new System.Drawing.Size(284, 21);
            this.numLoginDelay.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "登录失败延时(毫秒):";
            // 
            // chkNocheckUn
            // 
            this.chkNocheckUn.AutoSize = true;
            this.chkNocheckUn.Location = new System.Drawing.Point(8, 40);
            this.chkNocheckUn.Name = "chkNocheckUn";
            this.chkNocheckUn.Size = new System.Drawing.Size(96, 16);
            this.chkNocheckUn.TabIndex = 1;
            this.chkNocheckUn.Text = "不检查用户名";
            this.chkNocheckUn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "登录失败后延时发送失败消息,可以防止黑客对用户名和密码进行快速爆破(不需要时设为0)";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "关闭检查用户名,可以防止黑客对用户名进行爆破";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Location = new System.Drawing.Point(4, 40);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(310, 248);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "假用户设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numFakeUserTrigger);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkAllowFakeUser);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 117);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "假账户设置";
            // 
            // numFakeUserTrigger
            // 
            this.numFakeUserTrigger.Location = new System.Drawing.Point(6, 89);
            this.numFakeUserTrigger.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numFakeUserTrigger.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numFakeUserTrigger.Name = "numFakeUserTrigger";
            this.numFakeUserTrigger.Size = new System.Drawing.Size(286, 21);
            this.numFakeUserTrigger.TabIndex = 3;
            this.numFakeUserTrigger.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "在下列尝试次数后登入假账户";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "对频繁使用错误的账户密码登录的用户,给与一个登录成功的假象";
            // 
            // chkAllowFakeUser
            // 
            this.chkAllowFakeUser.AutoSize = true;
            this.chkAllowFakeUser.Location = new System.Drawing.Point(6, 49);
            this.chkAllowFakeUser.Name = "chkAllowFakeUser";
            this.chkAllowFakeUser.Size = new System.Drawing.Size(96, 16);
            this.chkAllowFakeUser.TabIndex = 0;
            this.chkAllowFakeUser.Text = "开启虚假用户\r\n";
            this.chkAllowFakeUser.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(310, 248);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "会话设置";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numInactiveTimeout);
            this.groupBox5.Controls.Add(this.numUnloginTimeout);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(303, 73);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "会话设置";
            // 
            // numInactiveTimeout
            // 
            this.numInactiveTimeout.Location = new System.Drawing.Point(162, 41);
            this.numInactiveTimeout.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numInactiveTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInactiveTimeout.Name = "numInactiveTimeout";
            this.numInactiveTimeout.Size = new System.Drawing.Size(135, 21);
            this.numInactiveTimeout.TabIndex = 1;
            this.numInactiveTimeout.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numUnloginTimeout
            // 
            this.numUnloginTimeout.Location = new System.Drawing.Point(162, 16);
            this.numUnloginTimeout.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numUnloginTimeout.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numUnloginTimeout.Name = "numUnloginTimeout";
            this.numUnloginTimeout.Size = new System.Drawing.Size(135, 21);
            this.numUnloginTimeout.TabIndex = 1;
            this.numUnloginTimeout.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "断开不活跃的用户(分钟)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "断开超时未登陆的用户(秒)";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Location = new System.Drawing.Point(4, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(310, 248);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "智能IP封禁";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.numBanIpTime);
            this.groupBox6.Controls.Add(this.numBanIpTrigger);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.chkSmartBanIp);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(304, 148);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "智能IP封禁";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "封禁时间(分钟)";
            // 
            // numBanIpTime
            // 
            this.numBanIpTime.Location = new System.Drawing.Point(129, 111);
            this.numBanIpTime.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numBanIpTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBanIpTime.Name = "numBanIpTime";
            this.numBanIpTime.Size = new System.Drawing.Size(169, 21);
            this.numBanIpTime.TabIndex = 3;
            this.numBanIpTime.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numBanIpTrigger
            // 
            this.numBanIpTrigger.Location = new System.Drawing.Point(129, 84);
            this.numBanIpTrigger.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numBanIpTrigger.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBanIpTrigger.Name = "numBanIpTrigger";
            this.numBanIpTrigger.Size = new System.Drawing.Size(169, 21);
            this.numBanIpTrigger.TabIndex = 3;
            this.numBanIpTrigger.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "封禁触发阈值";
            // 
            // chkSmartBanIp
            // 
            this.chkSmartBanIp.AutoSize = true;
            this.chkSmartBanIp.Location = new System.Drawing.Point(9, 64);
            this.chkSmartBanIp.Name = "chkSmartBanIp";
            this.chkSmartBanIp.Size = new System.Drawing.Size(108, 16);
            this.chkSmartBanIp.TabIndex = 1;
            this.chkSmartBanIp.Text = "使用智能IP封禁";
            this.chkSmartBanIp.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(291, 42);
            this.label11.TabIndex = 0;
            this.label11.Text = "当服务器受到一个或多个IP地址的异常连接请求时(例如频繁连接/断开)会停止该地址的一切连接,保障正常用户的使用";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.groupBox7);
            this.tabPage5.Location = new System.Drawing.Point(4, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(310, 248);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "主界面设置";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkWriteLog);
            this.groupBox7.Controls.Add(this.numLogCount);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(303, 67);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "主界面设置";
            // 
            // chkWriteLog
            // 
            this.chkWriteLog.AutoSize = true;
            this.chkWriteLog.Location = new System.Drawing.Point(9, 44);
            this.chkWriteLog.Name = "chkWriteLog";
            this.chkWriteLog.Size = new System.Drawing.Size(126, 16);
            this.chkWriteLog.TabIndex = 2;
            this.chkWriteLog.Text = "将Log写入日志文件";
            this.chkWriteLog.UseVisualStyleBackColor = true;
            // 
            // numLogCount
            // 
            this.numLogCount.Location = new System.Drawing.Point(110, 15);
            this.numLogCount.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numLogCount.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numLogCount.Name = "numLogCount";
            this.numLogCount.Size = new System.Drawing.Size(187, 21);
            this.numLogCount.TabIndex = 1;
            this.numLogCount.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "Log缓冲区大小";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(268, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "保存设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.numTransferBufferSize);
            this.groupBox8.Location = new System.Drawing.Point(4, 146);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(300, 96);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "缓冲区设置";
            // 
            // numTransferBufferSize
            // 
            this.numTransferBufferSize.Location = new System.Drawing.Point(78, 17);
            this.numTransferBufferSize.Maximum = new decimal(new int[] {
            131072,
            0,
            0,
            0});
            this.numTransferBufferSize.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numTransferBufferSize.Name = "numTransferBufferSize";
            this.numTransferBufferSize.Size = new System.Drawing.Size(215, 21);
            this.numTransferBufferSize.TabIndex = 0;
            this.numTransferBufferSize.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "缓冲区大小";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(9, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(282, 40);
            this.label17.TabIndex = 2;
            this.label17.Text = "设置缓冲区大小可以调节服务器性能与并发的平衡\r\n更大的缓冲区能够带来更高的传输速度，而较小的缓冲区能够在有限的内存下实现更大的并发";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 372);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器选项";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFileSizeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUserLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoginDelay)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFakeUserTrigger)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInactiveTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnloginTimeout)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBanIpTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBanIpTrigger)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogCount)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTransferBufferSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numFakeUserTrigger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAllowFakeUser;
        private System.Windows.Forms.ComboBox txtEncoding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkNocheckUn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numLoginDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numUserLimit;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numInactiveTimeout;
        private System.Windows.Forms.NumericUpDown numUnloginTimeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numBanIpTime;
        private System.Windows.Forms.NumericUpDown numBanIpTrigger;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkSmartBanIp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown numLogCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numFileSizeLimit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkWriteLog;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown numTransferBufferSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}