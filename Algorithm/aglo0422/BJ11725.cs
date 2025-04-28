using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0422
{
    public partial class Program
    {
       
        public static StringBuilder sb11725 = new StringBuilder();
        public static void BJ11725()
        {
            int nodeCount = int.Parse(Console.ReadLine()!);
            List<int>[] adjacents = new List<int>[nodeCount];
            for (int i = 0; i < adjacents.Length; i++)
            {
                adjacents[i] = new List<int>();
            }

            int[] parents = new int[nodeCount + 1];

            for (int i = 0; i < nodeCount - 1; i++)
            {
                string[] arg = Console.ReadLine()!.Split();
                int first = int.Parse(arg[0]);
                int second = int.Parse(arg[1]);

                adjacents[first - 1].Add(second);
                adjacents[second - 1].Add(first);
            }

            //Root = 1
            bool[] isVisited = new bool[nodeCount];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1); //Root
            isVisited[0] = true;

            while (queue.Count > 0)
            {
                int search = queue.Dequeue();

                foreach (int adjacent in adjacents[search - 1])
                {
                    if (isVisited[adjacent - 1] == true)
                    {
                        continue;
                    }   
                    //adjacent는 자식
                    parents[adjacent] = search;
                    isVisited[adjacent - 1] = true;
                    queue.Enqueue(adjacent);
                }
            }

            for (int i = 2; i < parents.Length; i++) 
            {
                sb11725.AppendLine(parents[i].ToString());
            }
            
            Console.WriteLine(sb11725.ToString());
        }
    }
}
