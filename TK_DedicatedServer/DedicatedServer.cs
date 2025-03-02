using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TK_DedicatedServer
{
    public class DedicatedServer
    {
        public static int MaxPlayer { get; private set; } //왜 다 static으로 했을까? Dedicated Server와 연관이 있을까?
        public static int Port { get; private set; }

        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();

        private static TcpListener tcpListener;

        public static void Start(int maxPlayer, int port)
        {
            MaxPlayer = maxPlayer;
            Port = port;

            InitializeServerData();

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptSocket(new AsyncCallback(TCPConnectCallback), null); //@tk :beginAcceptSocket? and AsyncCallback의 사용법

            Console.WriteLine($"server started on port({Port}).");
        }

        private static void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = tcpListener.EndAcceptTcpClient(result); //@tk : EndAcceptTcpClient ?
            tcpListener.BeginAcceptSocket(new AsyncCallback(TCPConnectCallback), null); //@tk : 메소드 안에서 메소드 호출? 왜?

            for (int i = 0; i < MaxPlayer; i++)
            {
                if (clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(client);
                    return;
                }
            }

            Console.WriteLine($"{client.Client.RemoteEndPoint} failed to connect: server is full!");
        }

        private static void InitializeServerData()
        {
            for (int i = 0; i < MaxPlayer; i++)
            {
                clients.Add(i, new Client(i));
            }
        }
    }
}
