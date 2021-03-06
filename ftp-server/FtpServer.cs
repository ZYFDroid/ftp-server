﻿using System;
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
    class FtpServer : IDisposable
    {

        public event EventHandler<string> OnConsoleWriteLine;

        public static long UnloginedTimeout = 16;

        public static int MaxUserCount = 30;

        public static long limitedFileSizeMB = 0;

        public static int BanIpTrigger = 20;

        public static string Encodings = "GBK";

        public static long BanIpDuration = 1;

        public static int DisconnectInactiveTimeout = 10;

        public static bool enableSmartBanIp = true;

        public static int transferBufferSize =4096;

        public static bool useRecovery = true;

        internal SortedList<string, long> blockedIpAddress=new SortedList<string, long>();
        internal SortedList<string, int> blockingcount=new SortedList<string, int>();

        private TcpListener _listener = null;
        private bool _disposed;
        private bool _listening;
        private Thread _checkThread;
        public List<ClientConnection> _activeConnections;

        public FtpServer(){}

        public static int Port = 21;

        public bool Disposed {
            get { return _disposed; }
        }

        public bool Start(out SocketError code)
        {
            try
            {
                _activeConnections = new List<ClientConnection>();
                _listener = new TcpListener(IPAddress.Any, Port);
                _listening = true;
                _listener.Start();
                _checkThread = new Thread(checkUnloginedSession);
                _checkThread.Start();
                _listener.BeginAcceptTcpClient(HandleAcceptTcpClient, _listener);
                writelog("[Server] Server started");
                code = SocketError.Success;
                return true;
            }
            catch (SocketException ex) {
                writelog("[Error] "+ex.Message);
                code = ex.SocketErrorCode;
                return false;
            }
        }

        public void Stop()
        {

            _listening = false;
            _listener.Stop();

            _listener = null;
        }

        private void HandleAcceptTcpClient(IAsyncResult result)
        {
            if (_listening)
            {
                try
                {
                    _listener.BeginAcceptTcpClient(HandleAcceptTcpClient, _listener);
                    try
                    {
                        TcpClient client = _listener.EndAcceptTcpClient(result);

                        if (_activeConnections.Count >= MaxUserCount)
                        {
                            try
                            {
                                byte[] retn = Encoding.GetEncoding("GBK").GetBytes("220 鸡你太美\r\n");
                                client.GetStream().Write(retn, 0, retn.Length);
                            }
                            catch { }
                            client.Close();
                            return;
                        }
                        string ip = ((IPEndPoint)(client.Client.RemoteEndPoint)).Address.ToString();
                        if (checkIpBlocked(ip))
                        {
                            try
                            {
                                byte[] retn = Encoding.GetEncoding("GBK").GetBytes("220 鸡你太美\r\n");
                                client.GetStream().Write(retn, 0, retn.Length);
                            }
                            catch { }
                            client.Close();
                            return;
                        }

                        ClientConnection clientConnection = new ClientConnection(client, this);

                        _activeConnections.Add(clientConnection);

                        clientConnection.HandleClient();
                    }
                    catch (Exception ex) { writelog("[SERVER_ERROR] " + ex.Message); }
                }
                catch (Exception ex){ writelog("[TERM] "+ex.Message); Dispose(); }
            }
        }

        internal void writelog(string str) {
            try
            {
                OnConsoleWriteLine.Invoke(this, str);
            }
            catch { }
        }

        internal void onIpDisturb(string ip) {
            if (!enableSmartBanIp) {
                blockedIpAddress.Clear();
                return;
            }
            if (blockedIpAddress.ContainsKey(ip)) { return; }
            if (blockingcount.ContainsKey(ip))
            {
                blockingcount[ip]++;
                if (blockingcount[ip] > BanIpTrigger)
                {
                    blockingcount.Remove(ip);
                    blockedIpAddress.Add(ip, SysClock.Mill + BanIpDuration * 60000);
                    writelog("[IPBLOCKER] Blocked " + ip);
                }
            }
            else {
                blockingcount.Add(ip, 1);
            }
        }
        internal void clearIpDisturb(string ip)
        {
            blockingcount.Remove(ip);
            blockedIpAddress.Remove(ip);
        }

        internal bool checkIpBlocked(string ip) {
            if (!blockedIpAddress.ContainsKey(ip)) { return false; }
            List<KeyValuePair<string, long>> iplist = blockedIpAddress.ToList();
            foreach (KeyValuePair < string, long > ipinfo in iplist) {
                if (ipinfo.Value < SysClock.Mill) {
                    blockedIpAddress.Remove(ipinfo.Key);
                }
            }
            return blockedIpAddress.ContainsKey(ip);
        }

        private void checkUnloginedSession() {
            try
            {
                while (true)
                {
                    try
                    {
                        
                        for(int i=_activeConnections.Count-1;i>=0;i--) {
                            ClientConnection cln = _activeConnections[i];
                            cln.checkTimeout();
                            if (cln.Disposed) { _activeConnections.RemoveAt(i); }
                        }
                        Thread.Sleep(666);
                    }
                    catch { }
                }
            }
            catch { }
        }

        public int UserCount {
            get { return _activeConnections.Count; }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Stop();
                
                foreach (ClientConnection conn in _activeConnections)
                {
                   conn.Dispose();
                }
            }

            _disposed = true;
        }

        public void KickAll() {
            for (int i = _activeConnections.Count - 1; i >= 0; i--)
            {
                ClientConnection cln = _activeConnections[i];
                try
                {
                    cln.Dispose();
                }
                catch (Exception ex) {
                    writelog("[ERROR] "+ex.Message);
                }
            }


        }
    }
}
