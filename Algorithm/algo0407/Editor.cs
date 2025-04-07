using System.Text;

namespace algo0407
{
    public partial class Program
    {
        public static LinkedList<char> cmdResult;
        public static LinkedListNode<char> currentNode;

        public static void TKEditor()
        {            
            string sentence = Console.ReadLine();
            cmdResult = new LinkedList<char>(sentence);
            cmdResult.AddLast(' ');
            currentNode = cmdResult.Last;


            int cmdCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < cmdCount; i++) 
            {
                ProcessCommand(Console.ReadLine());
            }

            cmdResult.RemoveLast();

            StringBuilder sb = new StringBuilder();
            foreach (char c in cmdResult) 
            {
                sb.Append(c);
            }

            Console.WriteLine(sb.ToString());
        }

        public static void ProcessCommand(string cmd)
        {
            if(cmd == "L")
            {
                ProcessL();
            }
            else if (cmd == "D")
            {
                ProcessD();
            }
            else if(cmd == "B")
            {
                ProcessB();
            }
            else
            {
                string data = cmd.Split(' ')[1];
                ProcessP(data[0]);
            }
        }

        public static void ProcessL()
        {
            if(currentNode.Previous == null)
            {
                return;
            }

            currentNode = currentNode.Previous;
        }
        public static void ProcessD()
        {
            if (currentNode.Next == null)
            {
                return;
            }

            currentNode = currentNode.Next;
        }

        public static void ProcessB()
        {
            if (currentNode.Previous == null)
            {
                return;
            }

            cmdResult.Remove(currentNode.Previous);
            
        }
        public static void ProcessP(char data)
        {
            cmdResult.AddBefore(currentNode, data);
            
        }
    }
}
