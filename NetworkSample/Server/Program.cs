using MessagePack;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TKPacket;
using Newtonsoft.Json;


namespace Server
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            ByteOrderPollingServer();
        }
        
        
        static void ServerWithPacket()
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 4000);
            listenSocket.Bind(listenEndPoint);
            listenSocket.Listen(10);

            bool isRunning = true;
            while (isRunning)
            {
                Socket clientSocket = listenSocket.Accept();

                byte[] recvBuffer = new byte[1024];
                int RecvLength = clientSocket.Receive(recvBuffer);
                var deserializedPacket = MessagePackSerializer.Deserialize<TKPacketChat>(recvBuffer);
                if (RecvLength < 0)
                {
                    isRunning = false;
                }
                else if (RecvLength > 0)
                {
                    Console.WriteLine($"[클라이언트]: {deserializedPacket.Chat}");
                }

                clientSocket.Close();
            }

            listenSocket.Close();
        }
    }
}
