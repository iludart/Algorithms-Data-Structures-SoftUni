namespace P01.FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTheRoot
    {
        private static Dictionary<Node, List<Node>> graph;
        private static Dictionary<int, Node> nodes;

        public static void Main()
        {
            ReadGraph();
            var roots = FindRoots();

            if (roots.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (roots.Count == 1)
            {
                Console.WriteLine(roots[0].Value);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }

        private static List<Node> FindRoots()
        {
            var roots = new List<Node>();

            foreach (var node in nodes.Values)
            {
                if (!node.HasParent)
                {
                    roots.Add(node);
                }
            }

            return roots;
        }

        private static void ReadGraph()
        {
            var nodeCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());

            graph = new Dictionary<Node, List<Node>>();
            nodes = new Dictionary<int, Node>();

            for (int i = 0; i < edgeCount; i++)
            {
                var edge =
                    Console.ReadLine()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                if (!nodes.ContainsKey(edge[0]))
                {
                    AddNode(edge[0]);
                }

                if (!nodes.ContainsKey(edge[1]))
                {
                    AddNode(edge[1]);
                }

                CreateEdge(edge[0], edge[1]);
            }
        }

        private static void AddNode(int value)
        {
            var node = new Node() {Value = value};
            graph.Add(node, new List<Node>());
            nodes.Add(value, node);
        }

        private static void CreateEdge(int parentValue, int childValue)
        {
            var parentNode = nodes[parentValue];
            var childNode = nodes[childValue];

            graph[parentNode].Add(childNode);
            childNode.HasParent = true;
        }
    }
}
