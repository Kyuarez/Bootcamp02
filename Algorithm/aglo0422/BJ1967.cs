using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0422
{
    public partial class Program
    {

        //@TK : 트리의 지름
        public static void BJ1967()
        {
            int nodeCount = int.Parse(Console.ReadLine()!);
            List<Edge1967>[] tree = new List<Edge1967>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                tree[i] = new List<Edge1967>();
            }
            
            for (int i = 0; i < nodeCount - 1; i++)
            {
                string[] args = Console.ReadLine()!.Split();
                int root = int.Parse(args[0]);
                int child = int.Parse(args[1]);
                int weight = int.Parse(args[2]);

                tree[root - 1].Add(new Edge1967(child, weight));
                tree[child - 1].Add(new Edge1967(root, weight));
            }

            //인접 리스트 Sort
            int diameter = 0;
            for (int i = 1; i <= nodeCount; i++)
            {
                int compare = 0;

                Queue<int> queue = new Queue<int>();
                int[] isVisited = new int[nodeCount];
                queue.Enqueue(i);
                isVisited[i - 1] = 1;

                //BFS
                while (queue.Count > 0) 
                {
                    int search = queue.Dequeue();

                    foreach (Edge1967 edge in tree[search - 1]) 
                    {
                        if(isVisited[edge.child - 1] <= 0)
                        {
                            isVisited[edge.child - 1] = edge.weight + isVisited[search - 1];
                            queue.Enqueue(edge.child);
                        }
                    }
                }

                
                diameter = Math.Max(diameter, isVisited.Max() - 1);    
            }

            Console.WriteLine(diameter);
        }


        public struct Edge1967
        {
            public int child;
            public int weight;

            public Edge1967(int child, int weight)
            {
                this.child = child;
                this.weight = weight;
            }
        }

        static StringBuilder stringBuilder = new StringBuilder();



        static List<(int node, int weight)>[] tree1967;
        static Dictionary<(int, int), int> weight1967Dict = new Dictionary<(int, int), int>();
        public static void BJ196DFS()
        {
            int num = int.Parse(Console.ReadLine());

            tree1967 = new List<(int, int)>[num];
            for (int i = 0; i < num; i++)
            {
                tree1967[i] = new List<(int, int)>();
            }

            for (int i = 0; i < num - 1; i++)
            {
                string[] inputNum = Console.ReadLine().Split();
                int first = int.Parse(inputNum[0]) - 1;
                int second = int.Parse(inputNum[1]) - 1;
                int weight = int.Parse(inputNum[2]);

                weight1967Dict[(first, second)] = weight;
                weight1967Dict[(second, first)] = weight;

                tree1967[first].Add((second, weight));
                tree1967[second].Add((first, weight));
            }

            (int, int) node = DFS1967(0, -1);
            Console.WriteLine(DFS1967(node.Item2, -1).Item1);
        }
        static (int weight, int node) DFS1967(int current, int parent)
        {
            int maxWeight = 0;
            int farthestNode = current;

            foreach (var (next, weight) in tree1967[current])
            {
                if (next != parent)
                {
                    var (childWeight, childNode) = DFS1967(next, current);
                    childWeight += weight;

                    if (childWeight > maxWeight)
                    {
                        maxWeight = childWeight;
                        farthestNode = childNode;
                    }
                }
            }

            return (maxWeight, farthestNode);
        }
    }
}
