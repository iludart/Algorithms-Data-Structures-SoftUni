namespace P04.OrderedSet
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
