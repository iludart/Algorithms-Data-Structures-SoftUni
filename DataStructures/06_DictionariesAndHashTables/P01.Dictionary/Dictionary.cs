namespace P01.Dictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomDictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const float LoadFactor = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] dictionary; 

        public CustomDictionary()
        {
            this.dictionary = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
        }

        public CustomDictionary(int capacity)
        {
            this.dictionary = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public int Capacity => this.dictionary.Length;

        public int Count { get; private set; }

        public IEnumerable<TKey> Keys
        {
            get { return this.Select(element => element.Key); }
        }

        public IEnumerable<TValue> Values
        {
            get { return this.Select(element => element.Value); }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }

            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.GrowIfNeeded();

            var slot = this.GetSlot(key);

            if (this.dictionary[slot] == null)
            {
                this.dictionary[slot] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            var elements = this.dictionary[slot];

            foreach (var element in elements)
            {
                if (key.Equals(element.Key))
                {
                    throw new ArgumentException("Key already exists.");
                }
            }

            this.dictionary[slot].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
        }

        private bool AddOrReplace(TKey key, TValue value)
        {
            this.GrowIfNeeded();

            var slot = this.GetSlot(key);

            if (this.dictionary[slot] == null)
            {
                this.dictionary[slot] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            var elements = this.dictionary[slot];

            foreach (var element in elements)
            {
                if (key.Equals(element.Key))
                {
                    element.Value = value;
                    return true;
                }
            }

            this.dictionary[slot].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
            return false;
        }

        public bool Remove(TKey key)
        {
            var slot = this.GetSlot(key);
            var elements = this.dictionary[slot];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (key.Equals(element.Key))
                    {
                        elements.Remove(element);
                        this.Count--;
                        return true;
                    }
                }
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);
            if (element == null)
            {
                throw new ArgumentException();
            }

            return element.Value;
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.Find(key);
            return element != null;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slot = this.GetSlot(key);

            if (this.dictionary[slot] != null)
            {
                foreach (var element in this.dictionary[slot])
                {
                    if (key.Equals(element.Key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var elements in this.dictionary)
            {
                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void GrowIfNeeded()
        {
            if ((float)(this.Count + 1) / this.dictionary.Length > LoadFactor)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            var newDictionary = new CustomDictionary<TKey, TValue>(2 * this.Capacity);
            foreach (var element in this)
            {
                newDictionary.Add(element.Key, element.Value);
            }

            this.dictionary = newDictionary.dictionary;
            this.Count = newDictionary.Count;
        }

        private int GetSlot(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % this.dictionary.Length;
        }
    }
}
