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
    class FtpServer : IDisposable
    {
        public long unlogintimeout = 16000;

        public int userLimits = 30;

        private TcpListener _listener = null;
        private int _port;
        private bool _disposed;
        private bool _listening;
        private Thread _checkThread;
        public List<ClientConnection> _activeConnections;

        public FtpServer(int port)
        {
            _port = port;
        }

        public bool Disposed {
            get { return _disposed; }
        }

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, _port);


            _listening = true;
            _listener.Start();

            _activeConnections = new List<ClientConnection>();
            _checkThread = new Thread(checkUnloginedSession);
            _checkThread.Start();
            _listener.BeginAcceptTcpClient(HandleAcceptTcpClient, _listener);
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

                    TcpClient client = _listener.EndAcceptTcpClient(result);

                    if (_activeConnections.Count >= userLimits)
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
                catch (Exception ex){ Console.WriteLine(ex.Message);Dispose(); }
            }
        }

        private void checkUnloginedSession() {
            try
            {
                while (true)
                {
                    try
                    {
                        foreach(ClientConnection cln in _activeConnections) {
                            cln.checkTimeout();
                            if (cln.Disposed) { _activeConnections.Remove(cln); }
                        }
                        Thread.Sleep(2560);
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
    }
}
