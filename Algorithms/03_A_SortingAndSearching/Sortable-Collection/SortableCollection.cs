namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearchProcedure(item, 0, this.Items.Count - 1);
        }

        private int BinarySearchProcedure(T item, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = start + (end - start) / 2;

            if (item.CompareTo(this.Items[mid]) < 0)
            {
                return this.BinarySearchProcedure(item, start, mid - 1);
            }

            if (item.CompareTo(this.Items[mid]) > 0)
            {
                return this.BinarySearchProcedure(item, mid + 1, end);
            }

            return mid;
        }

        public int InterpolationSearch(T item)
        {
            Type paramType = typeof(T);

            if (paramType.Name != "Int32")
            {
                throw new ArgumentException("Supports int only.");
            }

            int[] collection = this.Items.Select(x => Convert.ToInt32(x)).ToArray();
            int key = Convert.ToInt32(item);

            return this.InterpolationSearchProcedure(collection, key);
        }

        private int InterpolationSearchProcedure(int[] items, int key)
        {
            if (items.Length == 0)
            {
                return -1;
            }

            int low = 0;
            int high = items.Length - 1;
            int mid;

            while (items[high] != items[low] && key >= items[low] && key <= items[high])
            {
                mid = low + ((key - items[low]) * (high - low) / (items[high] - items[low]));

                if (items[mid] < key)
                {
                    low = mid + 1;
                }
                else if (key < items[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (key == items[low])
            {
                return low;
            }
            else
            {
                return -1;
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            
            var n = this.Items.Count;

            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(0, n - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }        
    }
}