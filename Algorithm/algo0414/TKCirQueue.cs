using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0414
{
    public class TKCirQueue
    {
        private int[] datas;
        private int front;
        private int rear;
        private int amount;
        private int count;

        public TKCirQueue(int amount)
        {
            datas = new int[amount];
            front = 0;
            rear = 0;
            count = 0;
            this.amount = amount;
        }

        public void Enqueue(int data)
        {
            if(IsMax() == true)
            {
                //Debug
                Console.WriteLine("Is Full");
                return;
            }
            datas[rear] = data;
            rear = (rear + 1) % amount;
            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty() == true)
            {
                return -1;  
            }

            int result = datas[front];
            front = (front + 1) % amount;
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

        //@tk : Debug
        public void PrintQueue()
        {
            for (int i = 0; i < datas.Length; i++) 
            {
                Console.WriteLine(datas[i]);
            }
        }
    }
}
