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

        public const string CONF_MAX_USER = "MAX_USER";
        public const string CONF_PORT = "PORT";

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
                defaults.Add(CombineLine(CMD_CONF, CONF_MAX_USER, 48));
                defaults.Add(CombineLine(CMD_CONF, CONF_PORT, 21));
                defaults.Add(CombineLine(CMD_USER, CMD_USER_ADD, User.ANONYMOUS, "", "lr", Path.GetFullPath("." + Path.DirectorySeparatorChar + "FtpDir"), true));
                return defaults.ToArray();
            }
        }

        public static void PutConfigurations() {
            File.WriteAllLines(_cfgFileName, GenerateConfigurations());
        }

        public static string[] GenerateConfigurations() {
            List<string> lines = new List<string>();
            lines.Add(CombineLine(CMD_CONF, CONF_PORT, instance.Port));
            lines.Add(CombineLine(CMD_CONF, CONF_MAX_USER, instance.MaxUserCount));
            foreach(User user in Login.userList.Values) {
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
                string line = lines[i];
                if (line.StartsWith("#")) { break; }
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
                case CONF_MAX_USER:
                    {
                        if (argc < 3) { return NoEnoughArgs(CONF_MAX_USER, 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            instance.MaxUserCount = value;
                            return "Set user limits to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
                        }
                    }
                case CONF_PORT:
                    {
                        if (argc < 3) { return NoEnoughArgs(CONF_PORT, 3, argc); }
                        int value = 0;
                        if (int.TryParse(argv[2], out value))
                        {
                            instance.Port = value;
                            return "Set ftp port to " + value;
                        }
                        else
                        {
                            return string.Format("[Error]: Bad number format '{0}'", argv[2]);
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
