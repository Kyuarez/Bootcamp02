using MessagePack;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TKPacket;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] oper = new string[]
            {
                "+",
                "-",
                "*",
                "/"
            };


            for (int i = 0; i < 10; i++)
            {
                Console.Title = "Client";

                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.4"), 4000);
                serverSocket.Connect(ipEndPoint);
                Console.WriteLine("[클라이언트] 연결 성공!");

                Random rand = new Random();
                var tkPacket = new TKPacketDoubleOperation() 
                {
                    PacketID = i,
                    Operand1 = rand.Next(0, 10000),
                    Operand2 = rand.Next(0, 10000),
                    Operator = oper[rand.Next(0, 4)],
                };
                byte[] serializedData = MessagePackSerializer.Serialize(tkPacket);

                //byte[] sendBuffer = new byte[1024];
                //string message = $"{rand.Next(0, 10000)} + {rand.Next(0, 10000)}";
                //sendBuffer = Encoding.UTF8.GetBytes(message);
                //int sendLength = serverSocket.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
                int sendLength = serverSocket.Send(serializedData, 0, serializedData.Length, SocketFlags.None);

                byte[] recvBuffer = new byte[1024];
                int recvLength = serverSocket.Receive(recvBuffer);
                Console.WriteLine(Encoding.UTF8.GetString(recvBuffer));

                Console.ReadKey();
                Console.WriteLine("[클라이언트] 종료!");
                serverSocket.Close();
            }
        }
    }
}
