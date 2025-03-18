using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public partial class Program
    {
        public static void OnUDPClient() 
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 6000);

            byte[] sendBuffer = new byte[1024];
            string message = "안녕하세요";
            sendBuffer = Encoding.UTF8.GetBytes(message);
            //Send
            int sendLength = serverSocket.SendTo(sendBuffer, sendBuffer.Length, SocketFlags.None, serverEndPoint);

            byte[] recvBuffer = new byte[1024];
            EndPoint remotEndPoint = (EndPoint)serverEndPoint;
            int recvLength = serverSocket.ReceiveFrom(recvBuffer, ref remotEndPoint);
            string recvMsg = Encoding.UTF8.GetString(recvBuffer);
            Console.WriteLine(recvMsg);
            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
