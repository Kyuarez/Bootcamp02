using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public partial class Program
    {
        public static void OnUDPServer()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 6000);
            serverSocket.Bind(ipEndPoint);

            //Receive //@tk UDP는 흐름 제어를 하지 않아서 byte수가 중요하다. (헤더)
            byte[] recvBuffer = new byte[1024];
            EndPoint clientEndPoint = (EndPoint)ipEndPoint;
            int recvLength = serverSocket.ReceiveFrom(recvBuffer, ref clientEndPoint);

            //Send
            int sendLength = serverSocket.SendTo(recvBuffer, clientEndPoint);

            serverSocket.Close();
        }
    }
}
