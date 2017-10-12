namespace P05.LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public LinkedStack()
        {
        }
        
        public LinkedStack(T element)
        {
            this.firstNode = new Node<T>(element);
            this.Count++;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            var newFirstNode = new Node<T>(element);
            newFirstNode.NextNode = this.firstNode;
            this.firstNode = newFirstNode;
            this.Count++;
        }
        
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack was empty.");
            }

            var result = this.firstNode.Value;
            if (this.Count == 1)
            {
                this.firstNode = null;
            }
            else
            {
                this.firstNode = this.firstNode.NextNode;
            }

            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            var index = 0;
            while (this.Count > 0)
            {
                array[index] = this.Pop();
                index++;
            }

            return array;
        }
    }
}
