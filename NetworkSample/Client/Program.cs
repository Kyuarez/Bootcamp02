using MessagePack;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TKPacket;
using Newtonsoft.Json;

namespace Client
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            //InputLoginSystem();
            ClientWithThread();
        }

        static void ClientWithPacket() 
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
            serverSocket.Connect(serverEndPoint);

            bool isRunning = true;
            while (isRunning)
            {
                string message = Console.ReadLine();

                if (message.CompareTo("Exit") == 0)
                {
                    isRunning = false;
                }

                var tkPacket = new TKPacketChat()
                {
                    Chat = message,
                };
                byte[] packet = MessagePackSerializer.Serialize(tkPacket);
                int packetSize = packet.Length;

                int sendLength = serverSocket.Send(packet, 0, packetSize, SocketFlags.None);
                if (sendLength < 0)
                {
                    isRunning = false;
                }
                else if (sendLength > 0)
                {
                    Console.Clear();
                }
            }

            serverSocket.Close();
        }
    }
}
