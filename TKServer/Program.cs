using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace TKServer
{

    public class Program
    {
        static void Main(string[] args)
        {
            TK_TcpServer server = new TK_TcpServer();
            server.OnServer(12345);
        }
    }

    public class TK_TcpServer
    {
        private TcpListener listener;
        private List<TcpClient> clients = new List<TcpClient>();
        private object lockObject = new object();

        public void OnServer(int port)
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
            Console.WriteLine($"[Server on] port : {port}");

            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                lock (lockObject)
                {
                    clients.Add(tcpClient);
                }

                Thread clientThread = new Thread(GetHandleClient);
                clientThread.IsBackground = true;
                clientThread.Start(tcpClient);
            }
        }

        private void GetHandleClient(object obj)
        {
            TcpClient client = (TcpClient) obj;
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                int byteCount;
                while ((byteCount = ns.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    Console.WriteLine($"[수신] {message}");
                    //다른 클라에게 동시 적용
                    BroadcastMessage(message, client);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 : {ex.Message}");
            }
            finally
            {   

                lock (lockObject)
                {
                    clients.Remove(client);
                }
                client.Close();
                Console.WriteLine("클라이언트 종료");
            }


        }

        private void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            lock (lockObject) 
            {
                try
                {
                    foreach (var client in clients) 
                    {
                        //if(client != sender)
                        //{
                        //    NetworkStream ns = client.GetStream();
                        //    ns.Write(data, 0, data.Length);
                        //}

                        NetworkStream ns = client.GetStream();
                        ns.Write(data, 0, data.Length);
                    }

                }
                catch
                {
                    Console.WriteLine("전송 실패");
                }
            }

        }

        public const string EchoMessage = "서버가 받았어요!";

    }
}
