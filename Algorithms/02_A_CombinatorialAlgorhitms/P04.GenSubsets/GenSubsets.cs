using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.GenSubsets
{
    class GenSubsets
    {
        static string[] set = new string[] { "test", "rock", "fun" };
        static int k = 2;
        static string[] vector = new string[k];

        static void Main(string[] args)
        {
            Gen(0, 0);
        }

        private static void Gen(int index, int start)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    Gen(index + 1, i + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", vector));
        }
    }
}
