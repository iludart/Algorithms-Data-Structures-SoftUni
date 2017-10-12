using System;
using System.Collections.Generic;
using System.Text;

namespace P01.SequencesOfLimitedSum
{
    class Program
    {
        static List<int> combination = new List<int>();
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            var maxSum = int.Parse(Console.ReadLine());
            var currentSum = 0;
            CreateLimitedSum(currentSum, maxSum);
            Console.WriteLine(result.ToString());
        }

        static void CreateLimitedSum(int currentSum, int maxSum)
        {
            if (currentSum > maxSum)
            {
                return;
            }
            else
            {
                result.AppendLine(string.Join(" ", combination));
                for (int i = 1; i <= maxSum; i++)
                {
                    combination.Add(i);
                    currentSum += i;

                    CreateLimitedSum(currentSum, maxSum);

                    combination.RemoveAt(combination.Count - 1);
                    currentSum -= i;
                }
            }
        }
    }
}
