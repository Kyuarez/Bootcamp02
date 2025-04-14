using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public partial class Program
    {
        public static StringBuilder sb4949 = new StringBuilder();

        public static void BJ4949()
        {
            Stack<char> bracketsStack = new Stack<char>(); //괄호 스택

            while (true)
            {
                bracketsStack.Clear();
                
                string arg = Console.ReadLine();

                if (arg == ".")
                {
                    break;
                }

                bool isBalance = true;
                char[] dataArr = arg.ToCharArray();
                foreach (char data in dataArr)
                {
                    if(data == '[' || data == '(')
                    {
                        bracketsStack.Push(data);
                    }
                    else if(data == ']')
                    {
                        if (bracketsStack.Count <= 0)
                        {
                            isBalance = false;
                            break;
                        }

                        if (bracketsStack.Peek() != '[')
                        {
                            isBalance = false;
                            break;
                        }
                        else
                        {
                            bracketsStack.Pop();
                        }
                    }
                    else if (data == ')')
                    {
                        if (bracketsStack.Count <= 0)
                        {
                            isBalance = false;
                            break;
                        }

                        if (bracketsStack.Peek() != '(')
                        {
                            isBalance = false;
                            break;
                        }
                        else
                        {
                            bracketsStack.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                //input
                if(isBalance == false)
                {
                    sb4949.AppendLine("no");
                }
                else
                {
                    sb4949.AppendLine(bracketsStack.Count == 0 ? "yes" : "no");
                }

            }

            Console.WriteLine(sb4949.ToString());
        }
    }
}
