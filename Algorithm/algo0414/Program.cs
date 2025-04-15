namespace algo0414
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //Stack
            //BJ10828();
            //BJ10773();
            //BJ9012();
            //BJ4949();
            //BJ1874();

            //Queue
            //BJ10845();
            //BJ18258();
            //BJ2164();
            //BJ11866();
            //BJ1966();
            //BJ10866();

            //Test
            TKCirQueue testQueue = new TKCirQueue(5);
            testQueue.Enqueue(1);
            testQueue.Enqueue(2);
            testQueue.Enqueue(3);
            testQueue.PrintQueue();
            testQueue.Dequeue();
            testQueue.Enqueue(4);
            testQueue.Enqueue(5);
            testQueue.Enqueue(6);
            testQueue.Enqueue(7);
            testQueue.PrintQueue();
        }
    }
}
