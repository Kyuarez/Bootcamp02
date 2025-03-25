using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

[Serializable]
public class LoginPacket
{
    public string code;
    public string id;
    public string password;
}
[Serializable]
public class SignupPacket
{
    public string code;
    public string id;
    public string password;
    public string name;
    public string email;
}
[Serializable]
public class ChatPacket
{
    public string code;
    public string id;
    public string message;
}

public class TKNetworkManager : TSingleton<TKNetworkManager>    
{
    private Socket serverSocket;
    private IPEndPoint serverEndPoint;

    private Thread recvThread;

    private UIChat uiChat;
    private Queue<string> chatQueue;

    private void Start()
    {
        uiChat = FindAnyObjectByType<UIChat>();
        chatQueue = new Queue<string>();

        ConnectedToServer();
    }

    private void RecvPacket()
    {
        while (true)
        {
            byte[] lengthBuffer = new byte[2];

            int RecvLength = serverSocket.Receive(lengthBuffer, 2, SocketFlags.None);
            ushort length = BitConverter.ToUInt16(lengthBuffer, 0);
            length = (ushort)IPAddress.NetworkToHostOrder((short)length);
            byte[] recvBuffer = new byte[4096];
            RecvLength = serverSocket.Receive(recvBuffer, length, SocketFlags.None);

            string jsonString = Encoding.UTF8.GetString(recvBuffer);
            JObject clientData = JObject.Parse(jsonString);
            string code = clientData.Value<String>("code");

            if(code == "Chat")
            {
                string id = clientData.Value<String>("id");
                string message = clientData.Value<String>("message");
                string data = $"[{id}] : {message}";
                chatQueue.Enqueue(data);
            }

            Debug.Log(jsonString);
            Thread.Sleep(10);
            //Parsing
        }
    }

    private void SendPacket(string message)
    {
        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
        ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

        byte[] headerBuffer = BitConverter.GetBytes(length);

        byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];
        Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
        Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);
        int SendLength = serverSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);

    }

    private void ConnectedToServer()
    {
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
        serverSocket.Connect(serverEndPoint);

        recvThread = new Thread(new ThreadStart(RecvPacket));
        recvThread.IsBackground = true;
        recvThread.Start();
    }

    public void OnLogin(LoginPacket packet)
    {
        SendPacket(JsonUtility.ToJson(packet));
    }

    public void OnSignup(SignupPacket packet)
    {
        SendPacket(JsonUtility.ToJson(packet));
    }
    public void OnChat(ChatPacket packet)
    {
        SendPacket(JsonUtility.ToJson(packet));
    }
    public void OnLogin(JObject jsonMessage)
    {
        SendPacket(jsonMessage.ToString());
    }

    public void OnSignup(JObject jsonMessage) 
    {
        SendPacket(jsonMessage.ToString());
    }

    private void Update()
    {
        if(chatQueue.Count > 0)
        {
            string message = chatQueue.Dequeue();
            uiChat.UpdateChat(message);
        }
    }

    private void OnApplicationQuit()
    {
        if(recvThread != null)
        {
            recvThread.Abort();
        }

        if(serverSocket != null)
        {
            serverSocket.Shutdown(SocketShutdown.Both);
            serverSocket.Close();
        }
    }
}
