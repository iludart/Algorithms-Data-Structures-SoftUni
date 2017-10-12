namespace P05.OrderedSet_AVLTree_
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        private Node<T> left;
        private Node<T> right;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public int BalanceFactor { get; set; }

        public Node<T> Parent { get; set; }

        public Node<T> Left
        {
            get
            {
                return this.left;
            }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.left = value;
            }
        }

        public Node<T> Right
        {
            get
            {
                return this.right;
            }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.right = value;
            }
        }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent != null)
                {
                    if (this.Value.CompareTo(this.Parent.Value) <= 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent != null)
                {
                    if (this.Value.CompareTo(this.Parent.Value) > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public int ChildrenCount
        {
            get
            {
                var childrenCount = 0;
                if (this.Left != null)
                {
                    childrenCount++;
                }

                if (this.Right != null)
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
