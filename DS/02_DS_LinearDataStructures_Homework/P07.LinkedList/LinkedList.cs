namespace P07.LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public LinkedList()
        {
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(item);
            }
            else
            {
                var newNode = new ListNode<T>(item);
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List was empty.");
            }

            if (index >= this.Count)
            {
                throw new InvalidOperationException("Index was out of bounds.");
            }

            ListNode<T> result = null;
            if (this.Count == 1)
            {
                result = this.head;
                this.head = this.tail = null;
            }
            else
            {
                var counter = 0;
                var currentNode = this.head;
                while (counter < index)
                {
                    currentNode = currentNode.NextNode;
                    counter++;
                }

                result = currentNode;
            }

            this.Count--;
            return result.Value;
        }

        public int FirstIndexOf(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List was empty.");
            }

            var index = -1;
            var counter = 0;
            var currentNode = this.head;
            while (true)
            {
                if (counter >= this.Count)
                {
                    break;
                }

                if (currentNode.Value.Equals(item))
                {
                    index = counter;
                    break;
                }

                currentNode = currentNode.NextNode;
                counter++;
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List was empty.");
            }

            var index = -1;
            var counter = 0;
            var currentElement = this.head;

            while (counter < this.Count)
            {
                if (currentElement.Value.Equals(item))
                {
                    index = counter;
                }

                currentElement = currentElement.NextNode;
                counter++;
            }

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
