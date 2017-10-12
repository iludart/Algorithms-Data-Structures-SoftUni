namespace P01.AvlTree
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var tree = new AvlTree<int>();
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            //var numbers = new int[] {20, 30, 5, 8, 14, 18, -2, 0, 50, 50,};

            foreach (var number in numbers)
            {
                tree.Add(number);
            }

            //var range = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => int.Parse(x))
            //    .ToArray();

            //var start = range[0];
            //var end = range[1];

            //tree.Range(start, end);

            Console.WriteLine(tree[6]);
        }
    }
}
