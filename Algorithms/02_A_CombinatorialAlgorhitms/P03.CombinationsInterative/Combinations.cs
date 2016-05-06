using System;
using System.Collections.Generic;

namespace P03.CombinationsInterative
{
    class Combinations
    {
        public static void Combs(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        Print(result);
                        break;
                    }
                }
            }
        }

        private static void Print(int[] result)
        {
            Console.WriteLine(string.Join(", ", result));
        }

        static void Main()
        {
            Combs(3, 5);
        }
    }
}
