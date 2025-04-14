using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0407
{
    public partial class Program
    {

        public static void CutLanCable()
        {
            string[] inputData = Console.ReadLine().Split();
            long k = long.Parse(inputData[0]);
            long n = long.Parse(inputData[1]);

            long[] lan = new long[k];

            for (long i = 0; i < k; i++) 
            {
                lan[i] = long.Parse(Console.ReadLine());
            }

            long start = 1;
            long end = lan.Max();
            long result = 0;
                
            while(start <= end)
            {
                long mid = start + (end - start) / 2;

                long sum = 0;

                for (long i = 0; i < k; i++)
                {
                    sum += lan[i] / mid;
                }

                if(sum >= n)
                {
                    result = Math.Max(result, mid);
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            Console.WriteLine(result.ToString());
        }        
    }
}
