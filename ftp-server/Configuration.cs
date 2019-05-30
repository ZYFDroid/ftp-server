using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftp_server
{
    static class Configuration
    {
        public static FtpServer instance;

        #region CONSTANTS
        public const string TRUE = "TRUE";
        public const string FALSE = "FALSE";
        public const char SPLIT = '\t';

        public const string CMD_CONF = "CONF";

        public const string CONF_SERVER_MAX_USER = "SERVER_MAX_USER";
        public const string CONF_SERVER_PORT = "SERVER_PORT";
        public const string CONF_SERVER_FILESIZE_LIMIT = "SERVER_FILESIZE_LIMIT";
        public const string CONF_LOGIN_ALLOW_FAKE_USER = "LOGIN_ALLOW_FAKE_USER";
        public const string CONF_LOGIN_FAKE_USER_TRIGGER = "LOGIN_FAKE_USER_TRIGGER";
        public const string CONF_LOGIN_CHECK_USERNAME = "LOGIN_CHECK_USERNAME";
        public const string CONF_LOGIN_AUTH_DELAY = "LOGIN_AUTH_DELAY";
        public const string CONF_SERVER_UNLOGIN_TIMEOUT = "SERVER_UNLOGIN_TIMEOUT";
        public const string CONF_SERVER_ENABLE_SMART_BAN_IP = "SERVER_ENABLE_SMART_BAN_IP";
        public const string CONF_SERVER_BAN_IP_TRIGGER = "SERVER_BAN_IP_TRIGGER";
        public const string CONF_SERVER_BAN_IP_DURATION = "SERVER_BAN_IP_DURATION";
        public const string CONF_SERVER_DISCONNECT_INACTIVE_TIMEOUT = "SERVER_DISCONNECT_INACTIVE_TIMEOUT";
        public const string CONF_SERVER_ENCODING = "SERVER_ENCODING";
        public const string CONF_SERVER_TRANSFER_BUFFERSIZE = "SERVER_TRANSFER_BUFFERSIZE";

        public const string CONF_UI_LOG_LIMIT = "UI_LOG_LIMIT";
        public const string CONF_UI_LOG_WRITEFILE = "UI_LOG_WRITEFILE";

        public const string CMD_USER = "USER";
        public const string CMD_USER_ADD = "ADD";
        #endregion



        public const string _cfgFileName = "ftp.conf";
        public static string[] GetConfigurations() {
            if (File.Exists(_cfgFileName)) {
                return File.ReadAllLines(_cfgFileName);
            }
            else {
                List<string> defaults = new List<string>();
                defaults.Add(CombineLine(CMD_USER, CMD_USER_ADD, User.ANONYMOUS, "", "lr", Path.GetFullPath("." + Path.DirectorySeparatorChar + "FtpDir"), true));
                return defaults.ToArray();
            }
        }

        public static void PutConfigurations() {
            File.WriteAllLines(_cfgFileName, GenerateConfigurations());
        }

        public static string[] GenerateConfigurations() {
            List<string> lines = new List<string>();

            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_PORT, FtpServer.Port));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_MAX_USER, FtpServer.MaxUserCount));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_FILESIZE_LIMIT, FtpServer.limitedFileSizeMB));

            lines.Add(CombineLine(CMD_CONF, CONF_LOGIN_ALLOW_FAKE_USER,Login.AllowFakeUser));
            lines.Add(CombineLine(CMD_CONF, CONF_LOGIN_FAKE_USER_TRIGGER, Login.FakeUserTrigger));
            lines.Add(CombineLine(CMD_CONF, CONF_LOGIN_CHECK_USERNAME, Login.CheckUser));
            lines.Add(CombineLine(CMD_CONF, CONF_LOGIN_AUTH_DELAY, Login.AuthDelayTime));

            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_UNLOGIN_TIMEOUT, FtpServer.UnloginedTimeout));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_ENABLE_SMART_BAN_IP,FtpServer.enableSmartBanIp));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_BAN_IP_TRIGGER, FtpServer.BanIpTrigger));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_BAN_IP_DURATION, FtpServer.BanIpDuration));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_DISCONNECT_INACTIVE_TIMEOUT, FtpServer.DisconnectInactiveTimeout));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_ENCODING, FtpServer.Encodings));
            lines.Add(CombineLine(CMD_CONF, CONF_SERVER_TRANSFER_BUFFERSIZE, FtpServer.transferBufferSize));

            lines.Add(CombineLine(CMD_CONF, CONF_UI_LOG_LIMIT, FrmMain.maxlog));
            lines.Add(CombineLine(CMD_CONF, CONF_UI_LOG_WRITEFILE, FrmMain.WriteLogToFile));

            foreach (User user in Login.userList.Values) {
                lines.Add(CombineLine(CMD_USER,CMD_USER_ADD,user.Username,user.Password,user.Permissions,user.Root,true));
            }
            return lines.ToArray();
        }

        public static string CombineLine(params object[] items) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++) {
                if (items[i] is bool) {
                    sb.Append(((bool)items[i]) ? TRUE : FALSE);
                }
                else
                {
                    sb.Append(items[i].ToString().Replace(SPLIT, '_'));
                }
                if (i < items.Length - 1) {
                    sb.Append(SPLIT);
                }
            }
            return sb.ToString();
        }

        public static string InterpreteConfigurations(string[] lines) {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i].Trim();
                if (line.StartsWith("#")) { break; }
                if(line==""){ break; }
                string[] commands = line.Split(SPLIT);
                output.AppendLine("Line " + (i + 1) + ": " + performAction(commands));
            }
            return output.ToString().TrimEnd('\r', '\n', ' ');
        }

        private static string performAction(string[] args) {
            if (args.Length < 1) {
                return "No Operation for empty lines";
            }
            string cmd = args[0];
            int len = args.Length;
            switch (cmd.ToUpper()) {
                case CMD_CONF:
                    return performConf(len, args);
                case CMD_USER:
                    return performUser(len, args);

                default:
                    return String.Format("[Error]: Unknown command '{0}'", cmd);
            }
        }
        #region CONF ACTIONS 
        private static string performConf(int argc, string[] argv)
        {
            if (argc < 2)
            {
                return NoEnoughArgs(argv[0], 2, argc);
            }
            switch (argv[1].ToUpper()) {
                case CONF_SERVER_MAX_USER:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.MaxUserCount = value;
                            return "Set "+argv[1]+" to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_PORT:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.Port = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_FILESIZE_LIMIT:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.limitedFileSizeMB = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_LOGIN_ALLOW_FAKE_USER:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        bool value = false;
                        if (bool.TryParse(argv[2].ToLower(), out value))
                        {
                            Login.AllowFakeUser = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad boolean format '{0}'", argv[2]);
                        }
                    }

                case CONF_LOGIN_CHECK_USERNAME:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        bool value = false;
                        if (bool.TryParse(argv[2].ToLower(), out value))
                        {
                            Login.CheckUser = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad boolean format '{0}'", argv[2]);
                        }
                    }
                case CONF_LOGIN_FAKE_USER_TRIGGER:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            Login.FakeUserTrigger = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_LOGIN_AUTH_DELAY:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            Login.AuthDelayTime = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }

                case CONF_SERVER_ENABLE_SMART_BAN_IP:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        bool value = false;
                        if (bool.TryParse(argv[2].ToLower(), out value))
                        {
                            FtpServer.enableSmartBanIp = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad boolean format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_UNLOGIN_TIMEOUT:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.UnloginedTimeout = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_BAN_IP_TRIGGER:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.BanIpTrigger = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_BAN_IP_DURATION:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.BanIpDuration = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_DISCONNECT_INACTIVE_TIMEOUT:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.DisconnectInactiveTimeout= value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_TRANSFER_BUFFERSIZE:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            FtpServer.transferBufferSize = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_SERVER_ENCODING:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        string value = argv[2];
                        
                            FtpServer.Encodings = value;
                            return "Set " + argv[1] + " to " + value;
                    }
                case CONF_UI_LOG_LIMIT:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                           FrmMain.maxlog=value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_UI_LOG_WRITEFILE:
                    {
                        if (argc < 3) { return NoEnoughArgs(argv[1], 3, argc); }
                        bool value = false;
                        if (bool.TryParse(argv[2].ToLower(), out value))
                        {
                            FrmMain.WriteLogToFile = value;
                            return "Set " + argv[1] + " to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad boolean format '{0}'", argv[2]);
                        }
                    }
                default:
                    return string.Format("[Error]: Unknown configuration entry '{0}'", argv[1]);
            }

        }

        private static string performUser(int argc, string[] argv) {
            if (argc < 2)
            {
                return NoEnoughArgs(argv[0], 2, argc);
            }
            switch (argv[1].ToUpper()) {
                case CMD_USER_ADD:
                    {
                        if (argc < 2 + 4) { return NoEnoughArgs(argv[0], 2 + 4, argc); }
                        string username = argv[2 + 0];
                        string password = argv[2 + 1];
                        string permission = argv[2 + 2];
                        string rootdir = argv[2 + 3];
                        if (argc < 2 + 5)
                        {
                            Login.AddUser(new User(username, password, permission, rootdir));
                            return string.Format("Add user {0}", username);
                        }
                        else
                        {
                            Login.AddUser(new User(username, password, permission, rootdir, isTrue(argv[2+4])));
                            return string.Format("Add user {0}", username);
                        }
                    }
                default:
                    return string.Format("[Error]: Unknown sub command '{0}'", argv[1]);
            }
        }
        #endregion
        private static bool isTrue(String s) {
            return s.ToUpper() == TRUE;
        }
        private static string NoEnoughArgs(string cmd, int need, int acul) {
            return String.Format("[Error]: Argument to less for '{0}',need {1}, got {2}", cmd, need, acul);
        }
    }
}
