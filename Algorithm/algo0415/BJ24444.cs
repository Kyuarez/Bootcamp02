using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    //BFS
    /*
     bfs(V, E, R) {  # V : 정점 집합, E : 간선 집합, R : 시작 정점
        for each v ∈ V - {R}
            visited[v] <- NO;
        visited[R] <- YES;  # 시작 정점 R을 방문 했다고 표시한다.
        enqueue(Q, R);  # 큐 맨 뒤에 시작 정점 R을 추가한다.
        while (Q ≠ ∅) {
            u <- dequeue(Q);  # 큐 맨 앞쪽의 요소를 삭제한다.
            for each v ∈ E(u)  # E(u) : 정점 u의 인접 정점 집합.(정점 번호를 오름차순으로 방문한다)
                if (visited[v] = NO) then {
                    visited[v] <- YES;  # 정점 v를 방문 했다고 표시한다.
                    enqueue(Q, v);  # 큐 맨 뒤에 정점 v를 추가한다.
                }
        }
    }
     */
    public partial class Program
    {
        public static long[] isVisited24444;
        public static StringBuilder sb24444 = new StringBuilder();

        public static void BJ24444()
        {
            //data Setting
            string[] arg1 = Console.ReadLine().Split();
            long vertexCount = long.Parse(arg1[0]);
            long edgeCount = long.Parse(arg1[1]);
            long start = long.Parse(arg1[2]);

            List<long>[] graph = new List<long>[vertexCount];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<long>();
            }
            for (int i = 0; i < edgeCount; i++) 
            {
                string[] args = Console.ReadLine().Split();
                long vertexA = long.Parse(args[0]);
                long vertexB = long.Parse(args[1]);
                graph[vertexA - 1].Add(vertexB);
                graph[vertexB - 1].Add(vertexA);
            }
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i].Sort();
            }

            isVisited24444 = new long[vertexCount];
            long searchCount = 0;
            //long edgeCount 
            BFS24444(graph, vertexCount, edgeCount, start, ref searchCount);

            for (int i = 0; i < isVisited24444.Length; i++)
            {
                sb24444.AppendLine(isVisited24444[i].ToString());
            }

            Console.WriteLine(sb24444.ToString());
        }

        public static void BFS24444(List<long>[] graph, long vertexCount, long edgeCount, long start, ref long searchCount)
        {
            isVisited24444[start - 1] = ++searchCount;
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(start);

            while(queue.Count > 0)
            {
                long vertex = queue.Dequeue();
                List<long> adjecents = graph[vertex - 1];
                for (int i = 0; i < adjecents.Count; i++)
                {
                    long adjacent = adjecents[i];
                    if (isVisited24444[adjacent - 1] == 0)
                    {
                        isVisited24444[adjacent - 1] = ++searchCount;
                        queue.Enqueue(adjacent);
                    }
                }
            }

        }
        
    }        
}
