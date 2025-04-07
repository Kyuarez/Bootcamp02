using System.Numerics;
using System.Security.Cryptography;
using System.Collections;

namespace algo0401
{
    public partial class Program
    {

        static void Main(string[] args)
        {
            //MergeSort01();
        
            
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
