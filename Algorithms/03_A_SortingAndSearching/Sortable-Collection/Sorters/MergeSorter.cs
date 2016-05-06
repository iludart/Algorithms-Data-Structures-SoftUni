namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, new T[collection.Count], 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, T[] temporaryArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;

                this.MergeSort(array, temporaryArray, start, middle);
                this.MergeSort(array, temporaryArray, middle + 1, end);

                int leftMinIndex = start;
                int rightMinIndex = middle + 1;
                int tempIndex = 0;

                while (leftMinIndex <= middle && rightMinIndex <= end)
                {
                    if (array[leftMinIndex].CompareTo(array[rightMinIndex]) <= 0)
                    {
                        temporaryArray[tempIndex] = array[leftMinIndex];
                        leftMinIndex++;
                        tempIndex++;
                    }
                    else
                    {
                        temporaryArray[tempIndex] = array[rightMinIndex];
                        rightMinIndex++;
                        tempIndex++;
                    }
                }

                while (leftMinIndex <= middle)
                {
                    temporaryArray[tempIndex] = array[leftMinIndex];
                    leftMinIndex++;
                    tempIndex++;
                }

                while (rightMinIndex <= end)
                {
                    temporaryArray[tempIndex] = array[rightMinIndex];
                    rightMinIndex++;
                    tempIndex++;
                }

                tempIndex = 0;
                leftMinIndex = start;

                while (tempIndex < temporaryArray.Length && leftMinIndex <= end)
                {
                    array[leftMinIndex] = temporaryArray[tempIndex];
                    leftMinIndex++;
                    tempIndex++;
                }
            }
        }
    }
}
