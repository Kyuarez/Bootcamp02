using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public static void BJ2667()
        {
            int argsCount = int.Parse(Console.ReadLine());

            int[,] maps = new int[argsCount, argsCount];
            bool[,] isVisited = new bool[argsCount, argsCount];
            
            for (int y = 0; y < maps.GetLength(0); y++)
            {
                char[] args = Console.ReadLine().ToCharArray();
                for (int x = 0; x < maps.GetLength(1); x++)
                {
                    if (args[x] == '0')
                    {
                        maps[x, y] = 0;
                        isVisited[x, y] = true;
                    }
                    else if (args[x] == '1')
                    {
                        maps[x, y] = 1;
                    }
                }
            }

            List<int> complexData = new List<int>();

            for (int y = 0; y < argsCount; y++)
            {
                for (int x = 0; x < argsCount; x++)
                {
                    if (isVisited[x, y] == true)
                    {
                        continue;
                    }

                    int houseCount = 0;
                    DFS2667(isVisited, x, y, argsCount, ref houseCount);
                    complexData.Add(houseCount);    
                }
            }

            Console.WriteLine(complexData.Count);
            complexData.Sort();
            foreach (int complex in complexData)
            {
                Console.WriteLine(complex);
            }
        }

        //기본 : 현재 방문할 노드, 방문 기록지(static 아니면)
        public static void DFS2667(bool[,] isVisited, int x, int y, int max, ref int houseCount)
        {
            isVisited[x, y] = true;
            houseCount++;

            //상
            if (y - 1 >= 0)
            {
                if (isVisited[x, y - 1] == false)
                {
                    DFS2667(isVisited, x, y - 1, max, ref houseCount);
                }
            }

            //하
            if (y + 1 < max)
            {
                if (isVisited[x, y + 1] == false)
                {
                    DFS2667(isVisited, x, y + 1, max, ref houseCount);
                }
            }

            //좌
            if (x - 1 >= 0)
            {
                if (isVisited[x - 1, y] == false)
                {
                    DFS2667(isVisited, x - 1, y, max, ref houseCount);
                }
            }

            //우
            if (x + 1 < max)
            {
                if (isVisited[x + 1, y] == false)
                {
                    DFS2667(isVisited, x + 1, y, max, ref houseCount);
                }
            }
        }

        public static string[] Map2667 = new string[25];
        public static void BJ2667_2()
        {
            int N = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < N; i++)
            {
                Map2667[i] = Console.ReadLine()!;
            }

        }
    }
}
