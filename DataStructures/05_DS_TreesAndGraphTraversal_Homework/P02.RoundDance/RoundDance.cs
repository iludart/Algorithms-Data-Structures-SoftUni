namespace P02.RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundDance
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;

        static void Main()
        {
            var edgeCount = int.Parse(Console.ReadLine());
            var initialNode = int.Parse(Console.ReadLine());

            ReadGraph(initialNode, edgeCount);

            visited = new HashSet<int>();
            int longestDanceCount = DFS(initialNode, 1, 1);

            Console.WriteLine(longestDanceCount);
        }

        private static int DFS(int node, int currentPath, int longestPath)
        {
            visited.Add(node);

            if (currentPath > longestPath)
            {
                longestPath = currentPath;
            }

            foreach (var childNode in graph[node])
            {
                if (!visited.Contains(childNode))
                {
                    longestPath = DFS(childNode, currentPath + 1, longestPath);
                }
            }

            return longestPath;
        }

        private static void ReadGraph(int initialNode, int edgeCount)
        {
            graph = new Dictionary<int, List<int>>();
            graph.Add(initialNode, new List<int>());

            for (int i = 0; i < edgeCount; i++)
            {
                var connectedNodes =
                    Console.ReadLine()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                AddNode(connectedNodes[0]);
                AddNode(connectedNodes[1]);
                ConnectNodes(connectedNodes[0], connectedNodes[1]);
            }
        }

        private static void ConnectNodes(int f1, int f2)
        {
            graph[f1].Add(f2);
            graph[f2].Add(f1);
        }

        private static void AddNode(int friend)
        {
            if (!graph.ContainsKey(friend))
            {
                graph.Add(friend, new List<int>());
            }
        }
    }
}
