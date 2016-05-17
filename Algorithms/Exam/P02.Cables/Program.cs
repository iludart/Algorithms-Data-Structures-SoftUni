using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Cables
{
    class Program
    {
        static int[] prices = new int[] { 3, 8, 13, 15, 18, 20, 22 };
        static int[] newPrices;
        static int connectorPrice = 1;

        static void Main(string[] args)
        {
            prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            connectorPrice = int.Parse(Console.ReadLine());

            newPrices = new int[prices.Length];

            for (int i = 0; i < newPrices.Length; i++)
            {
                newPrices[i] = CutRod(i);
            }

            Console.WriteLine(string.Join(" ", newPrices));
        }

        private static int CutRod(int n)
        {
            if (n == -1)
            {
                return 0;
            }

            if (newPrices[n] > 0)
            {
                return newPrices[n];
            }

            var optimal = prices[n];

            for (int i = 0; i < n; i++)
            {
                var newPrice = prices[i] + CutRod(n - i - 1) - (2 * connectorPrice);
                optimal = Math.Max(optimal, newPrice);
            }

            return optimal;
        }
    }
}
