namespace P05.OrderedSet_AVLTree_
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private AvlTree<T> tree;

        public OrderedSet()
        {
            this.tree = new AvlTree<T>();
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
            var contains = this.tree.Contains(element);
            return contains;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var elements = new List<T>();
            this.tree.ForeachDfs((depth, x) => elements.Add(x));

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
