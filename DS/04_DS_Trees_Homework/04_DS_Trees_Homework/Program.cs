namespace _04_DS_Trees_Homework
{
    using System;

    public class Program
    {
        static void Main()
        {
            var tree = 
                new Tree<int>(4, 
                    new Tree<int>(2, 
                        new Tree<int>(3),
                        new Tree<int>(2)),
                    new Tree<int>(7),
                    new Tree<int>(3));

            Console.WriteLine();
        }
    }
}
