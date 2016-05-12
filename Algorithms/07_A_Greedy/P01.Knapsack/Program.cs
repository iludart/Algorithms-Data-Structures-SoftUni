using System;

class FractionalKnapsackProblem
{
    static void Main()
    {
        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        Console.Write("Items: ");
        int itemsCount = int.Parse(Console.ReadLine());
        var items = new dynamic[itemsCount];

        for (int i = 0; i < itemsCount; i++)
        {
            var currentLine = Console.ReadLine()
                    .Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            items[i] = new
            {
                Price = double.Parse(currentLine[0]),
                Weight = double.Parse(currentLine[1])
            };
        }

        Array.Sort(items, (a, b) =>
            (b.Price / b.Weight).CompareTo(a.Price / a.Weight));

        double totalPrice = 0;
        int index = 0;
        while (capacity >= 0)
        {
            capacity -= items[index].Weight;

            double precents = 1d;
            if (capacity < 0)
            {
                precents = ((capacity + items[index].Weight) / (items[index].Weight));
            }
            totalPrice += precents * items[index].Price;
            Console.WriteLine("Take {0:F2}% of item with price {1:F2} and weight {2:F2}",
                precents * 100, items[index].Price, items[index].Weight);

            index++;
        }

        Console.WriteLine("Total price: {0:F2}", totalPrice);
    }
}