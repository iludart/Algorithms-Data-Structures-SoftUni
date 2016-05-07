using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalDisjointSets
{
    public class Program
    {
        static void Main(string[] args)
        {
            var node = new Node(5);
            var set = new DisjointSet<Node>(node);
        }
    }
}
