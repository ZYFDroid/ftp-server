using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftp_server
{
    class User
    {
        private string _username;
        private string _password;
        private string _root;
        private bool _l = false;
        private bool _r = false;
        private bool _w = false;
        private bool _d = false;

        private bool _loggedIn;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
            }
        }
        public bool CanRead
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
            }
        }
        public bool CanWrite
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }
        public bool CanList
        {
            get
            {
                return _l;
            }
            set
            {
                _l = value;
            }
        }
        public bool CanDelete {
            get
            {
                return _d;
            }
            set {
                _d = value;
            }
        }

        public bool LoggedIn
        {
            get
            {
                return _loggedIn;
            }
            set
            {
                _loggedIn = value;
            }
        }

        public User()
        {
            _loggedIn = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="permission">Permissions,refer to code</param>
        /// <param name="root">root dictionary</param>
        /// <param name="creatroot"> create root dictionary if does not exist</param>
        public User(string username, string password,string permission, string root, bool creatroot=false) : this()
        {
            _username = username;
            _password = password;
            _root = root;
            CanRead = permission.Contains("r");
            CanWrite = permission.Contains("w");
            CanList = permission.Contains("l");
            CanDelete = permission.Contains("d");
            if (creatroot) {
                if (!Directory.Exists(root)) {
                    Directory.CreateDirectory(root);
                }
            }
        }
    }
}
