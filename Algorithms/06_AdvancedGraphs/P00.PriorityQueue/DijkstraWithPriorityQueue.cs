namespace PQueue
{
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            var nodeCount = graph.Count;
            int?[] previous = new int?[nodeCount];
            bool[] visited = new bool[nodeCount];

            var queue = new PriorityQueue<Node>();
            foreach (var pair in graph)
            {
                pair.Key.DistanceFromStart = double.PositiveInfinity;
            }

            sourceNode.DistanceFromStart = 0;
            queue.Enqueue(sourceNode);

            while (queue.Count > 0)
            {
                var currentNode = queue.ExtractMin();

                if (currentNode == destinationNode)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    var child = edge.Key;
                    if (!visited[child.Id])
                    {
                        queue.Enqueue(child);
                        visited[child.Id] = true;
                    }

                    var newDistance = currentNode.DistanceFromStart + edge.Value;

                    if (newDistance < child.DistanceFromStart)
                    {
                        child.DistanceFromStart = newDistance;
                        previous[child.Id] = currentNode.Id;
                        queue.DecreaseKey(child);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            var path = new List<int>();
            int? current = destinationNode.Id;
            while (current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
