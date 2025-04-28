using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        //@TK 미로 탐색
        public static void BJ2178()
        {
            //Data Setting
            string[] args = Console.ReadLine().Split();
            int mapY = int.Parse(args[0]);
            int mapX = int.Parse(args[1]);

            int[,] map = new int[mapX, mapY];
            bool[,] isVisted = new bool[mapX, mapY];

            for (int y = 0; y < mapY; y++)
            {
                char[] tiles = Console.ReadLine().ToCharArray();
                for (int x = 0; x < mapX; x++)
                {
                    if (tiles[x] == '0')
                    {
                        map[x, y] = 0;
                        isVisted[x, y] = true;
                    }
                    else if (tiles[x] == '1')
                    {
                        map[x, y] = 1;
                    }
                }
            }

            //Search : BFS 
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            Tuple<int, int> startNode = new Tuple<int, int>(0, 0);
            isVisted[0, 0] = true;
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                Tuple<int, int> node = queue.Dequeue();
                //adjacent 생성 : (상하좌우)
                //상
                if (node.Item2 /*Y*/ - 1 >= 0)
                {
                    if (isVisted[node.Item1, node.Item2 - 1] == false)
                    {
                        queue.Enqueue(new Tuple<int, int>(node.Item1, node.Item2 - 1));
                        isVisted[node.Item1, node.Item2 - 1] = true;
                        map[node.Item1, node.Item2 - 1] += map[node.Item1, node.Item2];
                    }
                }
                //하
                if (node.Item2 + 1 < mapY)
                {
                    if (isVisted[node.Item1, node.Item2 + 1] == false)
                    {
                        queue.Enqueue(new Tuple<int, int>(node.Item1, node.Item2 + 1));
                        isVisted[node.Item1, node.Item2 + 1] = true;
                        map[node.Item1, node.Item2 + 1] += map[node.Item1, node.Item2];
                    }
                }

                //좌
                if (node.Item1 - 1 >= 0)
                {
                    if (isVisted[node.Item1 - 1, node.Item2] == false)
                    {
                        queue.Enqueue(new Tuple<int, int>(node.Item1 - 1, node.Item2));
                        isVisted[node.Item1 - 1, node.Item2] = true;
                        map[node.Item1 - 1, node.Item2] += map[node.Item1, node.Item2];
                    }
                }
                //우
                if (node.Item1 + 1 < mapX)
                {
                    if (isVisted[node.Item1 + 1, node.Item2] == false)
                    {
                        queue.Enqueue(new Tuple<int, int>(node.Item1 + 1, node.Item2));
                        isVisted[node.Item1 + 1, node.Item2] = true;
                        map[node.Item1 + 1, node.Item2] += map[node.Item1, node.Item2];
                    }
                }
            }

            Console.WriteLine(map[mapX - 1, mapY - 1]);
        }
    }
}
