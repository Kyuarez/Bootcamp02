using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    //DFS(깊이 우선 탐색 1)
    public partial class Program
    {
        /*
         dfs(V, E, R) {  # V : 정점 집합, E : 간선 집합, R : 시작 정점
            visited[R] <- YES;  # 시작 정점 R을 방문 했다고 표시한다.
            for each x ∈ E(R)  # E(R) : 정점 R의 인접 정점 집합.(정점 번호를 오름차순으로 방문한다)
            if (visited[x] = NO) then dfs(V, E, x);
        */

        //vertex : 1은 인덱스 0번이다.
        public static StringBuilder sb24479 = new StringBuilder();
        public static long[] isVisited24479;
        public static void BJ24479()
        {
            //Input Data
            string[] args1 = Console.ReadLine().Split();
            long vertexCount = long.Parse(args1[0]);
            long edgeCount = long.Parse(args1[1]);
            long start = long.Parse(args1[2]);

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

            isVisited24479 = new long[vertexCount];
            long searchCount = 0;

            DFS24479(graph, vertexCount, edgeCount, start, ref searchCount);
            for (int i = 0; i < isVisited24479.Length; i++)
            {
                sb24479.AppendLine(isVisited24479[i].ToString());
            }

            Console.WriteLine(sb24479.ToString());
        }

        public static void DFS24479(List<long>[] graph, long vertexCount, long edgeCount, long start, ref long searchCount)
        {
            isVisited24479[start - 1] = ++searchCount;

            foreach (long adjacentVertex in graph[start - 1])
            {
                if (isVisited24479[adjacentVertex - 1] == 0)
                {
                    DFS24479(graph, vertexCount, edgeCount, adjacentVertex, ref searchCount);
                }
            }
        }
    }
}
