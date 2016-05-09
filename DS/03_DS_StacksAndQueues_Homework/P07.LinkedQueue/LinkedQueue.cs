namespace P07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public LinkedQueue()
        {
        }

        public LinkedQueue(T element)
        {
            this.head = this.tail = new QueueNode<T>(element);
            this.Count++;
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new QueueNode<T>(element);
            }
            else
            {
                var newTail = new QueueNode<T>(element);
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack was empty.");
            }

            var result = this.head.Value;
            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
            }

            this.Count--;
            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack was empty.");
            }

            var result = this.head.Value;
            return result;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            var index = 0;
            while (this.Count > 0)
            {
                array[index] = this.Dequeue();
                index++;
            }

            return array;
        }
    }
}
