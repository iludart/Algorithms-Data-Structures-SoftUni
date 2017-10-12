using System.Collections.Generic;

namespace KruskalDisjointSets
{
    public class Program
    {
        static List<Edge> graphEdges = new List<Edge>
        {
            new Edge(0, 3, 9),
            new Edge(0, 5, 4),
            new Edge(0, 8, 5),
            new Edge(1, 4, 8),
            new Edge(1, 7, 7),
            new Edge(2, 6, 12),
            new Edge(3, 5, 2),
            new Edge(3, 6, 8),
            new Edge(3, 8, 20),
            new Edge(4, 7, 10),
            new Edge(6, 8, 7)
        };

        static void Main(string[] args)
        {
            var sets = new HashSet<DisjointSet<int>>();

            graphEdges.Sort();

            var disSetA = new DisjointSet<int>(new Node<int>(5));
            var disSetB = new DisjointSet<int>(new Node<int>(6));

            disSetA.

            //foreach (var edge in graphEdges)
            //{
            //    var start = new Node<int>(edge.StartNode);
            //    var end = new Node<int>(edge.EndNode);

            //    sets.Add(new DisjointSet<int>(start));
            //    sets.Add(new DisjointSet<int>(end));

            //    if (true)
            //    {

            //    }
            //}
        }
    }
}
