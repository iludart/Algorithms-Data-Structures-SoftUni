using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.PermutationsWithRepetition
{
    

    class PermsWithReps
    {
        static int[] numbers = new int[] { 1, 3, 5, 5 };

        static void Main(string[] args)
        {
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= numbers.Length)
            {
                Print();
            }
            else
            {
                var swapped = new HashSet<int>();
                for (int i = index; i < numbers.Length; i++)
                {
                    if (!swapped.Contains(numbers[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(i, index);
                        swapped.Add(numbers[i]);
                    }
                }
            }
        }

        private static void Swap(int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
