using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ftp_server
{
    class ClientConnection : IDisposable
    {
        #region Fields

        long createTime = -1;

        private TcpClient _client;
        private TcpClient _dataClient;
        private TcpListener _passiveListener;

        private NetworkStream _networkStream;
        private StreamReader _reader;
        private StreamWriter _writer;     
        private StreamWriter _dataWriter;

        private IPEndPoint _dataEndpoint;

        private User _user=new User();
        private string _transferType;
        private string _currentDirectory;
        private bool _disposed;
        private bool _passiveConn;
        private FtpServer _parent;
        #endregion

        bool _isValidSession = false;
        

        public ClientConnection(TcpClient client,FtpServer server)
        {
            try
            {
                _user.RemoteAddress = ((IPEndPoint)(client.Client.RemoteEndPoint)).Address.ToString();
            }
            catch { _user.RemoteAddress = "unknown_host"; }
            createTime = SysClock.Mill;
            _client = client;
            _parent = server;
            _networkStream = _client.GetStream();
            _networkStream.ReadTimeout = FtpServer.DisconnectInactiveTimeout * 60000+2000;
            _reader = new StreamReader(_networkStream, Encoding.GetEncoding(FtpServer.Encodings));
            _writer = new StreamWriter(_networkStream, Encoding.GetEncoding(FtpServer.Encodings));
        }

        public bool Disposed {
            get { return _disposed; }
        }

        private string Response(string cmd, string argument)
        {
            _isValidSession = true;
            string response = "503 Bad sequence of commands";
            switch (cmd.ToUpper())
            {
                case "USER":
                    response = "503 Bad sequence of commands";
                    break;
                case "PASS":
                    response = "503 Bad sequence of commands";
                    break;
                case "NOOP":
                    response = "200 OK";
                    break;
                case "CWD":
                        response = ChangeWorkingDirectory(argument);
                    break;
                case "CDUP":
                        response = ChangeWorkingDirectory("..");
                    break;
                case "QUIT":
                    response = "221 Bye";
                    Dispose();
                    break;
                case "BYE":
                    response = "221 Bye";
                    Dispose();
                    break;
                case "PWD":
                    response = PrintWorkingDirectory();
                    break;
                case "TYPE":
                    string[] args = argument.Split(' ');
                    response = Type(args[0], args.Length > 1 ? args[1] : null);
                    break;
                case "PORT":
                    response = Port(argument);
                    break;
                case "PASV":
                    response = Passive();
                    break;
                case "LIST":
                    response = List(argument,_user.IsFake);
                    break;
                case "SYST":
                    response = "215 UNIX Type: L8";
                    break;
                case "RETR":
                    if (_user.CanRead)
                        response = Retrieve(argument);
                    break;
                case "STOR":
                    if (_user.CanWrite)
                        response = Store(argument);
                    break;
                case "DELE":
                    if (_user.CanDelete)
                        response = Delete(argument);
                    break;
                case "MKD":
                    if(_user.CanWrite)
                        response = MakeDirectory(argument);
                    break;
                case "RMD":
                    if (_user.CanDelete)
                        response = RemoveDirectoyy(argument);
                    break;
                case "STRU":
                    if (_user.CanRead)
                        response = Structure(argument);
                    break;
                case "MODE":
                    response = Mode(argument);
                    break;
                case "RNFR":
                    if (_user.CanWrite)
                        response = RenameFrom(argument);
                    break;
                case "RNTO":
                    if (_user.CanWrite)
                        response = RenameTo(argument);
                    break;
                case "SIZE":
                    if (_user.CanRead)
                        response = GetSize(argument);
                    break;
                case "TERM":
                    if (_user.CanRead && _user.CanList && _user.CanWrite && _user.CanDelete)
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;
                default:
                    response = "502 Command not implemented";
                    break;
            }
            return response;
        }


        private string LoginResponse(string cmd, string argument)
        {
            string response = "";

            switch (cmd)
            {
                case "USER":
                    response = CheckUsername(argument);
                    break;
                case "PASS":
                    response = CheckPassword(argument);
                    break;
                case "QUIT":
                    response = "221 Bye";
                    Dispose();
                    break;
                case "BYE":
                    response = "221 Bye";
                    Dispose();
                    break;
                default:
                    response = "530 Not logged in";
                    break;
            }
            return response;
        }

        public void HandleClient()
        {
            try
            {
                _writer.WriteLine("220 全民制作人们 大家好 我是练习时长两年半的个人练习生蔡徐坤 喜欢唱，跳，Rap，篮球 Music!");
                _writer.Flush();
            }
            catch(IOException ex)
            {
                ConsoleWriteLine(ex.Message);
                return;
            }

            string line = null;

            _dataClient = new TcpClient();
            try
            {
                while (!string.IsNullOrEmpty(line = _reader.ReadLine()))
                {
                    ConsoleWriteLine(String.Format("--[FROM {0}@{1}] {2}",_user.Username,_user.RemoteAddress,line));
                    string response = null;

                    string[] command = line.Split(' ');

                    string cmd = command[0].ToUpper();

                    string argument = command.Length > 1 ? line.Substring(command[0].Length + 1) : null;

                    if (string.IsNullOrWhiteSpace(argument))
                        argument = null;

                    if (_user.LoggedIn)
                    {
                        response = Response(cmd, argument);
                    }
                    else
                    {
                        response = LoginResponse(cmd, argument);
                    }

                    if (_client == null || !_client.Connected)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            ConsoleWriteLine(String.Format("----[TO {0}@{1}] {2}", _user.Username, _user.RemoteAddress, response));
                            _writer.WriteLine(response);
                            _writer.Flush();
                        }
                        catch (IOException)
                        {
                            ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, "Connection Lost."));
                            break;
                        }

                        if (response.StartsWith("221"))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress,ex.Message));
            }
            Dispose();
        }

        #region AccessControlCommands

        private string CheckUsername(string username)
        {
            if (username == null)
            {
                return "530 Not logged in. Missing <username>";
            }

            if (Login.UsernameExists(username))
            {
                _user.Username = username;
                return "331 Username ok, need password";
            }

            return "530 Not logged in";            
        }

        private string CheckPassword(string password)
        {
            _user.Password = password;

            if (password == null)
            {
                return CheckPassword("");
            }

            if (Login.IsValidLogin(_user))
            {
                _currentDirectory = _user.Root;
                _user.LoggedIn = true;
                return "230 User logged in";
            }
            else
            {
                return "530 Username or password incorrect";
            }
        }

        private string ChangeWorkingDirectory(string pathname)
        {
            if (!_user.CanList) {
                if (pathname.Length < 1024) {
                    return "250 Changed to new directory";
                } else
                {
                    return "550 Permission Denied";
                }
            }
            if (pathname == "/")
            {
                _currentDirectory = _user.Root;
            }
            else
            {
                string newDir;
                try
                {
                    if (pathname.StartsWith("/"))
                    {
                        pathname = pathname.Substring(1).Replace('/', '\\');
                        newDir = Path.Combine(_user.Root, pathname);
                    }
                    else
                    {
                        pathname = pathname.Replace('/', '\\');
                        newDir = Path.Combine(_currentDirectory, pathname);
                    }
                }
                catch(ArgumentException)
                {
                    return "550 Directory not found";
                }
                

                if (Directory.Exists(newDir))
                {
                    _currentDirectory = new DirectoryInfo(newDir).FullName;

                    if (!IsPathValid(_currentDirectory))
                    {
                        _currentDirectory = _user.Root;
                        return "550 Can't access directory";
                    }
                }
                else
                {
                    _currentDirectory = _user.Root;
                    return "550 Directory not found";
                }
            }

            return "250 Changed to new directory";
        }

        #endregion

        #region TransferParameterCommands

        private string Type(string typeCode, string formatControl)
        {
            string response = "500 error";

            switch (typeCode)
            {
                case "I":
                    _transferType = typeCode;
                    response = "200 OK";
                    break;
                case "A":
                    _transferType = typeCode;
                    response = "200 OK";
                    break;
                case "E":
                case "L":
                default:
                    response = "504 Command not implemented for that parameter.";
                    break;
            }

            if (formatControl != null)
            {
                switch (formatControl)
                {
                    case "N":
                        response = "200 OK";
                        break;
                    case "T":
                    case "C":
                    default:
                        response = "504 Command not implemented for that parameter.";
                        break;
                }
            }

            return response;
        }

        private string Port(string hostPort)
        {
            _passiveConn = false;

            string[] ipAndPort = hostPort.Split(',');

            byte[] ipAddress = new byte[4];
            byte[] port = new byte[2];

            for (int i = 0; i < 4; i++)
            {
                ipAddress[i] = Convert.ToByte(ipAndPort[i]);
            }

            for (int i = 4; i < 6; i++)
            {
                port[i - 4] = Convert.ToByte(ipAndPort[i]);
            }

            if (BitConverter.IsLittleEndian)
                Array.Reverse(port);

            int prt = port[1] * 256 + port[0];

            _dataEndpoint = new IPEndPoint(new IPAddress(ipAddress), prt);

            return "200 Data Connection Established";
        }

        private string renamefrom_name;
        private String RenameFrom(String args) {
            string pathname = NormalizeFilename(args);
            if (File.Exists(pathname) || Directory.Exists(pathname)) {
                renamefrom_name = pathname;
                return "350 File exists, ready for destination name.";
            }
            return "550 File not found";
        }
        private String RenameTo(String arg) {
            string pathname = NormalizeFilename(arg);
            if (File.Exists(pathname) || Directory.Exists(pathname))
            {
                return "550 File exists, cannot rename";
            }
            try
            {
                //if (File.GetAttributes(pathname).HasFlag(FileAttributes.Directory))
                
                    Directory.Move(renamefrom_name, pathname);
                    return "250 RNTO command successful.";
               
                
            }
            catch (Exception ex) {
                ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
            }
            return "550 Fail to rename";

        } 

        private string Passive()
        {
            _passiveConn = true;

            IPAddress localAddress = ((IPEndPoint)_client.Client.LocalEndPoint).Address;

            _passiveListener = new TcpListener(localAddress, 0);
            _passiveListener.Start();

            IPEndPoint passiveListenerEndpoint = (IPEndPoint)_passiveListener.LocalEndpoint;

            byte[] address = passiveListenerEndpoint.Address.GetAddressBytes();
            short port = (short)passiveListenerEndpoint.Port;

            byte[] portArray = BitConverter.GetBytes(port);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(portArray);

            return string.Format("227 Entering Passive Mode ({0},{1},{2},{3},{4},{5})", address[0], address[1], address[2], address[3], portArray[0], portArray[1]);
        }

        private string Structure(string structure)
        {
            switch (structure)
            {
                case "F":
                    break;
                case "R":
                case "P":
                    return string.Format("504 STRU not implemented for \"{0}\"", structure);
                default:
                    return string.Format("501 Parameter {0} not recognized", structure);
            }

            return "200 Command OK";
        }

        private string Mode(string mode)
        {
            if (mode.ToUpperInvariant() == "S")
            {
                return "200 OK";
            }
            else
            {
                return "504 Command not implemented for that parameter";
            }
        }

        #endregion

        #region FTPServiceCommands

        private string List(string pathname,bool isFunny)
        {
            if (pathname == "-l") {
                return List("", isFunny);
            }
            if (pathname == "-a")
            {
                return List("", isFunny);
            }
            pathname = NormalizeFilename(pathname);

            if (pathname != null)
            {
                try
                {
                    _writer.WriteLine("150 Opening Passive mode data transfer for LIST");
                    _writer.Flush();

                    return HandleList(pathname, isFunny);
                }
                catch (IOException ex)
                {
                    ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
                }

            }
            
            return "450 Requested file action not taken";
        }

        private string Delete(string pathname)
        {
            pathname = NormalizeFilename(pathname);

            if(pathname != null)
            {
                if(File.Exists(pathname))
                {
                    File.Delete(pathname);
                }
                else
                {
                    return "550 File not found";
                }

                return "250 Requested file action okay, completed";
            }

            return "550 File not found";
        }

        private string RemoveDirectoyy(string pathname)
        {
            pathname = NormalizeFilename(pathname);

            if(pathname != null)
            {
                if(Directory.Exists(pathname))
                {
                    Directory.Delete(pathname);
                }
                else
                {
                    return "550 Directory not found";
                }

                return "250 Requested directory action okay, comlpeted";
            }

            return "550 Directory not found";
        }

        private string MakeDirectory(string pathname)
        {
            pathname = NormalizeFilename(pathname);
            
            if(pathname != null)
            {
                if(!Directory.Exists(pathname))
                {
                    Directory.CreateDirectory(pathname);
                }
                else
                {
                    return "550 Directory already exists";
                }

                return "250 Requested directory action okay, completed";
            }

            return "550 Directory not created";
        }

        private string HandleList(string pathname,bool isFunny)
        {
            if (_passiveConn)
            {
                _dataClient = _passiveListener.AcceptTcpClient();
            }
            else
            {
                _dataClient = new TcpClient(_dataEndpoint.AddressFamily);
                _dataClient.Connect(_dataEndpoint.Address, _dataEndpoint.Port);
            }

            using (NetworkStream stream = _dataClient.GetStream())
            {
                _dataWriter = new StreamWriter(stream, Encoding.GetEncoding(FtpServer.Encodings));
                StringBuilder list = new StringBuilder();
                IEnumerable<string> directories;
                if (!isFunny)
                {
                    if (_user.CanList)
                    {
                        directories = Directory.EnumerateDirectories(pathname);
                    }
                    else
                    {
                        directories = new List<string>();
                    }
                }
                else {
                    directories = new List<string>(new string[] {
                        "鸡你太美",
                        "鸡你太美",
                        "鸡你实在是太美",
                    });
                }

                list.Append(String.Format("drwxr-xr-x 1 user group {0,13} Aug 31 00:00 {1}", "0", ".")).Append("\n");
                list.Append(String.Format("drwxr-xr-x 1 user group {0,13} Aug 31 00:00 {1}", "0", "..")).Append("\n");
                foreach (string dir in directories)
                {
                    DirectoryInfo d = new DirectoryInfo(dir);
                    list.Append(String.Format("drwxr-xr-x 1 user group {0,13} Aug 31 00:00 {1}", "0",d.Name)).Append("\n");
                   

                }


                IEnumerable<string> files;
                if (!isFunny)
                {
                    if (_user.CanList)
                    {
                        files = Directory.EnumerateFiles(pathname);
                    }
                    else
                    {
                        files = new List<string>(new string[] { "您没有查看文件列表的权限" });
                    }
                }
                else
                {
                    files = new List<string>(new string[] {
                        "鸡你太美.doc",
                        "鸡你太美.xls",
                        "鸡你实在是太美.ppt",
                    });
                }

                foreach (string file in files)
                {
                    if (isFunny || (!_user.CanList))
                    {
                        list.Append(String.Format("-rwxr-xr-x 1 user group {0,13} Aug 31 00:00 {1}", 2333, file)).Append("\n");
                    }
                    else {
                        FileInfo f = new FileInfo(file);
                        list.Append(String.Format("-rwxr-xr-x 1 user group {0,13} Aug 31 00:00 {1}", f.Length, f.Name)).Append("\n");
                    }
                   
                }
                try
                {
                    _dataWriter.WriteLine(list.ToString().Trim());
                    _dataWriter.Flush();
                }
                catch (IOException ex)
                {
                    ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
                    return "550 Requested action not taken";
                }
            }
            
            _dataClient.Close();
            _dataClient = null;

            return "226 Transfer complete";
        }

        private void HandleRetrieve(IAsyncResult res)
        {
            string pathname = res.AsyncState as string;

            if (_passiveConn)
            {
                _dataClient = _passiveListener.EndAcceptTcpClient(res);
            }
            else
            {
                _dataClient.EndConnect(res);
            }

            using (NetworkStream dataStream = _dataClient.GetStream())
            {
                using (FileStream fs = new FileStream(pathname, FileMode.Open, FileAccess.Read))
                {
                    FileInfo fi = new FileInfo(pathname);
                    if(fs.Length==0 || CopyStream(fs, dataStream) > 0)
                    {
                        try
                        {
                            _writer.WriteLine("226 Closing data connection, file transfer succesful");
                            _writer.Flush();
                        }
                        catch(IOException ex)
                        {
                            ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
                        }
                    }
                }
            }
            _dataClient.Close();
            _dataClient = null;
        }

        private string Retrieve(string pathname)
        {
            pathname = NormalizeFilename(pathname);

            if(IsPathValid(pathname))
            {
                if(File.Exists(pathname))
                {
                    if (_passiveConn)
                    {
                        _passiveListener.BeginAcceptTcpClient(HandleRetrieve, pathname);
                    }
                    else
                    {
                        _dataClient = new TcpClient(_dataEndpoint.AddressFamily);
                        _dataClient.BeginConnect(_dataEndpoint.Address, _dataEndpoint.Port, HandleRetrieve, pathname);
                    }
                    return "150 Opening Passive mode data transfer for RETR";
                }
            }
            return "550 File Not Found";
        }

        private string Store(string pathname)
        {
            pathname = NormalizeFilename(pathname);

            if (pathname != null)
            {
                if (File.Exists(pathname) || Directory.Exists(pathname)) {
                    return "450 File already exists.";
                }
                
                if (_passiveConn)
                {
                    _passiveListener.BeginAcceptTcpClient(HandleStore, pathname);
                }
                else
                {
                    _dataClient = new TcpClient(_dataEndpoint.AddressFamily);
                    _dataClient.BeginConnect(_dataEndpoint.Address, _dataEndpoint.Port, HandleStore, pathname);
                }

                return "150 Opening Passive mode data transfer for STOR";
            }

            return "450 Requested file action not taken";
        }

        private void HandleStore(IAsyncResult res)
        {
            string pathname = res.AsyncState as string;
            
            if (_passiveConn)
            {
                _dataClient = _passiveListener.EndAcceptTcpClient(res);
            }
            else
            {
                _dataClient.EndConnect(res);
            }

            using (NetworkStream dataStream = _dataClient.GetStream())
            {
                using (FileStream fs = new FileStream(pathname, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096, FileOptions.SequentialScan))
                {
                    if(CopyStream(dataStream, fs) > 0)
                    {
                        try
                        {
                            _writer.WriteLine("226 Closing data connection, file transfer succesful");
                            _writer.Flush();
                        }
                        catch(IOException ex)
                        {
                            ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
                        }
                    }
                }
            }
            _dataClient.Close();
            _dataClient = null;
        }

        private string PrintWorkingDirectory()
        {
            string current = _currentDirectory.Replace(_user.Root, string.Empty).Replace('\\', '/');

            if (current.Length == 0)
            {
                current = "/";
            }

            return string.Format("257 \"{0}\" is current directory.", current); ;
        }

        private string GetSize(String path) {
            String filepath = NormalizeFilename(path);
            try
            {
                FileInfo file = new FileInfo(filepath);
                return "213 " + file.Length;
            }
            catch{
               
            }
            return "213 0";
        }

        #endregion

        #region SupportFunctions

        private long CopyStream(Stream input, Stream output)
        {
            if (_transferType == "I")
            {
                return CopyStreamImage(input, output, 4096);
            }
            else
            {
                return CopyStreamAscii(input, output, 4096);
            }
        }

        private long CopyStreamImage(Stream input, Stream output, int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int count = 0;
            long total = 0;

            while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                try
                {
                    output.Write(buffer, 0, count);
                    total += count;
                }
                catch(IOException ex)
                {
                    ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
                    return -1; 
                }                
            }

            return total;
        }

        private long CopyStreamAscii(Stream input, Stream output, int bufferSize)
        {
            char[] buffer = new char[bufferSize];
            int count = 0;
            long total = 0;

            using (StreamReader rdr = new StreamReader(input))
            {
                using (StreamWriter wtr = new StreamWriter(output, Encoding.GetEncoding(FtpServer.Encodings)))
                {
                    while ((count = rdr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        try
                        { 
                            wtr.Write(buffer, 0, count);
                            total += count;
                        }
                        catch (IOException ex)
                        {
                            ConsoleWriteLine(String.Format("[ERROR {0}@{1}] {2}", _user.Username, _user.RemoteAddress, ex.Message));
                            return -1;
                        }
                    }
                }
            }

            return total;
        }

        private string NormalizeFilename(string path)
        {
            if (path == null)
            {
                path = string.Empty;
            }

            if (path == "/")
            {
                return _user.Root;
            }
            else if (path.StartsWith("/"))
            {
                path = new FileInfo(Path.Combine(_user.Root, path.Substring(1))).FullName;
            }
            else
            {
                try
                {
                    path = new FileInfo(Path.Combine(_currentDirectory, path)).FullName;
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }

            return IsPathValid(path) ? path : null;
        }

        private bool IsPathValid(string path)
        {
            try
            {
                return path.StartsWith(_user.Root);
            }
            catch { return false; }
        }
        
        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_client != null)
                {
                    _client.Close();
                }

                if (_dataClient != null)
                {
                    _dataClient.Close();
                }

                if (_networkStream != null)
                {
                    _networkStream.Close();
                }

                if (_reader != null)
                {
                    _reader.Close();
                }

                if (_writer != null)
                {
                    _writer.Close();
                }
                if (_dataWriter != null) {
                    _dataWriter.Dispose();
                }
            }
            ConsoleWriteLine(String.Format("[LEAVE {0}@{1}] {2}", _user.Username, _user.RemoteAddress, "User quit"));
            if (!_isValidSession || _user.IsFake)
            {
                _parent.onIpDisturb(_user.RemoteAddress);
            }
            else {
                _parent.clearIpDisturb(_user.RemoteAddress);
            }
            _disposed = true;
        }

        public bool checkTimeout() {
            if ((!_user.LoggedIn) && SysClock.Mill - createTime > FtpServer.UnloginedTimeout * 1000L) {
                ConsoleWriteLine("[WARNING] Kicked a user that not logged in before timeout or is fake");
                this.Dispose();
                return true;
            }
            return false;
        }
        private void ConsoleWriteLine(string str)
        {
            try
            {
                _parent.ConsoleWriteLine(str);
            }
            catch { }
        }
    }
    static class SysClock
    {
        private static DateTime epoch = new DateTime(2019, 1, 1, 0, 0, 0);
        public static long Mill{
            get {
                return (long)((DateTime.Now - epoch).TotalMilliseconds);
            }
        }
    }
}
