using System;

namespace P02.NestedLoopToRecursion
{
    class NestedLoopToRecursion
    {
        static void Main()
        {
            int n = 3;
            int[] arr = new int[n];

            SimulateNestedLoops(arr, 0);
        }

        static void SimulateNestedLoops(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Print(arr);
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                SimulateNestedLoops(arr, index + 1);
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
