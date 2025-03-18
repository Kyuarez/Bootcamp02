using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TKPacket;

namespace Client
{
    public partial class Program
    {
        public static void Assign0318_2()
        {
            string imagePath = "./Data/ImageCopy.webp";
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.4"), 4000);
            server.Connect(iPEndPoint);
            Console.WriteLine("서버 연결 성공~!");

            //recv
            byte[] sizeBuffer = new byte[8];
            server.Receive(sizeBuffer, 0, sizeBuffer.Length, SocketFlags.None);
            long fileSize = BitConverter.ToInt64(sizeBuffer, 0);

            byte[] recvBuffer = new byte[4096];
            int recvLength;
            long totalReceived = 0;
            using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
            {
                while (totalReceived < fileSize &&
                       (recvLength = server.Receive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None)) > 0)
                {
                    fs.Write(recvBuffer, 0, recvLength);
                    totalReceived += recvLength;
                }
            }

            Console.WriteLine("전송 완료");
            Console.ReadKey();
            server.Close();

        }


        public static void Assign0318_1()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.4"), 4000);
            server.Connect(iPEndPoint);
            Console.WriteLine("서버 연결 성공~!");

            //send
            byte[] sendBuffer = new byte[1024];
            string sendMessage = "안녕하세요!";
            string sendJson = JsonConvert.SerializeObject(sendMessage);
            sendBuffer = Encoding.UTF8.GetBytes(sendJson);
            int sendLength = server.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);

            //recv
            byte[] recvBuffer = new byte[1024];
            int recvLength = server.Receive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None);
            string recvJson = Encoding.UTF8.GetString(recvBuffer);
            string recvMessage = JsonConvert.DeserializeObject<string>(recvJson);
            Console.WriteLine($"[서버] : {recvMessage}");

            Console.ReadKey();
            server.Close();
        }

        public static void SimpleClient()
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
