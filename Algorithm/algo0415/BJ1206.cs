using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program 
    { 
    
        public static StringBuilder sb1206 = new StringBuilder();
        public static void BJ1206()
        {
            //Data Setting
            string[] args = Console.ReadLine().Split();
            int vertexCount = int.Parse(args[0]);
            int edgeCount = int.Parse(args[1]);
            int start = int.Parse(args[2]);

            List<int>[] graph = new List<int>[vertexCount];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                string[] arg = Console.ReadLine().Split();
                int vertexA = int.Parse(arg[0]);
                int vertexB = int.Parse(arg[1]);
                graph[vertexA - 1].Add(vertexB);
                graph[vertexB - 1].Add(vertexA);
            }

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i].Sort();
            }

            //Logic
            bool[] isVisited = new bool[vertexCount];
            DFS1206(graph, isVisited, start);
            sb1206.AppendLine();
            isVisited = new bool[vertexCount];
            BFS1206(graph, isVisited, start);

            Console.WriteLine(sb1206.ToString());
        }

        public static void DFS1206(List<int>[] graph, bool[] isVisited, int start)
        {
            isVisited[start - 1] = true;
            sb1206.Append(start.ToString() + ' ');

            List<int> adjacents = graph[start - 1];
            for (int i = 0; i < adjacents.Count; i++)
            {
                int adjacent = adjacents[i];
                if (isVisited[adjacent - 1] == false)
                {
                    DFS1206(graph, isVisited, adjacent);
                }
            }
        }
        public static void BFS1206(List<int>[] graph, bool[] isVisited, int start)
        {
            isVisited[start - 1] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            sb1206.Append(start.ToString() + ' ');

            while (queue.Count > 0) 
            {
                int vertex = queue.Dequeue();
                List<int> adjacents = graph[vertex - 1];

                for(int i = 0; i < adjacents.Count; i++)
                {
                    int adjacent = adjacents[i];
                    if (isVisited[adjacent - 1] == false)
                    {
                        isVisited[adjacent - 1] = true;
                        queue.Enqueue(adjacent);
                        sb1206.Append(adjacent.ToString() + ' ');
                    }
                }
            }
        }
    }
}
