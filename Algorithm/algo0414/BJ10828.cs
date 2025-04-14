using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{

    public partial class Program
    {
        public static StringBuilder sb10828 = new StringBuilder();

        public static void BJ10828()
        {
            int commandCount = int.Parse(Console.ReadLine());

            Queue<string> commandQueue = new Queue<string>();
            Stack<int> DataStack = new Stack<int>();
            for (int i = 0; i < commandCount; i++) 
            {
                commandQueue.Enqueue(Console.ReadLine());
            }

            while (commandQueue.Count > 0)
            {
                string command = commandQueue.Dequeue();
                if(command.Contains("push") == true)
                {
                    DataStack.Push(int.Parse(command.Split().Last()));
                }
                else
                {
                    switch (command)
                    {
                        case "pop":
                            if (DataStack.Count <= 0)
                            {
                                sb10828.Append("-1\n");
                            }
                            else
                            {
                                sb10828.Append($"{DataStack.Pop()}\n");
                            }
                            break;
                        case "size":
                            sb10828.Append($"{DataStack.Count}\n");
                            break;
                        case "empty":
                            if (DataStack.Count <= 0)
                            {
                                sb10828.Append("1\n");
                            }
                            else
                            {
                                sb10828.Append($"0\n");
                            }
                            break;
                        case "top":
                            { 
                                if(DataStack.Count <= 0)
                                {
                                    sb10828.Append("-1\n");
                                }
                                else
                                {
                                    sb10828.Append($"{DataStack.Peek()}\n");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(sb10828.ToString());
        }



        public static void BJ10828WithLinear()
        {
            int commandCount = int.Parse(Console.ReadLine());

            Queue<string> commandQueue = new Queue<string>();
            List<int> dataList = new List<int>();
            int top = 0;

            for (int i = 0; i < commandCount; i++)
            {
                commandQueue.Enqueue(Console.ReadLine());
            }

            while (commandQueue.Count > 0)
            {
                string command = commandQueue.Dequeue();
                if (command.Contains("push") == true)
                {
                    dataList.Add(int.Parse(command.Split().Last()));
                    top++;
                }
                else
                {
                    switch (command)
                    {
                        case "pop":
                            if (dataList.Count <= 0)
                            {
                                sb10828.Append("-1\n");
                            }
                            else
                            {
                                sb10828.Append($"{dataList[top]}\n");
                                dataList.RemoveAt(top);
                                top--;
                            }
                            break;
                        case "size":
                            sb10828.Append($"{dataList.Count}\n");
                            break;
                        case "empty":
                            if (dataList.Count <= 0)
                            {
                                sb10828.Append("1\n");
                            }
                            else
                            {
                                sb10828.Append($"0\n");
                            }
                            break;
                        case "top":
                            {
                                if (dataList.Count <= 0)
                                {
                                    sb10828.Append("-1\n");
                                }
                                else
                                {
                                    sb10828.Append($"{dataList[top]}\n");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        public class BJ10828Stack
        {
            int[] container = new int[10004];
            int top = -1;

            public void Push(int data)
            {
                container[++top] = data;
            }

            public int Pop()
            {
                if (top == -1)
                {
                    return -1;
                }

                return container[top--];
            }

            public int Size()
            {
                return top + 1;
            }

            public int Empty()
            {
                if(top == -1)
                {
                    return -1;
                }

                return 0;
            }

            public int Top() => top;
        }
    }
}
