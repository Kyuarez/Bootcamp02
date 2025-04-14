namespace algo0407
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //TKEditor();
            //KeyLogger();
            //SearchNumber();
            //TestBinarySearch();
            //FindNumber();
            //CutLanCable();
            //CutTree();
            RouterInstall();
        }

        public static void TestBinarySearch()
        {
            List<int> arr1 = new List<int>
            {
                1,2,2,3,4
            };
            List<int> arr2 = new List<int>
            {
                1,3,5,7,9
            };
            List<int> arr3 = new List<int>
            {
                1,2,3,4,5
            };
            List<int> arr4 = new List<int>
            {
                1, 4, 4, 6, 9, 10
            };
            List<int> arr5 = new List<int>
            {
                1,2,2,2,2,2,2,2,3,4,5
            };

            Console.WriteLine(LowerBound(arr1, 2));
            Console.WriteLine(LowerBound(arr2, 2));
            Console.WriteLine(LowerBound(arr3, 6));
            Console.WriteLine(LowerBound(arr4, 0));
            Console.WriteLine("=====================");
            Console.WriteLine($"시작 위치 {LowerBound(arr5, 2)} 끝 위치 {UpperBound(arr5, 2)}");
        }

        public static bool LinearSearch(List<int> linearList, int key)
        {
            foreach (int element in linearList)
            {
                if (element == key)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool BinarySearch(List<int> list, int key)
        {
            int left = 0;
            int right = list.Count - 1;

            while(left <= right)
            {
                int mid = (left + right) / 2;   
                if (list[mid] == key)
                {   
                    return true;
                }
                else if (list[mid] > key)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }


        public static bool TKBinarySearch(List<int> list, int key)
        {
            //정렬
            list.Sort();

            //이진 탐색
            int low = 0;
            int high = list.Count - 1;
            while (low <= high) 
            {
                int mid = low + (high - low) / 2;

                if (list[mid] == key)
                {
                    return true;
                }
                else if (list[mid] > key) 
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return false;
        }

        /// <summary>
        /// list에서 key보다 크거나 같은 첫번째 원소의 인덱스 반환
        /// </summary>
        public static int LowerBound(List<int> list, int key)
        {
            int left = 0;
            int right = list.Count - 1;
            int result = -1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (list[mid] < key) //mid가 key보다 작다.
                {
                    left = mid + 1;
                }
                else //mid가 key보다 크거나 같다.
                {
                    right = mid;
                    result = mid;
                }
            }

            return result;   
        }

        /// <summary>
        /// list에서 key보다 큰 값. 인덱스 반환
        /// </summary>
        public static int UpperBound(List<int> list, int key)
        {
            int left = 0;
            int right = list.Count - 1;
            int result = -1;
            //mid > key : right 조정 필요 (더 큰 애 있을 수 있으니까!)
            //mid = or < key : left 조정 필요

            while(left < right)
            {
                int mid = left + (right - left) / 2;
                
                if (list[mid] > key) //mid가 크다
                {
                    right = mid;
                }
                else //mid가 작거나 같다.
                {
                    left = mid + 1;
                    result = mid + 1;
                }
            }

            return result;
        }
    }
}
