using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        public struct BoardState
        {
            
        }

        public static void BJ1525()
        {
            /* [생각]
             보드의 현재 상태 = 정점?
             -> 123456780 int  
             -> 0의 위치 변화 
             현재 탐색 : 빈칸 -> 상하좌우 (switch) 해서 
             */

            //Data setting
            int width = 3;
            int height = 3;

            for (int y = 0; y < height; y++) 
            {
                string[] args = Console.ReadLine()!.Split();
                for (int x = 0; x < width; x++)
                {

                }
            }

            //BFS
            Queue<BoardState> queue = new Queue<BoardState>();

        }
    }
}
