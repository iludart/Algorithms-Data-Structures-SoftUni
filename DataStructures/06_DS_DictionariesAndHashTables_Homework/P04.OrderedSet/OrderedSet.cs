namespace P04.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> tree;

        public OrderedSet()
        {
            this.tree = new BinaryTree<T>();
        }

        public int Count
        {
            get { return this.tree.Count; }
        }

        public void Add(T element)
        {
            this.tree.Add(element);
        }

        public void Remove(T element)
        {
            this.tree.Remove(element);
        }

        public bool Contains(T element)
        {
            var node = this.tree.Find(element);
            if (node != null)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var elements = this.tree.GetElements();
            foreach (var element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
