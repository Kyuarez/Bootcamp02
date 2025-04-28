using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoPath
{
    public partial class Program
    {
        const int INF = 123456789; //무한 값
        private static int[][] graph;

        static void ConstructGraph()
        {
            graph = new int[7][];

            graph[0] = new int[] { 0, 7, INF, INF, 3, 10, INF };
            graph[1] = new int[] { 7, 0, 4, 10, 2, 6, INF };
            graph[2] = new int[] { INF, 4, 0, 2, INF, INF, INF };
            graph[3] = new int[] { INF, 10, 2, 0, 11, 9, 4 };
            graph[4] = new int[] { 3, 2, INF, 11, 0, INF, 5 };
            graph[5] = new int[] { 10, 6, INF, 9, INF, 0, INF };
            graph[6] = new int[] { INF, INF, INF, 4, 5, INF, 0 };
        }

        //경유지 : int[] path  : 자기가 누구를 지나쳐 왔는지
        //path[i] start -> i 경유한 정점들
        //path[1] = 4
        //path[6] = 4
        //path[5] = 0
        //{0, 4, 1, 2, 0, 0, 4}

        //최단 거리 구하는 메소드 (시작 정점, 끝 정점 : 출력은 최단거리)
        public static int TKDijkstra(int start, int end, out int[] path)
        {
            //start에서 다른 모든 정점까지의 거리를 저장할 배열
            int[] dist = new int[7];
            path = new int[7];
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = -1;
            }

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = (i == start) ? 0 : INF;
            }

            path[start] = start;

            //초기 값 세팅
            for(int count = 0; count < dist.Length; count++)
            {
                //최단 거리 찾을 때 가지 반복
                //방문하지 않은 정점 중에서 dist가 최소인 정점 찾기
                PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
                minHeap.Enqueue(start, dist[start]);
                while(minHeap.Count > 0)
                {
                    //다음에 방문할 정점을 우선순위 큐에서 가지고 온다.
                    int adjacent = minHeap.Dequeue();

                    //dist 업데이트(next 경유해서 i번째 노드로 가는게 빠른지)
                    for (int v = 0; v < graph[adjacent].Length; v++)
                    {
                        int distViaNext = dist[adjacent] + graph[adjacent][v]; //start -> next -> v
                        if(distViaNext < dist[v])
                        {
                            dist[v] = distViaNext;
                            path[v] = adjacent;
                            minHeap.Enqueue(v, dist[v]);
                        }
                    }
                }
            }

            return dist[end];
        }

    }
}
