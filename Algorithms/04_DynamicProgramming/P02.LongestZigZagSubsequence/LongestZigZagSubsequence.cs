
using System;
using System.Collections.Generic;
using System.Linq;

class LongestZigZagSubsequence
{
    static void Main()
    {
        var sequence = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int[] lzzs = FindLongestZigZagSequence(sequence);
        Console.WriteLine(string.Join(" ", lzzs));
    }

    private static int[] FindLongestZigZagSequence(int[] sequence)
    {
        // creating two pairs of arrays so we can keep track of sequences with 1)odds 2)evens that are bigger
        // odds are bigger length and prev
        var lenOddIsBigger = new int[sequence.Length];
        var prevOddIsBigger = new int[sequence.Length];

        // evens are bigger length and prev
        var lenEvenIsBigger = new int[sequence.Length];
        var prevEvenIsBigger = new int[sequence.Length];

        var maxLen = 0;
        var maxPrev = -1;

        bool isOddsBigger = false;

        for (int x = 0; x < sequence.Length; x++)
        {
            lenOddIsBigger[x] = 1;
            prevOddIsBigger[x] = -1;

            lenEvenIsBigger[x] = 1;
            prevEvenIsBigger[x] = -1;

            for (int i = 0; i < x; i++)
            {
                // check sequence when odds have bigger values
                if (lenOddIsBigger[i] % 2 == 0)
                {
                    if (sequence[x] > sequence[i] && lenOddIsBigger[x] <= lenOddIsBigger[i])
                    {
                        lenOddIsBigger[x] = lenOddIsBigger[i] + 1;
                        prevOddIsBigger[x] = i;
                    }
                }
                else
                {
                    if (sequence[x] < sequence[i] && lenOddIsBigger[x] <= lenOddIsBigger[i])
                    {
                        lenOddIsBigger[x] = lenOddIsBigger[i] + 1;
                        prevOddIsBigger[x] = i;
                    }
                }

                // check sequence when evens have bigger values
                if (lenEvenIsBigger[i] % 2 == 0)
                {
                    if (sequence[x] < sequence[i] && lenEvenIsBigger[x] <= lenEvenIsBigger[i])
                    {
                        lenEvenIsBigger[x] = lenEvenIsBigger[i] + 1;
                        prevEvenIsBigger[x] = i;
                    }
                }
                else
                {
                    if (sequence[x] > sequence[i] && lenEvenIsBigger[x] <= lenEvenIsBigger[i])
                    {
                        lenEvenIsBigger[x] = lenEvenIsBigger[i] + 1;
                        prevEvenIsBigger[x] = i;
                    }
                }
            }

            if (lenOddIsBigger[x] > maxLen)
            {
                maxLen = lenOddIsBigger[x];
                maxPrev = x;
                isOddsBigger = true;
            }

            if (lenEvenIsBigger[x] > maxLen)
            {
                maxLen = lenEvenIsBigger[x];
                maxPrev = x;
                isOddsBigger = false;
            }
        }

        
        var longesLzzs = new List<int>();
        if (isOddsBigger)
        {
            while (maxPrev != -1)
            {
                longesLzzs.Add(sequence[maxPrev]);
                maxPrev = prevOddIsBigger[maxPrev];
            }
        }
        else
        {
            while (maxPrev != -1)
            {
                longesLzzs.Add(sequence[maxPrev]);
                maxPrev = prevEvenIsBigger[maxPrev];
            }
        }

        longesLzzs.Reverse();
        return longesLzzs.ToArray();
    }
}
