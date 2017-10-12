using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ').ToArray();
            numbers[i] = int.Parse(tokens[0]);
        }

        var lis = new int[n];
        var lisPrev = CreateArray(n);

        lis[0] = 1;
        lisPrev[0] = -1;

        for (int i = 0; i < n; i++)
        {
            lis[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] > numbers[j] && lis[i] <= lis[j])
                {
                    lis[i]++;
                    lisPrev[i] = j;
                }
            }
        }

        var lds = new int[n];
        var ldsPrev = CreateArray(n);

        lds[n - 1] = 1;
        ldsPrev[n - 1] = -1;

        for (int i = n - 1; i >= 0; i--)
        {
            lds[i] = 1;
            for (int j = n - 1; j > i; j--)
            {
                if (numbers[i] > numbers[j] && lds[i] <= lds[j])
                {
                    lds[i]++;
                    ldsPrev[i] = j;
                }
            }
        }

        var max = 0;

        for (int i = 0; i < n; i++)
        {
            var currentMax = lis[i] + lds[i] - 1;
            if (currentMax > max)
            {
                max = currentMax;
            }
        }

        Console.WriteLine(max);
    }

    private static int[] CreateArray(int n)
    {
        var array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = -1;
        }

        return array;   
    }
}
