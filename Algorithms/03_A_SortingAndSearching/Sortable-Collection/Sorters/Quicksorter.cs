namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }    
        
        private void Quicksort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int p = Partition(array, start, end);
            Quicksort(array, start, p - 1);
            Quicksort(array, p + 1, end);
        }

        private int Partition(List<T> array, int start, int end)
        {
            T pivot = array[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    Swap(array, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            Swap(array, start, storeIndex);
            return storeIndex;
        }

        private void Swap(List<T> array, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
