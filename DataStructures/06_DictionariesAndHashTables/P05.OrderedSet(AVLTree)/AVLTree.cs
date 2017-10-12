namespace P05.OrderedSet_AVLTree_
{
    using System;
    using System.Collections.Generic;

    public class AvlTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public AvlTree()
        {
        }

        public int Count { get; set; }

        public void Add(T item)
        {
            var inserted = true;
            if (this.root == null)
            {
                this.root = new Node<T>(item);
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

        public bool Remove(T item)
        {
            var removed = this.RemoveInternal(item);
            return removed;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        public bool Contains(T item)
        {
            var node = this.root;
            while (node != null)
            {
                var result = node.Value.CompareTo(item);
                if (result < 0)
                {
                    node = node.Right;
                }
                else if (result > 0)
                {
                    node = node.Left;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            var shouldRetrace = false;

            while (true)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.Right;
                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.Left;
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

            return true;
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
                        parent.BalanceFactor--;
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
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

        private void RetraceDelete(Node<T> node)
        {
            var parent = node.Parent;

            while (parent != null)
            {
                if (node.IsRightChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        var sibling = parent.Left;
                        if (sibling.BalanceFactor == -1)
                        {
                            this.RotateLeft(sibling);
                        }

                        this.RotateRight(parent);
                        if (sibling.BalanceFactor == 0)
                        {
                            break;
                        }
                    }

                    if (parent.BalanceFactor == 0)
                    {
                        parent.BalanceFactor = 1;
                        break;
                    }

                    parent.BalanceFactor = 0;
                }
                else
                {
                    if (parent.BalanceFactor == -1)
                    {
                        var sibling = parent.Right;
                        if (sibling.BalanceFactor == 1)
                        {
                            this.RotateRight(sibling);
                        }

                        this.RotateLeft(parent);

                        if (parent.BalanceFactor == 0)
                        {
                            parent.BalanceFactor = -1;
                            break;
                        }

                        parent.BalanceFactor = 0;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.Right;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.Right = child.Left;
            child.Left = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.Left;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.Left = child.Right;
            child.Right = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.Left != null)
            {
                this.InOrderDfs(node.Left, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.Right != null)
            {
                this.InOrderDfs(node.Right, depth + 1, action);
            }
        }

        private bool RemoveInternal(T value)
        {
            // Check if there are elements in the tree
            if (this.root == null)
            {
                return false;
            }

            Node<T> current = this.root;
            Node<T> parent = null;

            // Find the node to remove and its parent
            int result = value.CompareTo(current.Value);
            while (result != 0)
            {
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }

                if (current == null)
                {
                    return false;
                }
                else
                {
                    result = value.CompareTo(current.Value);
                }
            }

            this.Count--;
            this.RemoveNode(current, parent);

            if (parent != null)
            {
                this.RetraceDelete(parent);
            }

            return true;
        }

        private void RemoveNode(Node<T> current, Node<T> parent)
        {
            if (current.ChildrenCount == 0)
            {
                if (parent == null)
                {
                    this.root = null;
                    return;
                }

                if (current.IsLeftChild)
                {
                    parent.Left = null;
                }
                else if (current.IsRightChild)
                {
                    parent.Right = null;
                }

                current = null;
            }
            else if (current.ChildrenCount == 1)
            {
                if (parent == null)
                {
                    this.root = current.Left ?? current.Right;
                    this.root.Parent = null;
                    return;
                }

                if (current.IsLeftChild)
                {
                    parent.Left = current.Left ?? current.Right;
                }
                else
                {
                    parent.Right = current.Left ?? current.Right;
                }

                current = null;
            }
            else
            {
                var inOrderPredecessor = current.Left;
                while (inOrderPredecessor.Right != null)
                {
                    inOrderPredecessor = inOrderPredecessor.Right;
                }

                current.Value = inOrderPredecessor.Value;
                this.RemoveNode(inOrderPredecessor, inOrderPredecessor.Parent);
            }
        }
    }
}
