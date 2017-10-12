using System;
using System.Collections.Generic;

namespace P00.BFS
{
    class Program
    {
        static List<int>[] graph = new List<int>[]
        {
            new List<int>() { 4, 2, 5 },
            new List<int>() { 2, 5, 0 },
            new List<int>() { 0, 4, 5, 1 },
            new List<int>() { 5 },
            new List<int>() { 0, 2 },
            new List<int>() { 0, 1, 2, 3 },
        };

        static Dictionary<int, int> distances = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            BFS(0);

            foreach (var vertex in distances)
            {
                Console.WriteLine("vertex: {0}, distanse from start: {1}", vertex.Key, vertex.Value);
            }
        }

        static void BFS(int start)
        {
            
            for (int vertex = 0; vertex < graph.Length; vertex++)
            {
                distances[vertex] = -1;
            }

            var queue = new Queue<int>();
            queue.Enqueue(start);
            distances[start] = 0;

            while (queue.Count != 0)
            {
                var parent = queue.Dequeue();

                foreach (var child in graph[parent])
                {
                    if (distances[child] == -1)
                    {
                        distances[child] = distances[parent] + 1;
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
}
