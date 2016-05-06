using System;

namespace P00.PriorityQueue
{
    public class Node : IComparable<Node>
    {
        public Node()
        {
            this.Parent = null;
            this.Distance = int.MaxValue;
        }

        public Node Parent { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return this.Distance.ToString();
        }
    }
}
