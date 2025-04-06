using System.Numerics;
using System.Security.Cryptography;
using System.Collections;

namespace algo0401
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static int Fibo(int n)
        {
            if(n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            return Fibo(n - 2) + Fibo(n - 1);
        }

        
        public static long FiboDynamic(int n, ref long[] memo)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = FiboDynamic(n - 2, ref memo) + FiboDynamic(n - 1, ref memo);
            return memo[n];
        }
            

        public static void WriteRecursive(int start, int maxCount)
        {
            if(start > maxCount)
            {
                return;
            }

            Console.WriteLine(start);
            WriteRecursive(start + 1, maxCount);
        }

        public static void FlexibleWriteRecursive(int recursiveCount)
        {
            if(recursiveCount <= 0)
            {
                return;
            }

            FlexibleWriteRecursive(recursiveCount - 1);
            Console.WriteLine(recursiveCount);
        }
    }   
}
