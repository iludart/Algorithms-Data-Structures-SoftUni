namespace P09.SequenceNM
{
    using System;
    using System.Collections.Generic;

    class Item
    {
        public Item(int value, Item prevItem = null)
        {
            this.Value = value;
            this.PrevItem = prevItem;
        }

        public int Value { get; set; }

        public Item PrevItem { get; set; }
    }

    class SequenceNM
    {
        static void Main()
        {
            int n = 3;
            int m = 10;

            var queue = new Queue<Item>();
            queue.Enqueue(new Item(n));

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.Value < m)
                {
                    queue.Enqueue(new Item(element.Value + 1, element));
                    queue.Enqueue(new Item(element.Value + 2, element));
                    queue.Enqueue(new Item(element.Value * 2, element));
                }

                if (element.Value == m)
                {
                    PrintSolution(element);
                    break;
                }
            }
        }

        private static void PrintSolution(Item item)
        {
            var result = new Stack<int>();

            while (item != null)
            {
                result.Push(item.Value);
                item = item.PrevItem;
            }

            Console.WriteLine(string.Join(" -> ", result));
        }
    }
}
