using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{

    //@tk 안전영역
    public partial class Program
    {
        public static void BJ2468()
        {
            int[] dirX = new int[4] { 0, 0, -1, 1 };
            int[] dirY = new int[4] { -1, 1, 0, 0 };

            //Data Setting
            int boardLength = int.Parse(Console.ReadLine());
            int[,] board = new int[boardLength, boardLength];
            int rainMax = 0;
            for (int y = 0; y < boardLength; y++)
            {
                string[] arg = Console.ReadLine()!.Split();

                for (int x = 0; x < boardLength; x++)
                {
                    board[x,y] = int.Parse(arg[x]);
                    if (board[x,y] > rainMax)
                    {
                        rainMax = board[x,y];
                    }
                }
            }

            //graph 탐색 //max 값 ~ 0까지 (비의 높이)
            List<int> safeAreaList = new List<int>(); //비의 높이에 따른 safeAreaCount 값
            for (int i = 0; i <= rainMax; i++)
            {
                safeAreaList.Add(0);
            }


            for (int rainHeight = rainMax; rainHeight >= 0; rainHeight--)
            {
                bool[,] isVisited = new bool[boardLength, boardLength];
                safeAreaList[rainHeight] = 0;
                for (int y = 0; y < boardLength; y++)
                {
                    for (int x = 0; x < boardLength; x++)
                    {
                        if (board[x, y] <= rainHeight) //안전하지 않은 지역
                        {
                            isVisited[x, y] = true;
                        }
                    }
                }

                for (int y = 0; y < boardLength; y++)
                {
                    for (int x = 0; x < boardLength; x++)
                    {
                        //BFS
                        if (isVisited[x, y] == true)
                        {
                            continue;
                        }

                        Tuple<int, int> start = new Tuple<int, int>(x, y);
                        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
                        queue.Enqueue(start);
                        isVisited[x, y] = true;
                        safeAreaList[rainHeight] += 1;

                        while (queue.Count > 0)
                        {
                            Tuple<int, int> search = queue.Dequeue();

                            for (int i = 0; i < 4; i++)
                            {
                                Tuple<int, int> adjacent = new Tuple<int, int>(search.Item1 + dirX[i], search.Item2 + dirY[i]);
                                if (adjacent.Item1 >= 0 && adjacent.Item1 < boardLength && adjacent.Item2 >= 0 && adjacent.Item2 < boardLength)
                                {
                                    if (isVisited[adjacent.Item1, adjacent.Item2] == false)
                                    {
                                        queue.Enqueue(adjacent);
                                        isVisited[adjacent.Item1, adjacent.Item2] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //다 돎.
            Console.WriteLine(safeAreaList.Max().ToString());

        }
    }
}
