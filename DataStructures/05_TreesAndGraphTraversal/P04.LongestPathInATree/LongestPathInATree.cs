namespace P04.LongestPathInATree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPathInATree
    {
        private static Dictionary<int, List<int>> tree;
        private static Dictionary<int, int?> parents;

        static void Main()
        {
            var nodeCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());

            ReadTree(nodeCount, edgeCount);

            var longestPath = FindLongestPath();
            Console.WriteLine(longestPath);
        }

        private static int FindLongestPath()
        {
            var longestPath = int.MinValue;
            var nodes = tree.Keys.ToArray();
            for (int indexA = 0; indexA < nodes.Length; indexA++)
            {
                for (int indexB = indexA + 1; indexB < nodes.Length; indexB++)
                {
                    var nodeA = nodes[indexA];
                    var nodeB = nodes[indexB];

                    var lca = FindLeastCommonAncestor(nodeA, nodeB);

                    var sumToRootNodeLCA = FindSumToRoot(lca);
                    var sumAtoLCA = FindSumToRoot(nodeA) - sumToRootNodeLCA + lca;
                    var sumBtoLCA = FindSumToRoot(nodeB) - sumToRootNodeLCA + lca;
                    var currentPath = sumAtoLCA + sumBtoLCA - lca;
                    if (currentPath > longestPath)
                    {
                        longestPath = currentPath;
                    }
                }
            }

            return longestPath;
        }

        private static int FindSumToRoot(int node)
        {
            var sum = node;
            while (parents[node] != null)
            {
                node = (int)parents[node];
                sum += node;
            }

            return sum;
        }

        private static int FindLeastCommonAncestor(int nodeA, int nodeB)
        {
            var stackA = new Stack<int>();
            var stackB = new Stack<int>();

            stackA.Push(nodeA);
            stackB.Push(nodeB);

            var parentA = parents[nodeA];
            var parentB = parents[nodeB];

            while (parentA != null)
            {
                stackA.Push((int)parentA);
                parentA = parents[(int)parentA];
            }

            while (parentB != null)
            {
                stackB.Push((int)parentB);
                parentB = parents[(int)parentB];
            }

            int lca = stackA.Peek();

            while (stackA.Count != 0 && stackB.Count != 0)
            {
                if (stackA.Peek() != stackB.Pop())
                {
                    break;
                }

                lca = stackA.Pop();
            }

            return lca;
        }

        private static void ReadTree(int nodeCount, int edgeCount)
        {
            tree = new Dictionary<int, List<int>>();
            parents = new Dictionary<int, int?>();

            for (int i = 0; i < edgeCount; i++)
            {
                var edge =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                AddNode(edge[0]);
                AddNode(edge[1]);
                CreateEdge(edge[0], edge[1]);
            }
        }

        private static void CreateEdge(int parent, int child)
        {
            tree[parent].Add(child);
            parents[child] = parent;
        }

        private static void AddNode(int node)
        {
            if (!tree.ContainsKey(node))
            {
                tree.Add(node, new List<int>());
                parents.Add(node, null);
            }
        }
    }
}
