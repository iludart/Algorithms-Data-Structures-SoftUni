using System;
using System.Linq;

namespace P02.IterativePermutations
{
    class IterativePermutations
    {
        static int n = int.Parse(Console.ReadLine());
        static int[] array = Enumerable.Range(1, n).ToArray();
        static int[] perm = Enumerable.Range(0, n + 1).ToArray();

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", array));

            int i = 1;

            while (i < array.Length)
            {
                perm[i]--;
                int j = i % 2 != 0 ? j = perm[i] : 0;
                Swap(j, i);
                i = 1;
                while (perm[i] == 0)
                {
                    perm[i] = i;
                    i++;
                }

                Console.WriteLine(string.Join(", ", array));
            }
        }

        private static void Swap(int j, int i)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
