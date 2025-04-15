using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public static void BJ2178()
        {
            //Data
            string[] args = Console.ReadLine().Split();
            int N = int.Parse(args[0]); //y
            int M = int.Parse(args[1]); //x

            bool[,] isVisited = new bool[N, M];
            int[,] maps = new int[N, M];

            for (int y = 0; y < N; y++) 
            {
                char[] dataLine = Console.ReadLine().ToCharArray();
                for (int x = 0; x < dataLine.Length; x++)
                {
                    if (dataLine[x] == '0')
                    {
                        maps[x, y] = 0;
                        isVisited[x, y] = true;
                    }
                    else if (dataLine[x] == '1')
                    {
                        maps[x, y] = 1;
                    }
                }
            }

            //Logic : BFS
            isVisited[0, 0] = true;
            int pathCount = 1;
            
            //뭔가의 워커플로우
            //방문했는가? cut
            //방문...
        }
    }
}
