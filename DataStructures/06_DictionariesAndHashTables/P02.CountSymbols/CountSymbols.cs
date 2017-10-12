namespace P02.CountSymbols
{
    using System;
    using System.Linq;
    using P01.Dictionary;

    public class CountSymbols
    {
        static void Main()
        {
            var input = "Did you know Math.Round rounds to the nearest even integer?";
            var dictionary = new CustomDictionary<char, int>();

            foreach (var ch in input)
            {
                var currentCount = 0;
                if (dictionary.ContainsKey(ch))
                {
                    currentCount = dictionary[ch];
                }

                dictionary[ch] = currentCount + 1;
            }

            var sorted = dictionary.OrderBy(kv => kv.Key);
            foreach (var keyValue in sorted)
            {
                Console.WriteLine("{0} -> {1}", keyValue.Key, keyValue.Value);
            }
        }
    }
}
