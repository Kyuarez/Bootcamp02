using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static StringBuilder sb11866 = new StringBuilder();
        public static void BJ11866()
        {
            sb11866.Append("<");

            string[] args = Console.ReadLine().Split();

            int humanCount = int.Parse(args[0]);
            int orderNum = int.Parse(args[1]);

            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= humanCount; i++) 
            {
                queue.Enqueue(i);
            }

            //다 죽을 때까지
            while (queue.Count > 0)
            {
                int currentOrder = 1;

                //죽일 순번까지 뒤로 돌리고
                while (currentOrder < orderNum) 
                {
                    currentOrder++;
                    queue.Enqueue(queue.Dequeue());
                }

                //죽이기
                if(queue.Count == 1)
                {
                    sb11866.Append(queue.Dequeue().ToString());
                }
                else
                {
                    sb11866.Append(queue.Dequeue().ToString() + ", ");
                }
            }
            
            sb11866.Append(">");
            Console.WriteLine(sb11866.ToString());
        }
    
    }
}
