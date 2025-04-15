using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    /* 
     [후입선출]
     - Push
     - Pop
     - Top
     */
    public class TKStack
    {
        private int[] datas;
        private int top; //index
        private int amount;
        private int count;

        public int Count => count;

        public TKStack(int amount)
        {
            this.datas = new int[amount];
            this.top = -1;
            this.amount = amount;
            count = 0;
        }

        public void Push(int data)
        {
            if (top < amount - 1)
            {
                datas[++top] = data;
                count++;
            }
            //예외처리
        }

        public int Pop()
        {
            if (top >= 0)
            {
                count--;
                return datas[top--];
            }
            else
            {
                return -1;
            }
        }

        public int Peek()
        {
            if (top >= 0)
            {
                count--;
                return datas[top];
            }
            else
            {
                return -1;
            }
        }

        public void Clear()
        {
            datas = new int[amount];
            top = -1;
            count = 0;
        }
    }


    public class TKNode
    {
        public int Data;
        public TKNode Next;
        public TKNode Prev;

    }

    public class TKConnectStack
    {
        public TKNode Top;

        public TKConnectStack(TKNode root = null)
        {
            
        }

        public void Push(int data)
        {
            TKNode node = new TKNode();
            node.Data = data;
            Top.Next = node;
            node.Prev = Top;
            
            Top = node;
        }

        public int Pop()
        {
            int result = Top.Data;
            TKNode prev = Top.Prev;
            prev.Next = null;
            return result;
        }
    }

}
