using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static StringBuilder sb9012 = new StringBuilder();
        public static void BJ9012()
        {
            int dataCount = int.Parse(Console.ReadLine());
            Stack<char> stack = new Stack<char>();

            while (dataCount > 0) 
            {
                dataCount--;
                char[] charData = Console.ReadLine().ToCharArray();
                
                stack.Clear();
                bool isVPS = true;

                for (int i = 0; i < charData.Length; i++) 
                {
                    if (charData[i] == '(')
                    {
                        stack.Push(charData[i]);
                    }
                    else if (charData[i] == ')')
                    {
                        if(stack.Count <= 0)
                        {
                            isVPS = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if(isVPS == false)
                {
                    sb9012.AppendLine("NO");
                }
                else
                {
                    sb9012.AppendLine((stack.Count ==  0) ? "YES" : "NO");
                }
            }

            Console.WriteLine(sb9012.ToString());
        }
    }
}
