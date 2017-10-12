namespace P01.AvlTree
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get { return this.rightChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public Node<T> Parent { get; set; }

        public int LeftSubtreeSize { get; set; }

        public int BalanceFactor { get; set; }

        public bool IsLeftChild
        {
            get { return this.Value.CompareTo(this.Parent.Value) < 0; }
        }

        public bool IsRightChild
        {
            get { return this.Value.CompareTo(this.Parent.Value) > 0; }
        }

        public int ChildrenCount
        {
            get
            {
                int childrenCount = 0;
                if (this.LeftChild != null)
                {
                    childrenCount++;
                }

                if (this.RightChild != null)
                {
                    childrenCount++;
                }

                return childrenCount;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString(); 
        }
    }
}
