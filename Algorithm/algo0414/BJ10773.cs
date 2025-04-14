using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static void BJ10773()
        {
            int commandCount = int.Parse(Console.ReadLine());
            Stack<int> dataStack = new Stack<int>();

            while (commandCount > 0) 
            {
                commandCount--;
                int data = int.Parse(Console.ReadLine());

                if(data == 0)
                {
                    if(dataStack.Count != 0)
                    {
                        dataStack.Pop();
                    }
                }
                else
                {
                    dataStack.Push(data);
                }
            }

            int sum = 0;
            while(dataStack.Count > 0)
            {
                sum += dataStack.Pop();
            }

            Console.WriteLine(sum);
        }
    }
}
