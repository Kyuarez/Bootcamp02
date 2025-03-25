namespace TKThread
{
    internal class Program
    {
        static object _lock = new object(); //동기화 객체
        public static int Money = 0;

        static void Add()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //lock (_lock)
                //{
                //    Money++;
                //}

                Interlocked.Increment(ref Money);
            }
        }

        static void Remove()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //lock (_lock)
                //{
                //    Money--;
                //}

                Interlocked.Decrement(ref Money);
            }
        }


        static void Main(string[] args)
        {
            Thread threadAdd = new Thread(new ThreadStart(Add));
            Thread threadRemove = new Thread(new ThreadStart(Remove));

            threadAdd.IsBackground = true;
            threadAdd.Start();
            threadRemove.IsBackground = true;
            threadRemove.Start();

            threadAdd.Join();
            threadRemove.Join();

            Console.WriteLine(Money.ToString());

        }
    }
}
