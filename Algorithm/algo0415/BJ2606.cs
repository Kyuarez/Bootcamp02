using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public static void BJ2606()
        {
            //Data
            int computerCount = int.Parse(Console.ReadLine()); //computer = vertex
            int edgeCount = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[computerCount];
            for (int i = 0; i < computerCount; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0;i < edgeCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                int vertexA = int.Parse(args[0]);
                int vertexB = int.Parse(args[1]);
                
                graph[vertexA - 1].Add(vertexB);
                graph[vertexB - 1].Add(vertexA);
            }

            //Logic
            int start = 1;
            bool[] isVisited = new bool[computerCount];
            isVisited[start - 1] = true;
            int searchCount = 0;
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                long vertex = queue.Dequeue();
                List<int> adjecents = graph[vertex - 1];
                for (int i = 0; i < adjecents.Count; i++)
                {
                    int adjacent = adjecents[i];
                    if (isVisited[adjacent - 1] == false)
                    {
                        isVisited[adjacent - 1] = true;
                        searchCount++;
                        queue.Enqueue(adjacent);
                    }
                }
            }

            Console.WriteLine(searchCount);
        }
    }
}
