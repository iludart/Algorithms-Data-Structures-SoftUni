namespace P07.LinkedList
{
    public class ListNode<T>
    {
        public ListNode(T element)
        {
            this.Value = element;
        }

        public T Value { get; }

        public ListNode<T> NextNode { get; set; }
    }
}
