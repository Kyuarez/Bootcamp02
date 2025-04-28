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

            int start = 1;
            bool[] isVisited = new bool[computerCount];
            //Logic
            #region BFS
            /*
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
            */
            #endregion

            #region DFS
            int result = 0;
            result = DFS2606(isVisited, graph, start);
            Console.WriteLine(result);
            #endregion
        }

        public static int DFS2606(bool[] isVisited, List<int>[] graph, int start)
        {
            isVisited[start - 1] = true;
            int count = 0; 
            //추가 

            foreach (int adjacent in graph[start - 1])
            {
                if (isVisited[adjacent - 1] == false)
                {
                    isVisited[adjacent - 1] = true;
                    count += DFS2606(isVisited, graph, adjacent) + 1;
                }
            }
            return count;
        }
    }
}
