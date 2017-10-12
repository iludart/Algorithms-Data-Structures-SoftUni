using System;

namespace P00.RodCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = new int[] { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            var n = 5;

            int optimal = CutRod(prices, n);
            Console.WriteLine(optimal);
        }

        private static int CutRod(int[] prices, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            var optimal = -1;

            for (int i = 1; i <= n; i++)
            {
                optimal = Math.Max(optimal, prices[i] + CutRod(prices, n - i));
            }

            return optimal;
        }
    }
}
