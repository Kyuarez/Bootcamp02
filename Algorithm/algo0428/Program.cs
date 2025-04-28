namespace algo0428
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //Key, value(priority)
            //PriorityQueue<string, int> pQueue = new PriorityQueue<string, int>();
            //pQueue.Enqueue("TK", 10);
            //pQueue.Enqueue("JS", 5);
            //pQueue.Enqueue("BC", 3);

            //Console.WriteLine(pQueue.Dequeue());
            //Console.WriteLine(pQueue.Dequeue());
            //Console.WriteLine(pQueue.Dequeue());

            TKMinHeap heap = new TKMinHeap();
            for (int i = 1; i < 10; i++)
            {
                heap.Enqueue(i);
            }
            

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine(heap.Dequeue());
            }


        }
    }
}
