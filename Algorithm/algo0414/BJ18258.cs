using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program 
    {
        public static StringBuilder sb18258 = new StringBuilder();
        public static void BJ18258()
        {
            long inputCount = long.Parse(Console.ReadLine()!);
            TK18258Queue queue = new TK18258Queue();

            while (inputCount > 0) 
            {
                inputCount--;   
                string arg = Console.ReadLine()!;

                if(arg.Contains("push") == true)
                {
                    string[] args = arg.Split(' ');
                    queue.Push(long.Parse(args[1]));
                }
                else
                {
                    if(arg == "pop")
                    {
                        sb18258.AppendLine(queue.Pop().ToString());
                    }
                    else if(arg == "size")
                    {
                        sb18258.AppendLine(queue.Size().ToString());
                    }
                    else if(arg == "empty")
                    {
                        sb18258.AppendLine(queue.Empty().ToString());
                    }
                    else if(arg == "front")
                    {
                        sb18258.AppendLine(queue.Front().ToString());
                    }
                    else if(arg == "back")
                    {
                        sb18258.AppendLine(queue.Back().ToString());
                    }
                }
                
            }

            Console.WriteLine(sb18258.ToString());
        }
    }

    public class TK18258Queue
    {
        public long[] dataArr = new long[2000004];
        public long front = 0;
        public long rear = 0;

        public TK18258Queue() 
        {

        }

        public void Push(long data)
        {
            dataArr[rear++] = data;
        }

        public long Pop()
        {
            if(Empty() == 1)
            {
                return -1;
            }

            return dataArr[front++];
        }

        public long Size()
        {
            return rear - front;
        }

        public int Empty() //비어있으면 1
        {
            return (rear == 0 || rear == front) ? 1 : 0;
        }

        public long Front()
        {
            if(Empty() == 1)
            {
                return -1;
            }

            return dataArr[front];
        }

        public long Back()
        {
            if (Empty() == 1)
            {
                return -1;
            }

            return dataArr[rear - 1];
        }
    }
}
