using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace algo0401
{
    public partial class Program
    {
        public static int mergeCount = 0;
        public static int mergeSaveCount;
        public static int result = -1;

        public static void MergeSort01()
        {  
            string[] arg1 = Console.ReadLine().Split();
            string[] arg2 = Console.ReadLine().Split();

            int mergeArrCount = int.Parse(arg1[0]);
            mergeSaveCount = int.Parse(arg1[1]);

            int[] mergeArr = new int[mergeArrCount];
            for (int i = 0; i < arg2.Length; i++)
            {
                mergeArr[i] = int.Parse(arg2[i]);
            }

            int[] temp = new int[mergeArrCount];
            MergeSort(mergeArr, temp, 0, mergeArrCount - 1);

            Console.WriteLine(result);  
        }

        public static void MergeSort(int[] arr, int[] temp, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(arr, temp, p, q);
                MergeSort(arr, temp, q + 1, r);
                Merge(arr, temp, p, q, r);
            }
        }

        public static void Merge(int[] arr, int[] temp, int p, int q, int r)
        {
            int i = p;
            int j = q + 1;
            int t = p;

            while (i <= q && j <= r)
            {
                if (arr[i] <= arr[j])
                {
                    temp[t++] = arr[i++];
                }
                else
                {
                    temp[t++] = arr[j++];
                }
            }
            while (i <= q)
            {
                temp[t++] = arr[i++];
            }
            while (j <= r)
            {
                temp[t++] = arr[j++];
            }

            for (int k = p; k <= r; k++)
            {
                arr[k] = temp[k];
                mergeCount++;

                if (mergeCount == mergeSaveCount)
                {
                    result = arr[k];
                }
            }
        }

    }
}
