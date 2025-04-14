using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static void BJ2164()
        {
            long inputCount = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            for (int i = 1; i <= inputCount; i++) 
            {
                queue.Enqueue(i);
            }

            while (true) 
            {
                if(queue.Count == 1)
                {
                    Console.WriteLine(queue.Dequeue());
                    break;
                }
                //제일 위에 카드를 제거
                queue.Dequeue();
                //다음 카드 뒤로 옮긴다.
                if(queue.Count == 2)
                {
                    Console.WriteLine(queue.Dequeue());
                    break;
                }

                queue.Enqueue(queue.Dequeue());
            }
        }
    }

}
