﻿namespace P04.OrderedSet
{
    using System;

    public class Program
    {
        static void Main()
        {
            var set = new OrderedSet<int>();

            set.Add(17);
            set.Add(9);
            //set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);

            var numberToRemove = 17;
            set.Remove(numberToRemove);

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
