using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P00.PriorityQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node v1 = new Node();
            Node v2 = new Node();
            Node v3 = new Node();
            Node v4 = new Node();

            var pQueue = new PriorityQueue<Node>();
            pQueue.Enqueue(v1);
            pQueue.Enqueue(v2);
            pQueue.Enqueue(v3);
            pQueue.Enqueue(v4);

            v4.Distance = 0;
        }
    }
}
