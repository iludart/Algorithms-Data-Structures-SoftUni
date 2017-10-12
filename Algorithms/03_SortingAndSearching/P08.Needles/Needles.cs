using System;
using System.Linq;

namespace P08.Needles
{
    class Needles
    {

        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions
                .RemoveEmptyEntries).Select(x => int.Parse(x))
                .ToArray();

            string[] needlesAsStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Needle[] needles = ConvertNeedles(needlesAsStrings);
            Array.Sort(needles);

            
            var needleIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currNumIndex = 0;
                var nextNumIndex = 1;

                bool placeNeedle = PlaceNeedle(numbers, prevNumIndex)
            }
        }

        private static Needle[] ConvertNeedles(string[] needlesAsStrings)
        {
            var needles = new Needle[needlesAsStrings.Length];
            for (int i = 0; i < needlesAsStrings.Length; i++)
            {
                var value = int.Parse(needlesAsStrings[i]);
                needles[i] = new Needle() { Value = value, Index = i };
            }

            return needles;
        }

        struct Needle : IComparable<Needle>
        {
            public int Value { get; set; }

            public int Index { get; set; }

            public int CompareTo(Needle other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }
    }
}
