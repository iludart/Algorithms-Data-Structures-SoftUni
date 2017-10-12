namespace KruskalDisjointSets
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Parent = this;
            this.Rank = 0;
        }

        public Node<T> Parent { get; set; }

        public T Value { get; set; }

        public int Rank { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public int CompareTo(Node<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
