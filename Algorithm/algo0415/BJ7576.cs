using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public static void BJ7576()
        {
            //Data Setting
            string[] args = Console.ReadLine()!.Split();
            int boxLengthX = int.Parse(args[0]);
            int boxLengthY = int.Parse(args[1]);

            List<Tuple<int, int>> startList = new List<Tuple<int, int>>();
            int[,] box = new int[boxLengthX, boxLengthY];
            int[,] isVisited = new int[boxLengthX, boxLengthY]; //-1 방문x, 

            int[] dirX = new int[] { 0, 0, -1, 1 };
            int[] dirY = new int[] { -1, 1, 0, 0 };

            for (int y = 0; y < boxLengthY; y++)
            {
                string[] oneLine = Console.ReadLine()!.Split();
                for (int x = 0; x < boxLengthX; x++)
                {
                    box[x, y] = int.Parse(oneLine[x]);

                    if (box[x, y] == -1)
                    {
                        isVisited[x, y] = -1;
                    }
                    else if (box[x, y] == 1)
                    {
                        startList.Add(new Tuple<int, int>(x, y));
                    }
                }
            }

            //BFS 시작 점이 여러개...?
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            foreach (Tuple<int, int> start in startList)
            {
                isVisited[start.Item1, start.Item2] = 1;
                queue.Enqueue(start);
            }

            while (queue.Count > 0)
            {
                Tuple<int, int> searchVertex = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    Tuple<int, int> adjacent = new Tuple<int, int>(searchVertex.Item1 + dirX[i], searchVertex.Item2 + dirY[i]);

                    if (adjacent.Item1 < 0 || adjacent.Item1 >= boxLengthX || adjacent.Item2 < 0 || adjacent.Item2 >= boxLengthY)
                    {
                        continue;
                    }
                    if (isVisited[adjacent.Item1, adjacent.Item2] > 0 || isVisited[adjacent.Item1, adjacent.Item2] < 0)
                    {
                        continue;
                    }

                    queue.Enqueue(adjacent);
                    isVisited[adjacent.Item1, adjacent.Item2] += isVisited[searchVertex.Item1, searchVertex.Item2] + 1;
                }
            }

            //방문 애들 중에서 체크
            int result = 1;
            for (int y = 0; y < boxLengthY; y++)
            {
                for (int x = 0; x < boxLengthX; x++)
                {
                    if (isVisited[x, y] == 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }

                    if (isVisited[x, y] > result)
                    {
                        result = isVisited[x, y];
                    }
                }
            }

            Console.WriteLine((result - 1).ToString());
        }
    }
}
