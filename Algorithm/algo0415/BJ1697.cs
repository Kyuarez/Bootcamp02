using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    //@tk 숨바꼭질
    public partial class Program
    {
        public static void BJ1697()
        {
            string[] args = Console.ReadLine().Split();
            int N = int.Parse(args[0]); //subin pos
            int K = int.Parse(args[1]); //sister pos

            int[] timeCounts = new int[100004];
            bool[] isVisted = new bool[100004];
            Queue<int> queue = new Queue<int>();
            isVisted[N] = true;
            queue.Enqueue(N);

            while (queue.Count > 0)
            {
                int currentPos = queue.Dequeue();

                if (currentPos == K)
                {
                    break;
                }

                if (currentPos + 1 <= 100000 && isVisted[currentPos + 1] == false)
                {
                    queue.Enqueue(currentPos + 1);
                    isVisted[currentPos + 1] = true;
                    timeCounts[currentPos + 1] += timeCounts[currentPos] + 1;
                }
                if (currentPos * 2 <= 100000 && isVisted[currentPos * 2] == false)
                {
                    queue.Enqueue(currentPos * 2);
                    isVisted[currentPos * 2] = true;
                    timeCounts[currentPos * 2] += timeCounts[currentPos] + 1;
                }
                if (currentPos - 1 >= 0 && isVisted[currentPos - 1] == false)
                {
                    queue.Enqueue(currentPos - 1);
                    isVisted[currentPos - 1] = true;
                    timeCounts[currentPos - 1] += timeCounts[currentPos] + 1;
                }
            }

            Console.WriteLine(timeCounts[K]);
        }
    }
    

}
