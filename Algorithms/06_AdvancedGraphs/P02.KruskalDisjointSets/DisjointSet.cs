using System;

namespace KruskalDisjointSets
{
    public class DisjointSet<T> : IComparable<DisjointSet<T>> where T : IComparable<T>
    {
        public DisjointSet(Node<T> node)
        {
            this.Representative = node;
            node.Parent = node;
        }

        public Node<T> Representative { get; set; }

        public void Union(Node<T> x, Node<T> y)
        {
            this.Link(this.FindSet(x), this.FindSet(y));
        }

        private void Link(Node<T> x, Node<T> y)
        {
            if (x.Rank > y.Rank)
            {
                y.Parent = x;
            }
            else
            {
                x.Parent = y;
                if (x.Rank == y.Rank)
                {
                    y.Rank = y.Rank + 1;
                }
            }
        }

        private Node<T> FindSet(Node<T> node)
        {
            if (node != node.Parent)
            {
                node.Parent = this.FindSet(node.Parent);
            }

            return node.Parent;
        }

        public int CompareTo(DisjointSet<T> other)
        {
            return this.Representative.CompareTo(other.Representative);
        }
    }
}
