using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0407
{
    public partial class Program
    {
        public static void CutTree()
        {
            string[] arg1 = Console.ReadLine().Split();
            string[] arg2 = Console.ReadLine().Split();

            long N = long.Parse(arg1[0]); //Tree Count
            long M = long.Parse(arg1[1]); //Tree Length(Goal)

            long[] trees = new long[N];
            for (int i = 0; i < N; i++) 
            {
                trees[i] = long.Parse(arg2[i]);
            }
             
            long start = 1;
            long end = trees.Max();

            while (start <= end) 
            {
                long sum = 0;

                long mid = start + (end - start) / 2;

                for (int i = 0; i < N; i++)
                {
                    if (trees[i] > mid)
                    {
                        sum += (trees[i] - mid);
                    }
                }

                if (sum >= M)
                {
                    start = mid + 1;    
                }
                else
                {
                    end = mid - 1;
                }
            }

            Console.WriteLine(end.ToString());

        }
    }
}
