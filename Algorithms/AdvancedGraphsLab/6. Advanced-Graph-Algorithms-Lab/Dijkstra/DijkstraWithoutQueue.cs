namespace Dijkstra
{
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            var nodeCount = graph.GetLength(0);
            var distances = new int[nodeCount];
            var visited = new bool[nodeCount];
            var previous = new int?[nodeCount];

            // initialize distances
            for (int i = 0; i < nodeCount; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[sourceNode] = 0;

            while (true)
            {
                var minNode = 0;
                var minDistance = int.MaxValue;

                // find min node
                for (int node = 0; node < nodeCount; node++)
                {
                    if (!visited[node] && distances[node] < minDistance)
                    {
                        minNode = node;
                        minDistance = distances[node];
                    }
                }

                // break if all nodes are visited
                if (minDistance == int.MaxValue)
                {
                    break;
                }

                visited[minNode] = true;

                // check adjacent nodes
                for (int node = 0; node < nodeCount; node++)
                {
                    if (graph[minNode, node] > 0)
                    {
                        var newDistance = distances[minNode] + graph[minNode, node];
                        if (newDistance < distances[node])
                        {
                            distances[node] = newDistance;
                            previous[node] = minNode;
                        }
                    }
                }
            }

            // check if there is a path to dest
            if (distances[destinationNode] == int.MaxValue)
            {
                return null;
            }

            // reconstruct paths
            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
