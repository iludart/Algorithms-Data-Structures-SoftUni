using System;
using System.Collections.Generic;

class DistanceBetweenVertices
{
    static void Main()
    {
        var graph = new Dictionary<int, List<int>>();
        graph.Add(11, new List<int>() { 4 });
        graph.Add(4, new List<int>() { 12, 1 });
        graph.Add(1, new List<int>() { 12, 21, 7 });
        graph.Add(7, new List<int>() { 21 });
        graph.Add(12, new List<int>() { 4, 19 });
        graph.Add(19, new List<int>() { 1, 21 });
        graph.Add(21, new List<int>() { 14, 31 });
        graph.Add(14, new List<int>() { 14 });
        graph.Add(31, new List<int>() { });

        var distance = FindDistanceBetweenVertices(graph, 1, 11);
        Console.WriteLine(distance);
    }

    private static int FindDistanceBetweenVertices(Dictionary<int, List<int>> graph, int start, int destination)
    {

        var distanceFromRoot = new Dictionary<int, int>();

        foreach (var vertex in graph.Keys)
        {
            distanceFromRoot.Add(vertex, -1);
        }

        distanceFromRoot[start] = 0;
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            var currentVertex = queue.Dequeue();


            foreach (var child in graph[currentVertex])
            {
                if (distanceFromRoot[child] == -1)
                {
                    distanceFromRoot[child] = distanceFromRoot[currentVertex] + 1;
                    queue.Enqueue(child);

                    if (child == destination)
                    {
                        break;
                    }
                }
            }
        }

        return distanceFromRoot[destination];
    }
}
