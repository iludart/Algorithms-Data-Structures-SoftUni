namespace P03.TreeIndexing
{
    using P01.AvlTree;
    using System;
    using System.Linq;

    class TreeIndexing
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

            var command = Console.ReadLine();
            while (!string.IsNullOrEmpty(command))
            {
                try
                {
                    var index = int.Parse(command);
                    Console.WriteLine(tree[index]);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
