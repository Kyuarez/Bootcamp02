using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0422
{
    public class Node5639
    {
        public int Data;
        public Node5639 Left;
        public Node5639 Right;
        public Node5639()
        {
            this.Data = -1;
        }
        public bool IsEmtpy()
        {
            return this.Data == -1;
        }

        public Node5639 GetNextNode(int nextData)
        {
            if (nextData > this.Data)
            {
                if (Right == null)
                {
                    Right = new Node5639();
                }
                return Right;
            }
            else
            {
                if (Left == null)
                {
                    Left = new Node5639();
                }
                return Left;
            }
        }
    }

    //이진 트리
    public static StringBuilder sb5639 = new StringBuilder();
        public static void BJ5639()
        {
            //내 생각
            //1. 어쨋든, 첫번째 값은 무조건 root다
            //2. 다음 값도 재귀의 입장에서 루트다.(전위니까). 그러면 재귀로 데이터 넣으면?

            Node5639 root = new Node5639();

            while (true)
            {
                // 빈 값이 입력되면 종료
                string inputData = Console.ReadLine()!;
                if (inputData == null || inputData == "")
                {
                    break;
                }

                int data = int.Parse(inputData);
                MakeBinaryTree(root, data);
            }

            PostOrder(root);
            Console.WriteLine(sb5639.ToString());
        }

        public static void MakeBinaryTree(Node5639 root, int data)
        {
            if (root.IsEmtpy() == true)
            {
                root.Data = data;
                return;
            }

            MakeBinaryTree(root.GetNextNode(data), data);
        }

        public static void PostOrder(Node5639 root)
        {
            if (root.Left != null)
            {
                PostOrder(root.Left);
            }
            if (root.Right != null)
            {
                PostOrder(root.Right);
            }
            sb5639.AppendLine(root.Data.ToString());
        }
    } 
}
