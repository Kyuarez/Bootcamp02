namespace algoPath
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //ConstructGraph();
            //int[] path;
            //Console.WriteLine(TKDijkstra(0, 3, out path));

            //Stack<int> pathStack = new Stack<int>();
            //int back = 3;
            //int start = 0;
            //pathStack.Push(back);
            //while (back != start) 
            //{
            //    if (path[back] == -1)
            //    {
            //        break;
            //    }

            //    pathStack.Push(path[back]);
            //    back = path[back];
            //}

            //while(pathStack.Count > 0)
            //{
            //    Console.Write(pathStack.Pop().ToString() + "->");
            //}

            ConstructAstarMap();
            FindStartAndEnd();
            TKAstar();
            PrintMap();
        }
    }
}
