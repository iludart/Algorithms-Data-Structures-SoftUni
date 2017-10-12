namespace P02.RangeInTree
{
    using P01.AvlTree;
    using System;
    using System.Linq;

    class RangeInTree
    {
        static void Main()
        {
            var tree = new AvlTree<int>();
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            foreach (var number in numbers)
            {
                tree.Add(number);
            }

            var range = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var start = range[0];
            var end = range[1];

            tree.Range(start, end);
            Console.WriteLine();
        }
    }
}
