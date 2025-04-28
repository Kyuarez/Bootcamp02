using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace algo0428
{
    //@tk : 기본적으로 Mine Heap & 데이터 중복 허용
    public class TKMinHeap
    {
        private List<int> tree = new();

        public void Enqueue(int value)
        {
            tree.Add(value);
            int index = tree.Count;

            //접근할 때만 -1로 접근하고 root를 1로 판단
            while (index != 1)
            {
                int parentIndex = index / 2;
                if (tree[parentIndex - 1] < tree[index - 1])
                {
                    break;
                }

                // Swap
                int temp = tree[parentIndex - 1];
                tree[parentIndex - 1] = tree[index - 1];
                tree[index - 1] = temp;
                index = parentIndex;
            }
        }

        public int Dequeue()
        {
            if (tree.Count == 0)
            {
                return -1;
            }

            int result = tree[0];
            //제거하고 배열 처리 ()
            tree[0] = tree[tree.Count - 1];
            tree.RemoveAt(tree.Count - 1);

            int index = 1;
            while (index * 2 <= tree.Count) 
            {
                int leftIndex = index * 2;
                int rightIndex = index * 2 + 1;
                int childIndex = leftIndex;

                if (rightIndex <= tree.Count && tree[rightIndex - 1] < tree[leftIndex - 1])
                {
                    childIndex = rightIndex;
                }

                if (tree[index - 1] < tree[childIndex - 1]) 
                {
                    break;
                }

                int temp = tree[index - 1];
                tree[index - 1] = tree[childIndex - 1];
                tree[childIndex - 1] = temp;
                index = childIndex;
            }

            return result;
        }

        public int Peek()
        {
            if (tree.Count == 0)
            {
                return -1;
            }

            return tree[0];
        }

    }

    public class TKMaxHeap
    {

    }
}
