using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algo0407
{
    public partial class Program
    {
        public static void KeyLogger()
        {
            int testCount = int.Parse(Console.ReadLine());
            LinkedList<char> keyList;
            LinkedListNode<char> currentNode;

            for (int i = 0; i < testCount; i++)
            {
                keyList = new LinkedList<char>();
                keyList.AddLast(' ');
                currentNode = keyList.Last;
                string keyData = Console.ReadLine();

                foreach (char key in keyData)
                {
                    switch (key)
                    {
                        case '<':
                            { 
                                if (currentNode.Previous == null)
                                {
                                    break;
                                }
                                currentNode = currentNode.Previous;
                            }
                            break;
                        case '>':
                            {
                                if(currentNode.Next == null)
                                {
                                    break;
                                }
                                currentNode = currentNode.Next;
                            }
                            break;
                        case '-':
                            {
                                if(currentNode.Previous == null)
                                {
                                    break;
                                }

                                keyList.Remove(currentNode.Previous);
                            }
                            break;
                        default:
                            {
                                keyList.AddBefore(currentNode, key);
                            }
                            break;
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (char key in keyList)
                {
                    sb.Append(key);
                }
                Console.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// 링크드 리스트 직접 구현
        /// </summary>
        public static void KeyLoggerWithTK()
        {
            int testCount = int.Parse(Console.ReadLine());
            LinkedList<char> keyList;
            LinkedListNode<char> currentNode;

            for (int i = 0; i < testCount; i++)
            {
                keyList = new LinkedList<char>();
                keyList.AddLast(' ');
                currentNode = keyList.Last;
                string keyData = Console.ReadLine();

                foreach (char key in keyData)
                {
                    switch (key)
                    {
                        case '<':
                            {
                                if (currentNode.Previous == null)
                                {
                                    break;
                                }
                                currentNode = currentNode.Previous;
                            }
                            break;
                        case '>':
                            {
                                if (currentNode.Next == null)
                                {
                                    break;
                                }
                                currentNode = currentNode.Next;
                            }
                            break;
                        case '-':
                            {
                                if (currentNode.Previous == null)
                                {
                                    break;
                                }

                                keyList.Remove(currentNode.Previous);
                            }
                            break;
                        default:
                            {
                                keyList.AddBefore(currentNode, key);
                            }
                            break;
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (char key in keyList)
                {
                    sb.Append(key);
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
