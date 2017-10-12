namespace P01_SumAndAverage
{
    using System;
    using System.Linq;

    public class SumAndAverage
    {
        static void Main()
        {
            var numbers = 
                Console.ReadLine()
                    .Trim()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x)).ToList();

            var sum = numbers.Sum();
            var average = numbers.DefaultIfEmpty(0).Average();

            Console.WriteLine("Sum={0}; Average={1}", sum, average);
        }
    }
}
