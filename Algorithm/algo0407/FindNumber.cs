using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0407
{
    public partial class Program 
    {
        public static StringBuilder findResult = new StringBuilder();

        public static void FindNumber()
        {
            //데이터 세팅
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
                int start = FindLower(nArr, compare);
                int end = FindUpper(nArr, compare);
                    
                if(start == -1 || end == -1)
                {
                    findResult.Append(0.ToString() + " ");
                }
                else
                {
                    findResult.Append((end - start + 1).ToString() + " ");
                }
            }

            Console.WriteLine(findResult);
        }

        public static int FindLower(int[] arr, int compare)
        {
            int result = -1;
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (arr[mid] == compare)
                {
                    end = mid - 1;
                    result = mid;
                }
                else if (arr[mid] < compare)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return result;
        }
        //key보다 큰 값
        public static int FindUpper(int[] arr, int compare)
        {
            int result = -1;
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (arr[mid] == compare)
                {
                    start = mid + 1;
                    result = mid;
                }
                else if (arr[mid] < compare) 
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return result;
        }


    }
}
