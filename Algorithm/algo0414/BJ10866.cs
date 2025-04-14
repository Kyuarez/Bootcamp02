using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static StringBuilder sb10866 = new StringBuilder();
        public static void BJ10866()
        {
            long commandCount = long.Parse(Console.ReadLine()!);
            TKDeque deque = new TKDeque();

            while (commandCount > 0)
            {
                commandCount--;
                string arg = Console.ReadLine();
                
                if(arg.Contains("push") == true)
                {
                    string[] args = arg.Split();
                    if (args[0] == "push_front")
                    {
                        deque.PushFront(long.Parse(args[1]));
                    }
                    else if (args[0] == "push_back")
                    {
                        deque.PushBack(long.Parse(args[1]));
                    }

                }
                else
                {
                    if(arg == "pop_front")
                    {
                        sb10866.AppendLine(deque.PopFront().ToString());
                    }
                    else if(arg == "pop_back")
                    {
                        sb10866.AppendLine(deque.PopBack().ToString());
                    }
                    else if (arg == "size")
                    {
                        sb10866.AppendLine(deque.Size().ToString());
                    }
                    else if(arg == "empty")
                    {
                        sb10866.AppendLine(deque.Empty().ToString());
                    }
                    else if(arg == "front")
                    {
                        sb10866.AppendLine(deque.Front().ToString());
                    }
                    else if(arg == "back")
                    {
                        sb10866.AppendLine(deque.Back().ToString());
                    }
                }
            }

            Console.WriteLine(sb10866.ToString());

        }

        public class TKDeque
        {
            public LinkedList<long> DataList = new LinkedList<long>();
            public long Count;
            

            public void PushFront(long data)
            {
                DataList.AddFirst(data);
                Count++;
            }
            public void PushBack(long data)
            {
                DataList.AddLast (data);
                Count++;
            }
            public long PopFront()
            {
                if(Count == 0)
                {
                    return -1;
                }

                long result = DataList.First();
                Count--;
                DataList.RemoveFirst();
                return result;
            }
            public long PopBack()
            {
                if (Count == 0)
                {
                    return -1;
                }

                long result = DataList.Last();
                Count--;
                DataList.RemoveLast();
                return result;
            }
            public long Size()
            {
                return Count;
            }

            public long Empty()
            {
                return Count == 0 ? 1 : 0;
            }

            public long Front()
            {
                if (Count == 0)
                {
                    return -1;
                }

                return DataList.First();
            }
            public long Back()
            {
                if (Count == 0)
                {
                    return -1;
                }

                return DataList.Last();
            }
        }

    }

  
}
