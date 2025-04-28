using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0415
{
    public partial class Program
    {
        //@TK DSLR
        public static StringBuilder sb9019 = new StringBuilder();
        public static void BJ9019()
        {
            char[] commands = new char[4] { 'D', 'S', 'L', 'R' };

            int testCount = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < testCount; i++) 
            {
                string[] arg = Console.ReadLine()!.Split();
                int start = int.Parse(arg[0]);
                int goal = int.Parse(arg[1]);

                //BFS
                bool[] isVisited = new bool[10004];
                string[] commandArr = new string[10004];
                
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                commandArr[start] = string.Empty;
                isVisited[start] = true;

                while (queue.Count > 0) 
                {
                    int search = queue.Dequeue();

                    if(search == goal)
                    {
                        break;
                    }

                    for (int c = 0; c < commands.Length; c++)
                    {
                        int adjacent = DSLR(search, commands[c]);
                        if (isVisited[adjacent] == false)
                        {
                            queue.Enqueue(adjacent);
                            commandArr[adjacent] = commandArr[search] + commands[c];
                            isVisited[adjacent] = true;
                        }
                    }
                }

                sb9019.AppendLine(commandArr[goal]);
            }

            Console.WriteLine(sb9019.ToString());
        }

        public static int DSLR(int origin, char command)
        {
            switch (command)
            {
                case 'D':
                    return origin * 2 % 10000;   
                case 'S':
                    return (origin - 1 + 10000) % 10000; 
                case 'L':
                    return (origin % 1000 * 10) + origin / 1000;
                case 'R':
                    return (origin / 10) + (origin % 10 * 1000);           
            }
            return origin;
        }
    }
}
