using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class TK_Client 
{
    private TcpClient tcpClient;
    private NetworkStream ns;
    private Thread receiveThread;
    private bool isConnected = false;

    private Queue<string> messageQueue = new Queue<string>();
    public Queue<string> MessageQueue
    {
        get { return messageQueue; }
    }

    public void Connect(string ip, int port)
    {
        try
        {
            tcpClient = new TcpClient(ip, port);
            ns = tcpClient.GetStream();
            isConnected = true;
            Console.WriteLine("서버에 연결됨");

            receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        catch (Exception e) 
        {
            Console.WriteLine("서버 연결 실패: " + e.Message);
        }
    }

    private void ReceiveMessages()
    {
        byte[] buffer = new byte[1024];
        int byteCount;

        try
        {
            while (isConnected)
            {
                byteCount = ns.Read(buffer, 0, buffer.Length);
                if (byteCount <= 0) continue;

                string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine("서버로부터 수신: " + message);
                messageQueue.Enqueue(message);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("수신 오류: " + e.Message);
        }
    }

    public void SendMessage(string message)
    {
        if (!isConnected || ns == null)
        {
            return;
        }

        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            ns.Write(data, 0, data.Length);
            Console.WriteLine("서버로 전송: " + message);
        }
        catch (Exception e)
        {
            Console.WriteLine("메시지 전송 실패: " + e.Message);
        }
    }

    public void Disconnect()
    {
        isConnected = false;
        receiveThread?.Abort();
        ns?.Close();
        tcpClient?.Close();
    }

    
}
