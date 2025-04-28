using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0422
{
    public partial class Program
    {
        //@tk Tree 순회
        public static StringBuilder sb1991 = new StringBuilder();
        public static void BJ1991()
        {
            int nodeCount = int.Parse(Console.ReadLine()!);
            //단방향이다...
            List<char>[] tree = new List<char>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                tree[i] = new List<char>();
            }

            for (int i = 0; i < nodeCount; i++) 
            {
                char[] args = Console.ReadLine()!.ToCharArray();
                char root = args[0];
                char left = args[2];
                char right = args[4];

                tree[root - 'A'].Add(left);
                tree[root - 'A'].Add(right);
            }

            PreOrder1991(tree, 'A');
            sb1991.AppendLine();
            InOrder1991(tree, 'A');
            sb1991.AppendLine();
            PostOrder1991(tree, 'A');
            Console.WriteLine(sb1991.ToString());
        }

        public static void PreOrder1991(List<char>[] tree, char start)
        {
            sb1991.Append(start);
            char left = tree[start - 'A'][0];
            char right = tree[start - 'A'][1];
            if (left != '.')
            {
                PreOrder1991(tree, left);
            }
            if (right != '.')
            {
                PreOrder1991(tree, right);
            }

        }
        public static void InOrder1991(List<char>[] tree, char start)
        {
            char left = tree[start - 'A'][0];
            char right = tree[start - 'A'][1];
            if(left != '.')
            {
                InOrder1991(tree, left);
            }
            sb1991.Append(start);
            if (right != '.')
            {
                InOrder1991(tree, right);
            }
        }
        public static void PostOrder1991(List<char>[] tree, char start)
        {
            char left = tree[start - 'A'][0];
            char right = tree[start - 'A'][1];
            if (left != '.')
            {
                PostOrder1991(tree, left);
            }
            if (right != '.')
            {
                PostOrder1991(tree, right);
            }
            sb1991.Append(start);
        }
    }
}
