namespace P04.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = new List<int>();

            for (int index = 0; index < numbers.Length; index++)
            {
                var currentNumberCount = CountCurrentNumberOccurances(numbers, numbers[index]);
                if (currentNumberCount % 2 == 0)
                {
                    result.Add(numbers[index]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static int CountCurrentNumberOccurances(int[] array, int number)
        {
            var currentNumberCount = 0;

            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] == number)
                {
                    currentNumberCount++;
                }
            }

            return currentNumberCount;
        }
    }
}
