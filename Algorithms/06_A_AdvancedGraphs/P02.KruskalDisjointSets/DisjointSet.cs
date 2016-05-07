using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KruskalDisjointSets;

namespace KruskalDisjointSets
{
    public class DisjointSet<KruskalDisjointSets.Node>
    {
        public DisjointSet(KruskalDisjointSets.Node node)
        {
            this.Representative = node;
            node.Parent = node;
        }

        public Node Representative { get; set; }
    }
}
