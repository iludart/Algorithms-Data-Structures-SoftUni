namespace P01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    internal class ReverseNumbers
    {
        static void Main()
        {
            var stack = new Stack<string>(Console.ReadLine().Split());
            var result = new List<string>(stack.Count);

            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
