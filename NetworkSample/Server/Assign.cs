using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using TKPacket;

namespace Server
{
    public partial class Program
    {
        public static void ByteOrderServer()
        {

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 4000);

            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10);

            Socket clientSocket = listenSocket.Accept();

            //[][] [][][][][][]

            //패킷 길이 받기(header)
            byte[] headerBuffer = new byte[2];
            int RecvLength = clientSocket.Receive(headerBuffer, 2, SocketFlags.None);
            short packetlength = BitConverter.ToInt16(headerBuffer, 0);
            packetlength = IPAddress.NetworkToHostOrder(packetlength);


            //[][][][][]
            //실제 패킷(header 길이 만큼)
            byte[] dataBuffer = new byte[4096];
            RecvLength = clientSocket.Receive(dataBuffer, packetlength, SocketFlags.None);

            string JsonString = Encoding.UTF8.GetString(dataBuffer);

            Console.WriteLine(JsonString);

            //Custom 패킷 만들기
            //다시 전송 메세지
            string message = "{ \"message\" : \"클라이언트 받고 서버꺼 추가.\"}";
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

            //길이  자료
            //[][] [][][][][][][][]
            headerBuffer = BitConverter.GetBytes(length);

            //[][][][][][][][][][][]
            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];

            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

            int SendLength = clientSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);


            clientSocket.Close();
            listenSocket.Close();
        }

        public static void Assign0318_2()
        {
            string imagePath = "./Data/Image.webp";

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.4"), 4000);
            listener.Bind(listenEndPoint);


            listener.Listen(1000);

            bool isRunning = true;
            while (isRunning)
            {
                Socket client = listener.Accept();
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                long fileSize = imageBytes.Length;

                byte[] sizeBuffer = BitConverter.GetBytes(fileSize);
                int sendHeaderLength = client.Send(sizeBuffer, 0, sizeBuffer.Length, SocketFlags.None);

                int chunkSize = 4096;
                int offset = 0;
                while (offset < fileSize)
                {
                    int bytesToSend = (int)Math.Min(chunkSize, fileSize - offset);
                    int sendLength = client.Send(imageBytes, offset, bytesToSend, SocketFlags.None);
                    offset += bytesToSend;
                }

                client.Close();
            }
            listener.Close();
        }

        public static void Assign0318_1()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.4"), 4000);
            listener.Bind(listenEndPoint);


            listener.Listen(1000);

            bool isRunning = true;
            while (isRunning)
            {
                Socket client = listener.Accept();

                //Receive
                byte[] recvBuffer = new byte[1024];
                int recvLength = client.Receive(recvBuffer);
                if (recvLength < 0)
                {
                    isRunning = false;
                }
                else if (recvLength > 0)
                {
                    //Json 
                    string recvJson = Encoding.UTF8.GetString(recvBuffer, 0, recvLength);
                    string recvMessage = JsonConvert.DeserializeObject<string>(recvJson);
                    Console.WriteLine($"[클라이언트] : {recvMessage}");
                }

                //Send
                byte[] sendBuffer = new byte[1024];
                string sendMessage = "반가워요";
                string sendJson = JsonConvert.SerializeObject(sendMessage);
                sendBuffer = Encoding.UTF8.GetBytes(sendJson, 0, sendJson.Length);
                int SendLength = client.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
                if (SendLength < 0)
                {
                    isRunning = false;
                }

                client.Close();
            }
            listener.Close();
        }

        public static void SimpleServer()
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.4"), 4000);
            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10); //@tk : 10개씩 클라 요청 볼게
            Console.WriteLine("[서버] 서버 오픈 했어요! ㅇㅅㅇ!");

            bool isRunning = true;
            while (isRunning)
            {
                //@tk 동기 방식 (누가 오면 멈추기)
                Socket clientSocket = listenSocket.Accept();

                byte[] recvBuffer = new byte[1024];
                int RecvLength = clientSocket.Receive(recvBuffer);
                var deserializedPacket = MessagePackSerializer.Deserialize<TKPacketDoubleOperation>(recvBuffer);
                if (RecvLength < 0)
                {
                    isRunning = false;
                }
                else if (RecvLength > 0)
                {
                    Console.WriteLine("[클라이언트] 패킷 보냈어요");
                    Console.WriteLine($"[클라이언트] 패킷 ID : {deserializedPacket.PacketID}");
                    Console.WriteLine($"[클라이언트] Operand1 : {deserializedPacket.Operand1}");
                    Console.WriteLine($"[클라이언트] Operand2 : {deserializedPacket.Operand2}");
                    Console.WriteLine($"[클라이언트] Operator : {deserializedPacket.Operator}");
                }

                byte[] sendBuffer = new byte[1024];
                string message = $"결과값 : {deserializedPacket.Execute()}";
                sendBuffer = Encoding.UTF8.GetBytes(message);
                int SendLength = clientSocket.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
                if (SendLength < 0)
                {
                    isRunning = false;
                }

                //@tk 이거 안하면 계속 기다림(3분 정도) : keep alive time
                clientSocket.Close();
            }

            Console.WriteLine("[서버] 서버가 종료되었습니다.");
            listenSocket.Close();
        }
    }
}
