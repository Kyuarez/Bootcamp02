using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0401
{
    public partial class Program
    {
        public static void AlgoFibo01()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FiboRecursive(n));
        }

        public static int FiboRecursive(int n) 
        {
            if(n == 0)
            {
                return 0;
            }
            if(n == 1)
            {
                return 1;
            }

            return FiboRecursive(n - 2) + FiboRecursive(n -1);
        }
    }
}
