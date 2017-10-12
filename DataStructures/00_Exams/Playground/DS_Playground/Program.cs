namespace DS_Playground
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(3);
            list.Add(2);

            var item = list.BinarySearch(0);
            Console.WriteLine(item);
        }
    }
}
