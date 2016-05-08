using System;
using System.Collections.Generic;
using PQueue;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_ExtendCableNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = 7;
            var nodes = new Dictionary<int, Node>()
            {
                {0, new Node(0) },
                {1, new Node(1) },
                {2, new Node(2) },
                {3, new Node(3) },
            };

            var graph = new Dictionary<Node, Dictionary<Node, int>>()
            {
                {nodes[0], new Dictionary<Node, int>() { { nodes[1], 9 }, { nodes[3], 4} } },
                {nodes[1], new Dictionary<Node, int>() { { nodes[0], 9 }, { nodes[3], 6}, { nodes[2], 5 } } },
                {nodes[2], new Dictionary<Node, int>() { { nodes[1], 5 }, { nodes[3], 11} } },
                {nodes[3], new Dictionary<Node, int>() { { nodes[0], 4 }, { nodes[2], 11} } },
            };

            var existingNetwork = new HashSet<Node>();
            existingNetwork.Add(nodes[0]);
            existingNetwork.Add(nodes[2]);
            existingNetwork.Add(nodes[3]);

            Prim(graph, nodes, existingNetwork, budget);
        }

        private static void Prim(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, HashSet<Node> existingNetwork, int budget)
        {
            var queue = new PriorityQueue<Node>();
            foreach (var node in nodes.Values)
            {
                if (!existingNetwork.Contains(node))
                {
                    queue.Enqueue(node);
                }
            }

            var toBreak = false;

            while (existingNetwork.Count > 0)
            {
                var currentNode = queue.ExtractMin();

                foreach (var child in graph[currentNode].Keys)
                {
                    var edgeLength = graph[currentNode][child];
                    if (graph[currentNode][child] < child.DistanceFromStart)
                    {
                        if (edgeLength < budget)
                        {
                            child.Parent = currentNode;
                            child.DistanceFromStart = edgeLength;
                            Console.WriteLine("{{0}, {1}} -> {2}", currentNode.Id, child.Id, edgeLength);
                        }
                        else
                        {
                            toBreak = true;
                            break;
                        }
                    }
                }

                if (toBreak)
                {
                    break;
                }
            }
        }
    }
}
