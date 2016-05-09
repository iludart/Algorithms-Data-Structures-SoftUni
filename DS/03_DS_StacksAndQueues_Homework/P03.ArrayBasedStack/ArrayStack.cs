namespace P03.ArrayBasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int DefaultInitialCapacity = 16;

        private T[] array;

        public ArrayStack()
        {
            this.array = new T[DefaultInitialCapacity];
        }

        public ArrayStack(int capacity)
        {
            this.array = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity => this.array.Length;

        public void Push(T element)
        {
            if (this.Count == this.array.Length)
            {
                Grow();
            }

            this.array[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop() from empty stack.");
            }

            this.Count--;
            return this.array[this.Count];
        }

        public T[] ToArray()
        {
            var newArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[this.Count - i - 1];
            }

            return newArray;
        }

        private void Grow()
        {
            var newArray = new T[2*this.array.Length];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }
    }
}
