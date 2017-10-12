using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Substring(7);
            var people = command
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            command = Console.ReadLine().Substring(12);
            var connections = command
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            command = Console.ReadLine().Substring(6);
            var startNodes = command
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var graph = new Dictionary<string, List<string>>();
            var distances = new Dictionary<string, int>();
            var queue = new Queue<string>();
            var peopleByDistance = new Dictionary<int, List<string>>();

            foreach (var person in people)
            {
                graph[person] = new List<string>();
            }

            foreach (var connection in connections)
            {
                var users = connection
                    .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                var start = users[0];
                var end = users[1];

                graph[start].Add(end);
                graph[end].Add(start);
            }

            peopleByDistance[0] = new List<string>();
            foreach (var person in startNodes)
            {
                distances[person] = 0;
                queue.Enqueue(person);
                
                peopleByDistance[0].Add(person);
            }

            var max = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var child in graph[current])
                {
                    if (!distances.ContainsKey(child))
                    {
                        var newDistance = distances[current] + 1;
                        distances[child] = newDistance;

                        if (!peopleByDistance.ContainsKey(newDistance))
                        {
                            peopleByDistance[newDistance] = new List<string>();
                        }

                        peopleByDistance[newDistance].Add(child);
                        queue.Enqueue(child);

                        if (newDistance > max)
                        {
                            max = newDistance;
                        }
                    }
                }
            }

            var nonReachable = graph.Keys
                .Where(x => !distances.ContainsKey(x))
                .OrderBy(x => x)
                .ToList();
            
            if (nonReachable.Count != 0)
            {
                nonReachable.Sort();
                Console.WriteLine("Cannot reach: {0}", 
                    string.Join(", ", nonReachable));
            }
            else
            {
                var peopleOnLastStep = peopleByDistance[max]
                    .OrderBy(x => x);

                Console.WriteLine("All people reached in {0} steps", max);
                Console.WriteLine("People at last step: {0}", string.Join(", ", peopleOnLastStep));
            }
        }
    }
}
