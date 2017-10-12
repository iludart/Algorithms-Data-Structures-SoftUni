using System;
using System.Linq;
using System.Text;

namespace P01.Medenka
{
    class Program
    {
        static StringBuilder vector = new StringBuilder();
        static int[] numbers = new int[] { 1, 0, 1, 0, 1 };
        static int count = 0;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Generate(0);
        }

        private static void Generate(int index)
        {
            var number = numbers[index];

            if (index == numbers.Length - 1)
            {
                if (count == 1)
                {
                    return;
                }

                vector.Append(number);
                Console.WriteLine(vector);
                vector.Remove(vector.Length - 1, 1);
                return;
            }

            if (number == 1 && count == 1)
            {
                return;
            }

            vector.Append(number);

            if (number == 1)
            {
                vector.Append('|');
                Generate(index + 1);

                vector.Remove(vector.Length - 1, 1);
                count = 1;
                Generate(index + 1);
            }
            else
            {
                if (count == 1)
                {
                    vector.Append('|');
                    count = 0;
                    Generate(index + 1);
                    vector.Remove(vector.Length - 1, 1);

                    count = 1;
                    Generate(index + 1);
                }
                else
                {
                    Generate(index + 1);
                }
            }

            vector.Remove(vector.Length - 1, 1);
        }
    }
}
