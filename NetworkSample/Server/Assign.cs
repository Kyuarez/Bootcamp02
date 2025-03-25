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
using Newtonsoft.Json.Linq;
using MySqlConnector;

namespace Server
{
    public partial class Program
    {
        static Socket listenSocket;

        static List<Socket> clientSockets = new List<Socket>();
        //static List<Thread> threadManager = new List<Thread>();

        static object _lock = new object();

        static void SendPacket(Socket toSocket, string message)
        {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

            byte[] headerBuffer = BitConverter.GetBytes(length);

            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];
            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);
            int SendLength = toSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);
            
        }

        static void AcceptThread()
        {
            while (true)
            {
                Socket clientSocket = listenSocket.Accept();

                lock (_lock)
                {
                    clientSockets.Add(clientSocket);
                }
                Console.WriteLine($"Connect client : {clientSocket.RemoteEndPoint}");

                Thread workThread = new Thread(new ParameterizedThreadStart(WorkThread));
                workThread.IsBackground = true;
                workThread.Start(clientSocket);
                //threadManager.Add(workThread);

                
            }
        }

        static void WorkThread(Object clientObjectSocket)
        {

            Socket clientSocket = clientObjectSocket as Socket;

            while (true)
            {
                try
                {
                    byte[] headerBuffer = new byte[2];
                    int RecvLength = clientSocket.Receive(headerBuffer, 2, SocketFlags.None);
                    if (RecvLength > 0)
                    {
                        short packetlength = BitConverter.ToInt16(headerBuffer, 0);
                        packetlength = IPAddress.NetworkToHostOrder(packetlength);

                        byte[] dataBuffer = new byte[4096];
                        RecvLength = clientSocket.Receive(dataBuffer, packetlength, SocketFlags.None);
                        string JsonString = Encoding.UTF8.GetString(dataBuffer);
                        Console.WriteLine(JsonString);

                        string connectionString = "server=localhost;user=root;database=membership;password=0575";
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                        JObject clientData = JObject.Parse(JsonString);
                        string code = clientData.Value<String>("code");

                        try
                        {
                            if (code.CompareTo("Login") == 0)
                            {
                                string userId = clientData.Value<String>("id");
                                string userPassword = clientData.Value<String>("password");

                                mySqlConnection.Open();
                                MySqlCommand mySqlCommand = new MySqlCommand();
                                mySqlCommand.Connection = mySqlConnection;

                                mySqlCommand.CommandText = "select * from users where user_id = @user_id and user_password = @user_password";
                                mySqlCommand.Prepare();
                                mySqlCommand.Parameters.AddWithValue("@user_id", userId);
                                mySqlCommand.Parameters.AddWithValue("@user_password", userPassword);

                                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                                if (dataReader.Read())
                                {
                                    //로그인 성공
                                    JObject result = new JObject();
                                    result.Add("code", "loginresult");
                                    result.Add("message", "success");
                                    result.Add("name", dataReader["name"].ToString());
                                    result.Add("email", dataReader["email"].ToString());
                                    SendPacket(clientSocket, result.ToString());
                                }
                                else
                                {
                                    //로그인 실패
                                    JObject result = new JObject();
                                    result.Add("code", "loginresult");
                                    result.Add("message", "failed");
                                    SendPacket(clientSocket, result.ToString());
                                }


                            }
                            else if (code.CompareTo("Signup") == 0)
                            {
                                string userId = clientData.Value<String>("id");
                                string userPassword = clientData.Value<String>("password");
                                string name = clientData.Value<String>("name");
                                string email = clientData.Value<String>("email");

                                mySqlConnection.Open();
                                MySqlCommand mySqlCommand2 = new MySqlCommand();
                                mySqlCommand2.Connection = mySqlConnection;

                                mySqlCommand2.CommandText = "insert into users (user_id, user_password, name, email) values ( @user_id, @user_password, @name, @email)";
                                mySqlCommand2.Prepare();
                                mySqlCommand2.Parameters.AddWithValue("@user_id", userId);
                                mySqlCommand2.Parameters.AddWithValue("@user_password", userPassword);
                                mySqlCommand2.Parameters.AddWithValue("@name", name);
                                mySqlCommand2.Parameters.AddWithValue("@email", email);
                                mySqlCommand2.ExecuteNonQuery();

                                //가입 성공했습니다.
                                JObject result = new JObject();
                                result.Add("code", "signupresult");
                                result.Add("message", "success");
                                SendPacket(clientSocket, result.ToString());
                            }
                            else if(code.CompareTo("Chat") == 0)
                            {
                                string message = clientData.Value<String>("message");
                                string id = clientData.Value<String>("id");
                                Console.WriteLine(message);

                                JObject result = new JObject();
                                result.Add("code", "Chat");
                                result.Add("id", id);
                                result.Add("message", message);

                                lock (_lock)
                                {
                                    foreach (Socket client in clientSockets)
                                    {
                                        SendPacket(client, result.ToString());
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            JObject result = new JObject();
                            result.Add("code", "signupresult");
                            result.Add("message", "failed");
                            SendPacket(clientSocket, result.ToString());
                        }
                        finally
                        {
                            mySqlConnection.Close();
                        }
                    }
                    else
                    {
                        string message = "{ \"message\" : \" Disconnect : " + clientSocket.RemoteEndPoint + " \"}";

                        SendPacket(clientSocket, message);

                        lock (_lock)
                        {
                            clientSockets.Remove(clientSocket);
                        }

                        clientSocket.Close();




                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error 낸 놈 : {e.Message} {clientSocket.RemoteEndPoint}");

                    string message = "{ \"message\" : \" Disconnect : " + clientSocket.RemoteEndPoint + " \"}";

                    SendPacket(clientSocket, message);

                    lock (_lock)
                    {
                        clientSockets.Remove(clientSocket);
                    }

                    clientSocket.Close();

                    return;
                }
            }
        }

        public static void ByteOrderPollingServer()
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10);

            Thread acceptThread = new Thread(new ThreadStart(AcceptThread));
            acceptThread.IsBackground = true;
            acceptThread.Start();  

            acceptThread.Join();

            listenSocket.Close();
        }

        public static void ByteOrderServer()
        {

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

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
