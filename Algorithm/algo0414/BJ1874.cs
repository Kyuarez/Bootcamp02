using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static StringBuilder sb1874 = new StringBuilder();
        
        /// <summary>
        /// 백준 문제 1874 : 스택 수열
        /// </summary>
        public static void BJ1874()
        {
            int inputCount = int.Parse(Console.ReadLine());

            List<int> inputList = new List<int>();
            Stack<int> stack = new Stack<int>();
            int currentIndex = 0;

            for (int i = 0; i < inputCount; i++)
            {   
                inputList.Add(int.Parse(Console.ReadLine()!));
            }

            for (int i = 1; i <= inputCount; i++)
            {
                //Stack Input
                stack.Push(i);
                sb1874.AppendLine("+");

                //check
                while (true)
                {
                    if(stack.Count <= 0)
                    {
                        break;
                    }

                    if(stack.Peek() == inputList[currentIndex])
                    {
                        stack.Pop();
                        sb1874.AppendLine("-");
                        currentIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if(stack.Count != 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(sb1874.ToString());
            }
        }

    }
}
