using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.GuitarV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var startValue = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());
            var currentMax = startValue;

            var set = new HashSet<int>();
            var list = new List<int>();

            set.Add(startValue);
            list.Add(startValue);

            var startIndex = 0;
            var endIndex = 0;
            var lastNumberOfTonesAdded = 0;

            for (int i = 0; i < songs.Length; i++)
            {
                var newTonesAdded = 0;
                for (int current = startIndex; current <= endIndex; current++)
                {
                    var newIncrement = list[current] + songs[i];
                    var newDecrement = list[current] - songs[i];
                    if (newIncrement <= max && !set.Contains(newIncrement))
                    {
                        list.Add(newIncrement);
                        set.Add(newIncrement);
                        newTonesAdded++;
                    }

                    if (newDecrement >= 0 && !set.Contains(newDecrement))
                    {
                        list.Add(newDecrement);
                        set.Add(newDecrement);
                        newTonesAdded++;
                    }
                }

                startIndex = endIndex + 1;
                endIndex = endIndex + newTonesAdded;
                lastNumberOfTonesAdded = newTonesAdded;
            }

            var result = startValue;
            for (int i = list.Count - lastNumberOfTonesAdded - 1; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
