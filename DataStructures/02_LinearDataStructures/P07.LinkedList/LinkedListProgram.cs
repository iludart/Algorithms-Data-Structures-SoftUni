namespace P07.LinkedList
{
    using System;

    public class LinkedListProgram
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(0);
            linkedList.Add(0);
            linkedList.Add(0);

            Console.WriteLine(linkedList.LastIndexOf(0));
        }
    }
}
