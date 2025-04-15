using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public class TKQueue
    {
        private int[] datas;
        private int front;
        private int rear;
        private int amount;
        private int count;

        public TKQueue(int amount)
        {
            datas = new int[amount];
            front = 0;
            rear = -1;
            count = 0;
            this.amount = amount;
        }

        public void Enqueue(int data)
        {
            datas[++rear] = data;
            count++;
        }

        public int Dequeue()
        {
            if(IsEmpty() == true)
            {
                return -1;
            }

            int result = datas[front++];
            count--;
            return result;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsMax()
        {
            return count == amount; 
        }
    }


}
