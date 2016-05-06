using System;

namespace P03.CombinationsWithRepetition
{
    class CombsWithReps
    {
        static void Main()
        {
            int n = 3;
            int k = 2;

            int[] arr = new int[k];
            GenerateCombinations(arr, n, k, 0, 1);
        }

        static void GenerateCombinations(int[] arr, int n, int k, int index, int nextElement)
        {
            if (index >= k)
            {
                Print(arr);
                return;
            }

            for (int i = nextElement; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, n, k, index + 1, nextElement);
                nextElement++;
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
