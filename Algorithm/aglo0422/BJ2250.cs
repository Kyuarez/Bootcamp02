using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0422
{
    public partial class Program
    {
        public class Node2250
        {
            public int Data;
            public Node2250 Left;
            public Node2250 Right;
            public int Height;
            public int Row;

            public Node2250()
            {
                this.Data = -1;
            }
            public Node2250(int Data)
            {
                this.Data = Data;
            }


        }

        public static void BJ2250()
        {
            //Data Setting
            int nodeCount = int.Parse(Console.ReadLine()!);
            List<Node2250>[] tree = new List<Node2250>[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                string[] args = Console.ReadLine()!.Split();
                int parent = int.Parse(args[0]);
                int left = int.Parse(args[1]);
                int right = int.Parse(args[2]);

                Node2250 node = new Node2250(parent);

            }

            //중위 순회를 하면 열이 세팅이 될듯.

        }

        public static void InOrder(List<int>[] tree, int start)
        {
            
        }
    }
}
