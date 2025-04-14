using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        //프린터 큐
        public static StringBuilder sb1966 = new StringBuilder();
        public static void BJ1966()
        {
            int testCount = int.Parse(Console.ReadLine());

            while (testCount > 0) 
            {
                testCount--;

                //Data Setting
                string[] args = Console.ReadLine().Split();
                int pageCount = int.Parse(args[0]);
                int currentGoalIndex = int.Parse(args[1]); //원하는 문서의 현재 위치

                int[] orderData = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int goalPage = orderData[currentGoalIndex];
                int printCount = 0;

                Queue<int> pageQueue = new Queue<int>(orderData);
                Array.Sort(orderData);
                Array.Reverse(orderData);
                Queue<int> orderQueue = new Queue<int>(orderData);

                //Calc
                while (pageQueue.Count > 0) 
                {
                    if(pageQueue.Peek() == orderQueue.Peek())
                    {
                        printCount++;
                        int page = pageQueue.Dequeue();
                        orderQueue.Dequeue();
                        if(page == goalPage && currentGoalIndex == 0)
                        {
                            break;
                        }

                        currentGoalIndex = (currentGoalIndex - 1) < 0 ? pageQueue.Count - 1 : currentGoalIndex - 1;
                        continue;
                    }

                    pageQueue.Enqueue(pageQueue.Dequeue());
                    currentGoalIndex = (currentGoalIndex - 1) < 0 ? pageQueue.Count - 1 : currentGoalIndex - 1;
                }

                sb1966.AppendLine(printCount.ToString());
            }

            Console.WriteLine(sb1966.ToString());
        }
    }
}
