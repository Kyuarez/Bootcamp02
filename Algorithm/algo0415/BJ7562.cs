using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        //@TK Night
        public static StringBuilder sb7562 = new StringBuilder();
        public static void BJ7562()
        {
            int testCount = int.Parse(Console.ReadLine()!);

            int[] dirX = new int[] { -1, 1, 2, 2, 1, -1, -2, -2 };
            int[] dirY = new int[] { -2, -2, -1, 1, 2, 2, 1, -1 };

            for (int i = 0; i < testCount; i++)
            {
                //Data Setting
                int boardLength = int.Parse((Console.ReadLine()!));
                string[] args1 = Console.ReadLine().Split();
                string[] args2 = Console.ReadLine().Split();

                Tuple<int, int> startPos = new Tuple<int, int>(int.Parse(args1[0]), int.Parse(args1[1]));
                Tuple<int, int> destPos = new Tuple<int, int>(int.Parse(args2[0]), int.Parse(args2[1]));

                int[,] cheseBoard = new int[boardLength, boardLength];
                bool[,] isVisited = new bool[boardLength, boardLength];
                int[,] stepCounts = new int[boardLength, boardLength];

                //BFS
                Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(startPos);
                isVisited[startPos.Item1, startPos.Item2] = true;

                while (queue.Count > 0)
                {
                    Tuple<int, int> searchVertex = queue.Dequeue();

                    if (searchVertex.Item1 == destPos.Item1 && searchVertex.Item2 == destPos.Item2)
                    {
                        break;
                    }

                    //knight이동
                    for (int mIndex = 0; mIndex < 8; mIndex++)
                    {
                        if (searchVertex.Item1 + dirX[mIndex] < 0 || searchVertex.Item1 + dirX[mIndex] >= boardLength)
                        {
                            continue;
                        }
                        if (searchVertex.Item2 + dirY[mIndex] < 0 || searchVertex.Item2 + dirY[mIndex] >= boardLength)
                        {
                            continue;
                        }
                        if (isVisited[searchVertex.Item1 + dirX[mIndex], searchVertex.Item2 + dirY[mIndex]] == true)
                        {
                            continue;
                        }

                        Tuple<int, int> adjacentVertex = new Tuple<int, int>(searchVertex.Item1 + dirX[mIndex], searchVertex.Item2 + dirY[mIndex]);
                        queue.Enqueue(adjacentVertex);
                        isVisited[adjacentVertex.Item1, adjacentVertex.Item2] = true;
                        stepCounts[adjacentVertex.Item1, adjacentVertex.Item2] += stepCounts[searchVertex.Item1, searchVertex.Item2] + 1;
                    }
                }

                //Write
                sb7562.AppendLine(stepCounts[destPos.Item1, destPos.Item2].ToString());
            }

            Console.WriteLine(sb7562.ToString());
        }
    }
}
