using MessagePack;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TKPacket;
using Newtonsoft.Json;


namespace Server
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            Assign0318_2();
        }
        
    }
}
