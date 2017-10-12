using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.CombinationsWithoutRepetition
{
    class CombsWithoutReps
    {
        static void Main()
        {
            int n = 5;
            int k = 3;

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
                GenerateCombinations(arr, n, k, index + 1, i + 1);
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
