using MessagePack;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TKPacket;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

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
                else if(RecvLength > 0)
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
