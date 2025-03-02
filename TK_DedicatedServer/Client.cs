using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TK_DedicatedServer
{

    public class Client
    {
        public static int dataBufferSize = 4096;
        public int id;
        public TCP tcp;
    
        public Client(int clientID)
        {
            id = clientID;
            tcp = new TCP(id);
        }
        public class TCP //@tk : 왜 굳이 내부에 클래스를 만들어서 별도 관리?
        {
            public TcpClient socket;

            private readonly int id;
            private NetworkStream stream;
            private byte[] receiveBuffer;


            public TCP(int id)
            {
                this.id = id;
            }

            public void Connect(TcpClient socket)
            {
                this.socket = socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                receiveBuffer = new byte[dataBufferSize];
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null); //@tk : Read vs BeginRead

                //TODO : Send welcome packet
            }

            private void ReceiveCallback(IAsyncResult result) 
            {
                try
                {
                    int byteLength = stream.EndRead(result);

                    if(byteLength <= 0)
                    {
                        //TODO : Disconnect
                        return;
                    }

                    byte[] data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    //TODO : Handle Data
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving TCP data : {ex}");
                    //TODO : Disconnect
                }
            }
        }
    }

}
