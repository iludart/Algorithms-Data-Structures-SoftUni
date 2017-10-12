using System;

namespace P05.OrderedSet_AVLTree_
{
    public class Program
    {
        static void Main()
        {
            var set = new OrderedSet<int>();
            set.Add(1);
            set.Add(3);
            set.Add(-1);
            set.Add(-5);
            set.Add(-10);
            set.Add(100);

            foreach (var num in set)
            {
                Console.WriteLine(num);
            }
        }
    }
}
