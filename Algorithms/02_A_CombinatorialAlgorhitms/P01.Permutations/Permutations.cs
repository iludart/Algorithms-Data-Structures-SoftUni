using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Permutations
{
    class Permutations
    {
        static int n = int.Parse(Console.ReadLine());
        static int[] array = Enumerable.Range(1, n).ToArray();
        static int totalPermutations = 0;

        static void Main(string[] args)
        {
            Permute(0);
            Console.WriteLine(totalPermutations);
        }

        static void Permute(int index)
        {
            if (index >= array.Length)
            {
                Print(array);
                totalPermutations++;
            }
            else
            {
                for (int i = index; i < array.Length; i++)
                {
                    Swap(i, index);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int i, int index)
        {
            if (i == index)
            {
                return;
            }

            int temp = array[i];
            array[i] = array[index];
            array[index] = temp;
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
