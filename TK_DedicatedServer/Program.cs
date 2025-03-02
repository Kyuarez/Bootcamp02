namespace TK_DedicatedServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dedicated Server";

            DedicatedServer.Start(50, 26950);
            Console.ReadKey();
        }
    }
}
