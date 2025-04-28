using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace algoPath
{
    public partial class Program
    {

        const int MAX_Y = 10;
        const int MAX_X = 10;
        static char[][] map = new char[MAX_Y][];

        public static int startX, startY, endX, endY;

        public class AstarNode
        {
            public int X;
            public int Y;
            public int F;
            public AstarNode Adjacent;

            
        }

        //H(x)
        public static int GetMDistance(int fromX, int fromY, int toX, int toY)
        {
            return Math.Abs(toX - fromX) + Math.Abs(toY - fromY);
        }

        // 맵을 구성한다.
        static void ConstructAstarMap()
        {
            map[0] = "          ".ToCharArray();
            map[1] = "          ".ToCharArray();
            map[2] = "          ".ToCharArray();
            map[3] = "    #     ".ToCharArray();
            map[4] = " S  #  G  ".ToCharArray();
            map[5] = "    #     ".ToCharArray();
            map[6] = "          ".ToCharArray();
            map[7] = "          ".ToCharArray();
            map[8] = "          ".ToCharArray();
            map[9] = "          ".ToCharArray();
        }

        public static void PrintMap()
        {
            for (int y = 0; y < MAX_Y; y++)
            {
                for (int x = 0; x < MAX_X; x++)
                {
                    Console.Write(map[y][x]);
                }
                Console.WriteLine();
            }
        }

        public static void FindStartAndEnd()
        {
            for (int y = 0; y < MAX_Y; y++)
            {
                for (int x = 0; x < MAX_X; x++)
                {
                    if (map[y][x] == 'S')
                    {
                        startX = x;
                        startY = y;
                    }
                    else if (map[y][x] == 'G')
                    {
                        endX = x;
                        endY = y;
                    }
                }
            }
        }

        public static void TKAstar()
        {
            AstarNode[,] path = new AstarNode[MAX_Y, MAX_X];
            for (int y = 0; y < MAX_Y; y++)
            {
                for (int x = 0; x < MAX_X; x++)
                {
                    path[y, x] = new AstarNode() { X = x, Y = y, F = 123456789 };
                }
            }

            //우선순위 큐 생성
            PriorityQueue<AstarNode, int> minHeap = new PriorityQueue<AstarNode, int>();
            minHeap.Enqueue(path[startY, startX], 0);

            //8 방향 탐색(상하좌우 : 10, 대각선 : 14)
            int[] dy = { -1, -1, -1, 0, 1,  1,  1,  0};
            int[] dx = { -1,  0,  1, 1, 1,  0, -1,-1};
            int[] cost = { 14, 10, 14, 10, 14, 10, 14, 10 };

            //경로를 찾을 때 까지 반복
            while (minHeap.Count > 0) 
            {
                //방문 정점 받기
                AstarNode next = minHeap.Dequeue();

                //8방향 탐색
                for (int i = 0; i < 8; i++)
                {
                    int nx = next.X + dx[i];
                    int ny = next.Y + dy[i];

                    if(nx >= 0 && nx < MAX_X && ny >= 0 && ny < MAX_Y)
                    {
                        continue;
                    }
                    if (map[ny][nx] == '#')
                    {
                        continue;
                    }

                    //F(x) = g(x) + h(x)
                    int f = cost[i] + 10 * GetMDistance(nx, ny, endX, endY);
                    AstarNode newNode = path[ny, nx];
                    //부분 최단 경로 찾아서 heap 삽입
                    if (newNode.F < f)
                    {
                        newNode.F = f;
                        newNode.Adjacent = next;
                        minHeap.Enqueue(newNode, newNode.F);
                    }
                }
            }


            AstarNode current = path[endY, endX].Adjacent;
            while (true)
            {
                if (current.X == startX && current.Y == startY)
                {
                    break;
                }
                
                map[current.Y][current.X] = '*';
                current = current.Adjacent;
            }

        }

    }
}
