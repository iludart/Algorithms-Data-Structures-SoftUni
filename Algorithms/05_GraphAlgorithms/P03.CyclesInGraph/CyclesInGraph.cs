using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.CyclesInGraph
{
    class CyclesInGraph
    {
        static Dictionary<char, List<char>> graph;
        static HashSet<char> visited;
        static bool hasCycles = false;

        static void Main(string[] args)
        {
            visited = new HashSet<char>();
            ReadGraph();
            HasCycles();
            Console.WriteLine("Acyclic: {0}", (hasCycles ? "No" : "Yes"));
        }

        private static void HasCycles()
        {
            foreach (var vertex in graph.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    DFS(vertex);
                }
            }
        }

        private static void DFS(char vertex)
        {
            visited.Add(vertex);

            if (graph.ContainsKey(vertex))
            {
                foreach (var child in graph[vertex])
                {
                    if (visited.Contains(child))
                    {
                        hasCycles = true;
                    }

                    DFS(child);
                }
            }
        }

        private static void ReadGraph()
        {
            graph = new Dictionary<char, List<char>>();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var nodes = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x.Trim()))
                    .ToArray();

                if (!graph.ContainsKey(nodes[0]))
                {
                    graph.Add(nodes[0], new List<char>());
                }

                graph[nodes[0]].Add(nodes[1]);
                line = Console.ReadLine();
            }
        }
    }
}
