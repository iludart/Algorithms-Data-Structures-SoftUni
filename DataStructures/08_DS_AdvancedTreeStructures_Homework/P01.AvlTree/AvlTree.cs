namespace P01.AvlTree
{
    using System;

    public class AvlTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public AvlTree()
        { }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new InvalidOperationException("Invalid index");
                }

                return this.GetElementAtIndex(index, this.root);
            }
        }

        private T GetElementAtIndex(int index, Node<T> node)
        {
            if (index == node.LeftSubtreeSize)
            {
                return node.Value;
            }

            if (index <= node.LeftSubtreeSize)
            {
                return this.GetElementAtIndex(index, node.LeftChild);
            }
            else
            {
                return this.GetElementAtIndex(index - node.LeftSubtreeSize - 1, node.RightChild);
            }
        }

        public void Add(T item)
        {
            var inserted = false;
            if (this.root == null)
            {
                this.root = new Node<T>(item);
                inserted = true;
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }

            if (inserted)
            {
                this.Count++;
            }
        }

        public void Range(T start, T end)
        {
            this.PrintNodeInRange(this.root, start, end);
        }

        private void PrintNodeInRange(Node<T> node, T start, T end)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value.CompareTo(start) > 0)
            {
                this.PrintNodeInRange(node.LeftChild, start, end);
            }

            if (node.Value.CompareTo(start) >= 0 && node.Value.CompareTo(end) <= 0)
            {
                Console.Write(node.Value + " ");
            }

            if (node.Value.CompareTo(end) < 0)
            {
                this.PrintNodeInRange(node.RightChild, start, end);
            }
        }

        private Node<T> Search(T item)
        {
            var node = this.root;
            while (node != null)
            {
                if (item.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (item.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        public bool Contains(T item)
        {
            var node = this.root;
            while (node != null)
            {
                if (item.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (item.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                this.InOrderDfs(node.LeftChild, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.RightChild != null)
            {
                this.InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            var shouldRetrace = false;
            while (true)
            {
                if (item.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }
                    
                    currentNode = currentNode.LeftChild;
                }
                else if (item.CompareTo(currentNode.Value) > 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return false;
                }
            }

            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }

            this.IncrementLeftSubtreeSizes(newNode);
            return true;
        }

        private void IncrementLeftSubtreeSizes(Node<T> node)
        {
            var currentNode = node;
            var parent = node.Parent;
            while (parent != null)
            {
                if (currentNode.IsLeftChild)
                {
                    parent.LeftSubtreeSize++;
                }

                currentNode = parent;
                parent = currentNode.Parent;
            }
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;
                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = 1;
                    }
                }
                else
                {
                    if (parent.BalanceFactor == -1)
                    {
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = -1;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.LeftChild = child.RightChild;
            node.LeftSubtreeSize = node.LeftSubtreeSize - child.LeftSubtreeSize - 1;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.RightChild = child.LeftChild;
            child.LeftSubtreeSize = child.LeftSubtreeSize + node.LeftSubtreeSize + 1;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Min(node.BalanceFactor, 0);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
