using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0422
{
    public partial class Program
    {
        public struct Edge1167
        {
            public int Child;
            public int Weight;

            public Edge1167(int child, int weight)
            {
                Child = child;
                Weight = weight;
            }
        }

        //트리의 지름 (4번)
        public static void BJ1167()
        {
            //Data Setting
            int nodeCount = int.Parse(Console.ReadLine()!);
            List<Edge1167>[] tree = new List<Edge1167>[nodeCount];
            for (int i = 0; i < tree.Length; i++)
            {
                tree[i] = new List<Edge1167>();
            }

            int root = -1;
            for (int i = 0; i < nodeCount; i++)
            {
                string[] args = Console.ReadLine()!.Split();
                int vertex = int.Parse(args[0]);
                if (i == 0)
                {
                    root = vertex;
                }

                for (int j = 1; j < args.Length; j += 2)
                {
                    if (j == args.Length - 1)
                    {
                        break;
                    }

                    int child = int.Parse(args[j]);
                    int weight = int.Parse(args[j + 1]);
                    tree[vertex - 1].Add(new Edge1167(child, weight));
                }
            }

            bool[] isVisited = new bool[nodeCount];
            long[] pathRecorder = new long[nodeCount];
            DFS1167(tree, isVisited, pathRecorder, root);

            int maxNode = -1;
            long maxPath = 0;
            for (int i = 0; i < pathRecorder.Length; i++)
            {
                if (pathRecorder[i] > maxPath)
                {
                    maxPath = pathRecorder[i];
                    maxNode = i + 1;
                }
            }

            isVisited = new bool[nodeCount];
            pathRecorder = new long[nodeCount];
            DFS1167(tree, isVisited, pathRecorder, maxNode);

            maxNode = -1;
            maxPath = 0;
            for (int i = 0; i < pathRecorder.Length; i++)
            {
                if (pathRecorder[i] > maxPath)
                {
                    maxPath = pathRecorder[i];
                    maxNode = i + 1;
                }
            }
            Console.WriteLine(maxPath);
        }

        public static void DFS1167(List<Edge1167>[] tree, bool[] isVisited, long[] pathRecorder, int start)
        {
            isVisited[start - 1] = true;

            List<Edge1167> adjacents = tree[start - 1];
            for (int i = 0; i < adjacents.Count; i++)
            {
                if (isVisited[adjacents[i].Child - 1] == false)
                {
                    pathRecorder[adjacents[i].Child - 1] = pathRecorder[start - 1] + adjacents[i].Weight;
                    DFS1167(tree, isVisited, pathRecorder, adjacents[i].Child);
                }
            }
        }
    }
