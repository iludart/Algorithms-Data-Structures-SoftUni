using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Bridges
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bridges = new int[] { 7, 3, 4, 5, 3, 6, 7, 2, 4, 5, 6, 8, 6, 8 };
            var bridges = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var found = new List<int>();
            var last = 0;

            for (int i = 0; i < bridges.Length; i++)
            {
                for (int j = last; j < i; j++)
                {
                    var start = bridges[j];
                    var end = bridges[i];
                    if (start == end)
                    {
                        found.Add(j);
                        found.Add(i);
                        last = i;
                        break;
                    }
                }
            }

            var result = new string[bridges.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = "X";
            }

            for (int i = 0; i < found.Count; i++)
            {
                var index = found[i];
                result[index] = bridges[index].ToString();
            }

            if (found.Count == 0)
            {
                Console.WriteLine("No bridges found");
                Console.WriteLine(string.Join(" ", result));
            }
            else if (found.Count / 2 == 1)
            {
                Console.WriteLine(found.Count / 2 + " bridge found");
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(found.Count / 2 + " bridges found");
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
