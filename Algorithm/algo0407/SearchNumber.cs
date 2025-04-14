using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0407
{
    public partial class Program
    {
        public static StringBuilder searchResult = new StringBuilder();
        public static void SearchNumber()
        {
            string arg1 = Console.ReadLine();
            string arg2 = Console.ReadLine();
            string arg3 = Console.ReadLine();
            string arg4 = Console.ReadLine();

            int nArrCount = int.Parse(arg1);
            int[] nArr = new int[nArrCount];

            string[] nData = arg2.Split();
            for (int i = 0; i < nArrCount; i++) 
            {
                nArr[i] = int.Parse(nData[i]);
            }
            
            Array.Sort(nArr);

            int mArrCount = int.Parse(arg3);
            string[] mData = arg4.Split();
            for (int i = 0; i < mArrCount; i++)
            {
                int compare = int.Parse(mData[i]);
                //탐색
                BinarySearchArr(nArr, compare);
            }

            Console.WriteLine(searchResult);
        }

        public static void BinarySearchArr(int[] arr, int compare)
        {
            int left = 0;
            int right = arr.Length - 1;
            bool isFind = false;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == compare)
                {
                    isFind = true;
                    break;
                }
                else if (arr[mid] > compare) //left
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }


            searchResult.Append((isFind) ? 1.ToString() + "\n": 0.ToString() + "\n");
        }
    }
}
