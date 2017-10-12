namespace P04.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public BinaryTree()
        {
        }

        public int Count { get; set; }

        public void Add(T element)
        {
            var node = new Node<T>(element);
            int comparisonResult;

            Node<T> currentNode = this.root;
            Node<T> parentNode = null;

            while (currentNode != null)
            {
                comparisonResult = element.CompareTo(currentNode.Value);
                if (comparisonResult == 0)
                {
                    return;
                }
                else if (comparisonResult < 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else if (comparisonResult > 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                }
            }

            this.Count++;
            if (parentNode == null)
            {
                this.root = node;
            }
            else
            {
                comparisonResult = element.CompareTo(parentNode.Value);
                if (comparisonResult < 0)
                {
                    parentNode.Left = node;
                }
                else if (comparisonResult > 0)
                {
                    parentNode.Right = node;
                }
            }
        }

        public List<T> GetElements()
        {
            var elements = new List<T>();
            GetElementsDFS(this.root, elements);
            return elements;
        }

        private void GetElementsDFS(Node<T> node, List<T> elements)
        {
            if (node != null)
            {
                if (node.Left != null)
                {
                    GetElementsDFS(node.Left, elements);
                }

                elements.Add(node.Value);

                if (node.Right != null)
                {
                    GetElementsDFS(node.Right, elements);
                }
            }
        }

        public Node<T> Find(T element)
        {
            return this.BinarySearch(this.root, element);
        }

        private Node<T> BinarySearch(Node<T> node, T element)
        {
            if (node != null)
            {
                if (node.Value.CompareTo(element) == 0)
                {
                    return node;
                }

                if (node.Left != null && element.CompareTo(node.Value) < 0)
                {
                    return BinarySearch(node.Left, element);
                }

                if (node.Right != null && element.CompareTo(node.Value) > 0)
                {
                    return BinarySearch(node.Right, element);
                }
                
            }

            return null;
        }

        public bool Remove(T value)
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

            if (current.Right == null)
            {
                if (parent == null)
                {
                    this.root = current.Left;
                }
                else
                {
                    result = current.Value.CompareTo(parent.Value);
                    if (result < 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result > 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    this.root = current.Right;
                }
                else
                {
                    result = current.Value.CompareTo(parent.Value);
                    if (result < 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result > 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                var leftmostParent = current.Right;
                var leftmost = current.Right.Left;

                while (leftmost != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    root = leftmost;
                }
                else
                {
                    result = current.Value.CompareTo(parent.Value);
                    if (result < 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result > 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }
    }
}
