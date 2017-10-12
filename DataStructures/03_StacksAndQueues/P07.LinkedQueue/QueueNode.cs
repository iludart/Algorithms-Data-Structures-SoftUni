namespace P07.LinkedQueue
{
    internal class QueueNode<T>
    {
        public QueueNode(T element, QueueNode<T> prevNode = null, QueueNode<T> nextNode = null)
        {
            this.Value = element;
        }

        public T Value { get; set; }

        public QueueNode<T> NextNode { get; set; }
    }
}
