namespace P03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var longestSubsequence = GetLongestSubsequence(sequence);

            Console.WriteLine(string.Join(" ", longestSubsequence));
        }

        private static List<int> GetLongestSubsequence(List<int> list)
        {
            if (list.Count == 0)
            {
                return list;
            }

            var longestSequenceIndex = 0;
            var longestSequenceCount = 0;

            var index = 0;
            while (index < list.Count)
            {
                var currentSubsequenceLength = GetCurrentSubsequenceLength(list, index);
                if (currentSubsequenceLength > longestSequenceCount)
                {
                    longestSequenceIndex = index;
                    longestSequenceCount = currentSubsequenceLength;
                }

                index += currentSubsequenceLength;
            }

            var longestSubsequence = list.GetRange(longestSequenceIndex, longestSequenceCount);
            return longestSubsequence;
        }

        private static int GetCurrentSubsequenceLength(List<int> list, int index)
        {
            var sequenceLengthCounter = 0;
            while (index + sequenceLengthCounter < list.Count && list[index + sequenceLengthCounter] == list[index])
            {
                sequenceLengthCounter++;
            }

            return sequenceLengthCounter;
        }
    }
}
