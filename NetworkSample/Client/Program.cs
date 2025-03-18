using MessagePack;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TKPacket;
using Newtonsoft.Json;

namespace Client
{
    public partial class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Client";

            Assign0318_2();
        }
    }
}
