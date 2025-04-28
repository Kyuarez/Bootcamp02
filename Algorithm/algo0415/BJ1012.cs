using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public struct Tile
        {
            public int x;
            public int y;

            public Tile(int x, int y) 
            {
                this.x = x;
                this.y = y;
            }
        }

        public static StringBuilder sb1012 = new StringBuilder();
        public static void BJ1012()
        {
            int[] dirX = new int[4] { 0, 0, -1, 1};
            int[] dirY = new int[4] { -1, 1, 0, 0};

            int testCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {   
                //Data Setting
                string[] args = Console.ReadLine()!.Split();
                int width = int.Parse(args[0]);
                int height = int.Parse(args[1]);
                int swarmCount = 0;

                int[,] plane = new int[width, height];
                bool[,] isVisited = new bool[width, height];
                int cabbageCount = int.Parse(args[2]);

                for (int j = 0; j < cabbageCount; j++)
                {
                    string[] pos = Console.ReadLine()!.Split();
                    int x = int.Parse(pos[0]);
                    int y = int.Parse(pos[1]);
                    plane[x, y] = 1;
                }

                //BFS
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (plane[x, y] == 0)
                        {
                            continue;
                        }

                        if(isVisited[x, y] == true)
                        {
                            continue;
                        }

                        //BFS
                        Tile start = new Tile(x, y);
                        Queue<Tile> queue = new Queue<Tile>();
                        queue.Enqueue(start);
                        isVisited[x, y] = true;

                        while (queue.Count > 0)
                        {
                            Tile search = queue.Dequeue();

                            for (int k = 0; k < 4; k++)
                            {
                                Tile adjacent = new Tile(search.x + dirX[k], search.y + dirY[k]);
                                if(adjacent.x >= 0 && adjacent.x < width && adjacent.y >= 0 && adjacent.y < height)
                                {
                                    if (isVisited[adjacent.x, adjacent.y] == false && plane[adjacent.x, adjacent.y] != 0)
                                    {
                                        queue.Enqueue(adjacent);
                                        isVisited[adjacent.x, adjacent.y] = true;
                                    }
                                }
                            }
                        }

                        swarmCount++;
                    }
                }

                sb1012.AppendLine(swarmCount.ToString());
            }

            Console.WriteLine(sb1012.ToString());
        }
    }
}
