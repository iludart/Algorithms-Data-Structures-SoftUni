namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            edges.Sort();
            var mst = new List<Edge>();
            foreach (var edge in edges)
            {
                var rootA = FindRoot(edge.StartNode, parent);
                var rootB = FindRoot(edge.EndNode, parent);
                if (rootA != rootB)
                {
                    mst.Add(edge);
                    parent[rootA] = rootB;
                }
            }

            return mst;
        }

        public static int FindRoot(int node, int[] parent)
        {
            var root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            return root;
        }
    }
}
