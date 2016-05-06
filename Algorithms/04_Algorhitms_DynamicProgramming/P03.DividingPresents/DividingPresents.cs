using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var presents = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        var subsets = GenerateSubsets(presents);
        var maxValue = presents.Sum();
        var minDifference = maxValue;
        var optimalSum = 0;

        foreach (var sum in subsets)
        {
            var firstBrotherValue = maxValue - sum.Key;
            var secondBrotherValue = maxValue - firstBrotherValue;

            var currentDifference = Math.Abs(firstBrotherValue - secondBrotherValue);

            if (currentDifference < minDifference)
            {
                minDifference = currentDifference;
                optimalSum = sum.Key;
            }
        }

        var firstBrotherPresents = new List<int>();
        var reverseSum = optimalSum;
        while (reverseSum != 0)
        {
            firstBrotherPresents.Add(subsets[reverseSum]);
            reverseSum -= subsets[reverseSum];
        }

        Console.WriteLine("Difference: " + minDifference);
        Console.WriteLine("Alan:" + optimalSum + " Bob:" + (maxValue - optimalSum));
        Console.WriteLine("Alan takes: " + string.Join(", ", firstBrotherPresents));
        Console.WriteLine("Bob takes rest.");
    }

    private static Dictionary<int, int> GenerateSubsets(int[] presents)
    {
        var subsets = new Dictionary<int, int>();
        subsets.Add(0, 0);

        for (int i = 0; i < presents.Length; i++)
        {
            var newSubsets = new Dictionary<int, int>();
            foreach (var subset in subsets.Keys)
            {
                int newSubset = subset + presents[i];
                if (!newSubsets.ContainsKey(newSubset))
                {
                    newSubsets.Add(newSubset, presents[i]);
                }
            }

            foreach (var subset in newSubsets)
            {
                if (!subsets.ContainsKey(subset.Key))
                {
                    subsets.Add(subset.Key, subset.Value);
                }
            }
        }

        return subsets;
    }
}
