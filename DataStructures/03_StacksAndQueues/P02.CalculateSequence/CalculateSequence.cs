namespace P02.CalculateSequence
{
    using System;
    using System.Collections.Generic;

    internal class CalculateSequence
    {
        static void Main()
        {
            int n;
            bool isValidNumber = int.TryParse(Console.ReadLine(), out n);

            if (isValidNumber)
            {
                var queue = new Queue<int>();
                queue.Enqueue(n);

                var result = new List<int>(50);

                var index = 0;
                while (index < 50)
                {
                    n = queue.Peek();

                    queue.Enqueue(n + 1);
                    queue.Enqueue(2*n + 1);
                    queue.Enqueue(n + 2);

                    result.Add(queue.Dequeue());
                    index++;
                }

                Console.WriteLine(string.Join(", ", result));
            }
        }
    }
}
