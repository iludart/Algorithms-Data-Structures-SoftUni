namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InsertionSort(collection);
        }

        private void InsertionSort(List<T> collection)
        {
            for (int primaryIndex = 1; primaryIndex < collection.Count; primaryIndex++)
            {
                var secondaryIndex = primaryIndex;
                while (secondaryIndex > 0 && collection[secondaryIndex - 1].CompareTo(collection[secondaryIndex]) > 0)
                {
                    Swap(collection, secondaryIndex, secondaryIndex - 1);
                    secondaryIndex = secondaryIndex - 1;
                }
            }
        }

        private void Swap(List<T> collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
    }
}
