using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Sticks
{
    class Program
    {
        //static Dictionary<int, List<int>> graph;
        static HashSet<int> visitedNodes;
        static LinkedList<int> sortedNodes;
        static HashSet<int> cycleNodes;
        static HashSet<int> endCycles = new HashSet<int>();
        static bool isCycle = false;

        static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        //{
        //    {0, new List<int>() { 3 } },
        //    {1, new List<int>() { 0 } },
        //    {2, new List<int>() { 1, 3 } },
        //    {3, new List<int>() { 1 } },
        //    {4, new List<int>() {  } },
        //};

        public static void Main()
        {
            ReadGraph();
            var sorted = TopSort();

            if (isCycle)
            {
                Console.WriteLine("Cannot lift all sticks");
                foreach (var item in sorted)
                {
                    if (!endCycles.Contains(item))
                    {
                        Console.Write(item + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", sorted));
            }
        }

        static void ReadGraph()
        {
            int sticks = int.Parse(Console.ReadLine());
            int placings = int.Parse(Console.ReadLine());

            for (int i = 0; i < sticks; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < placings; i++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                graph[tokens[0]].Add(tokens[1]);
            }
        }

        public static LinkedList<int> TopSort()
        {
            visitedNodes = new HashSet<int>();
            sortedNodes = new LinkedList<int>();
            cycleNodes = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                TopSortDFS(node);
            }

            return sortedNodes;
        }

        private static void TopSortDFS(int node)
        {
            if (cycleNodes.Contains(node))
            {
                isCycle = true;

                foreach (var item in cycleNodes)
                {
                    endCycles.Add(item);
                }
            }

            if (!visitedNodes.Contains(node))
            {
                visitedNodes.Add(node);
                cycleNodes.Add(node);

                if (graph.ContainsKey(node))
                {
                    foreach (var child in graph[node])
                    {
                        TopSortDFS(child);
                    }
                }

                cycleNodes.Remove(node);
                sortedNodes.AddFirst(node);
            }
        }
    }
}
