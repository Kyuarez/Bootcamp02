using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static StringBuilder sb10845 = new StringBuilder();
        public static void BJ10845()
        {
            int inputCount = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            while (inputCount > 0) 
            {
                inputCount--;
                string arg = Console.ReadLine();

                if(arg.Contains("push") == true)
                {
                    string[] args = arg.Split();
                    queue.Enqueue(int.Parse(args[1]));
                }
                else
                {
                    if(arg == "pop")
                    {
                        sb10845.AppendLine(queue.Dequeue().ToString());
                    }
                    else if(arg == "size")
                    {
                        sb10845.AppendLine(queue.Count.ToString());
                    }
                    else if (arg == "empty")
                    {
                        sb10845.AppendLine(queue.Count > 0 ? "0" : "-1");
                    }
                    else if(arg == "front")
                    {
                        sb10845.AppendLine(queue.First().ToString());
                    }
                    else if(arg == "back")
                    {
                        sb10845.AppendLine(queue.Last().ToString());
                    }
                }
            }

            Console.WriteLine(sb10845.ToString());
        }

        public static void BJ10845Linear()
        {
            int inputCount = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            while (inputCount > 0)
            {
                inputCount--;
                string arg = Console.ReadLine();

                if (arg.Contains("push") == true)
                {
                    string[] args = arg.Split();
                    queue.Enqueue(int.Parse(args[1]));
                }
                else
                {
                    if (arg == "pop")
                    {
                        sb10845.AppendLine(queue.Dequeue().ToString());
                    }
                    else if (arg == "size")
                    {
                        sb10845.AppendLine(queue.Count.ToString());
                    }
                    else if (arg == "empty")
                    {
                        sb10845.AppendLine(queue.Count > 0 ? "0" : "-1");
                    }
                    else if (arg == "front")
                    {
                        sb10845.AppendLine(queue.First().ToString());
                    }
                    else if (arg == "back")
                    {
                        sb10845.AppendLine(queue.Last().ToString());
                    }
                }
            }

            Console.WriteLine(sb10845.ToString());
        }

        //public class BJ10845LinearQueue
        //{
        //    private int[int] DataArr;
        //    private int front = -1;
        //    private int rear = -1;

        //    public BJ10845LinearQueue()
        //    {
        //        DataArr = new List<int>();
        //        front = -1;
        //        rear = -1;
        //    }

        //    public void Enqueue(int data)
        //    {
        //        rear++;
        //        DataList.Add(data);
        //    }

        //    public int Dequeue() 
        //    {
        //        if(Empty() == 1)
        //        {
        //            return -1;
        //        }

        //        int result = DataList[++front];
        //        if (front > rear)
        //        {
        //            DataList.Clear();
        //            front = -1;
        //            rear = -1;
        //        }

        //        return result;
        //    }

        //    public int Size()
        //    {
        //        return (Empty() != 1) ? (rear - front) : -1;
        //    }

        //    public int Empty()
        //    {
        //        return (rear == front) ? 0 : 1;
        //    }

        //    public int Front()
        //    {
        //        if(front == -1 || Empty() == 1)
        //        {
        //            return -1;
        //        }

        //        return DataList[++front];
        //    }

        //    public int Back()
        //    {
        //        if (Empty() == 1)
        //        {
        //            return -1;
        //        }

        //        return DataList[rear - 1];
        //    }
        //}

        public class BJ10845ConnectQueue
        {
            public LinkedList<int> DataList;    

            public LinkedListNode<int> Front;
            public LinkedListNode<int> Rear;


        }

    }
}
