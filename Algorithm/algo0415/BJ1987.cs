using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public static void BJ1987()
        {
            int[] dirX = new int[4]{0,0,-1,1};
            int[] dirY = new int[4]{-1,1,0,0};

            //Data 입력!
            string[] args = Console.ReadLine()!.Split();
            int height = int.Parse(args[0]);
            int width = int.Parse(args[1]);

            char[,] maps = new char[width, height];
            int[,] counts = new int[width, height];
            bool[,] isVisited = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                char[] oneLine = Console.ReadLine().ToCharArray();

                for (int x = 0; x < width; x++)
                {
                    maps[x, y] = oneLine[x];
                }
            }

            List<char> checkList = new List<char>();

            //DFS로 하고 

            

            int maxCount = 0;
            for (int y = 0; y < counts.GetLength(1); y++) 
            {
                for (int x = 0; x < counts.GetLength(0); x++)
                {
                    if (counts[x, y] > maxCount)
                    {
                        maxCount = counts[x, y];
                    }
                }
            }

            Console.WriteLine(maxCount);
        }

        public static void DFS1987(int x, int y, char[,] maps, bool[,] isVisited)
        {
            isVisited[x, y] = true;

        }

        public static bool IsDuplicated(char compare, List<char> checkList)
        {
            bool result = false;

            foreach (char check in checkList)
            {
                if(check == compare)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
