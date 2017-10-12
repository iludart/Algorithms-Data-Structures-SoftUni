using System;

namespace P06.ReversedList
{
    public class ReversedListProgram
    {
        public static void Main()
        {
            ReversedList<int> reversedList = new ReversedList<int> {0, 1, 2, 3};
            
            reversedList.Remove(0);

            foreach (var item in reversedList)
            {
                Console.Write(item + " ");
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine("Count: " + reversedList.Count);
            Console.WriteLine("Capacity: " + reversedList.Capacity);

            while (reversedList.Count <= 16)
            {
                reversedList.Add(5);
            }

            Console.WriteLine("Count: " + reversedList.Count);
            Console.WriteLine("Capacity: " + reversedList.Capacity);
        }
    }
}
