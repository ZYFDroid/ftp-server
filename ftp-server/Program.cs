using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftp_server
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            FtpServer ftpServer = new FtpServer(21);

            Login.AddUser(new User("admin", "123456", "lrwd", "D:\\FTP",true));
            Login.AddUser(new User("anonymous", "", "lr", "D:\\FTP\\Public",true));
            for (int i = 1; i <= 30; i++) {
                Login.AddUser(new User(String.Format("s66{0:D2}",i), "password", "lrwd", "D:\\FTP\\s66"+String.Format("{0:D2}",i), true));
            }


            ftpServer.Start();
            Console.WriteLine("Server started");
            string title = "鸡你太美~~，鸡你太美~~，鸡你实在是太美~~! ";
            int start = 0;
            while (!ftpServer.Disposed)
            {
                if (ftpServer.UserCount > 0)
                {
                    Console.Title = title.Substring(start, title.Length - start) + title.Substring(0, start);
                    start += 1;
                    if (start >= title.Length) { start = 0; }
                    try
                    {
                        System.Threading.Thread.Sleep(1000 / ftpServer.UserCount + 10);
                    }
                    catch { }
                }
                else {
                    Console.Title = "鸡你太美FTP服务器";
                    start = 0;
                    System.Threading.Thread.Sleep(1000);
                }
                
            }

        }
    }
}
