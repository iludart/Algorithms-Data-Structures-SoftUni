namespace P05.CountOfOccurances
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var distinctNumbers = numbers.Distinct();

            foreach (var number in distinctNumbers)
            {
                var currentNumberOccurances = CountCurrentNumberOccurances(numbers.ToArray(), number);
                Console.WriteLine("{0} -> {1} times", number, currentNumberOccurances);
            }
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
