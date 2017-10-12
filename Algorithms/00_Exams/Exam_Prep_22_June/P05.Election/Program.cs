using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var min = int.Parse(Console.ReadLine());
        var n = int.Parse(Console.ReadLine());
        var numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        var sums = new Dictionary<int, int>();

        for (int i = 1; i < numbers.Length; i++)
        {
            var currentNum = numbers[i];

            if (!sums.ContainsKey(currentNum))
            {
                sums.Add(currentNum, 1);
            }

            var pastSums = sums.Keys.ToArray();
            foreach (var sum in pastSums)
            {
                var newSum = sum + currentNum;
                if (!sums.ContainsKey(newSum))
                {
                    sums.Add(newSum, 0);
                }

                sums[newSum]++;
            }
        }

        var count = sums.Where(x => x.Key >= min).Select(x => x.Value).Sum();
        Console.WriteLine(count);
    }
}
