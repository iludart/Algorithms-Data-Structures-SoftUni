using System;

namespace KruskalDisjointSets
{
    public class Node : IComparable<Node>
    {
        public Node(int value)
        {
            this.Value = value;
            this.Parent = this;
            this.Rank = 0;
        }

        public Node Parent { get; set; }

        public int Value { get; set; }

        public int Rank { get; set; }

        public int CompareTo(Node other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
