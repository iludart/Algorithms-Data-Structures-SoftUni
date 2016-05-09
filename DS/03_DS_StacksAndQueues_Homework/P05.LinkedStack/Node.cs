namespace P05.LinkedStack
{
    internal class Node<T>
    {
        public Node(T element, Node<T> nextNode = null)
        {
            this.Value = element;
        }

        public T Value { get; set; }

        public Node<T> NextNode { get; set; }
    }
}
