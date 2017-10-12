namespace P02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        static void Main()
        {
            var words = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var sortedWords = SortWordsAlphabetically(words);

            Console.WriteLine(string.Join(" ", sortedWords));
        }

        private static List<string> SortWordsAlphabetically(List<string> words)
        {
            if (words.Count == 0)
            {
                return words;
            }

            for (int index = 0; index < words.Count; index++)
            {
                bool toPerformSwap = false;

                var wordCandidateIndex = index;
                for (int innerIterator = index + 1; innerIterator < words.Count; innerIterator++)
                {
                    bool isWordAlphabeticallyLowest = 
                        words[innerIterator].CompareTo(words[wordCandidateIndex]) < 0;
                    if (isWordAlphabeticallyLowest)
                    {
                        wordCandidateIndex = innerIterator;
                        toPerformSwap = true;
                    }
                }

                if (toPerformSwap)
                {
                    Swap(words, index, wordCandidateIndex);
                }
            }

            return words;
        }

        private static void Swap(List<string> words, int index, int wordCandidateIndex)
        {
            var temp = words[index];
            words[index] = words[wordCandidateIndex];
            words[wordCandidateIndex] = temp;
        }
    }
}
