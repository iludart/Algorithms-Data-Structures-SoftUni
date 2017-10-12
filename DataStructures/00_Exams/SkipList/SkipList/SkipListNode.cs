namespace SkipList
{
    using System;

    public class SkipListNode<T> : Node<T>
    {
        private SkipListNode() { }   // no default constructor available, must supply height
        public SkipListNode(int height)
        {
            base.Neighbors = new SkipListNodeList<T>(height);
        }

        public SkipListNode(T value, int height) : base(value)
        {
            base.Neighbors = new SkipListNodeList<T>(height);
        }

        public int Height
        {
            get { return base.Neighbors.Count; }
        }

        public SkipListNode<T> this[int index]
        {
            get { return (SkipListNode<T>)base.Neighbors[index]; }
            set { base.Neighbors[index] = value; }
        }

        public void IncrementHeight()
        {
            base.Neighbors.Add(default(Node<T>));
        }

        public void DecrementHeight()
        {
            base.Neighbors.RemoveAt(base.Neighbors.Count - 1);
        }
    }
}
