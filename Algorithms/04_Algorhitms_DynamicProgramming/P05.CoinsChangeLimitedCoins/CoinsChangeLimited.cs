using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.CoinsChangeLimitedCoins
{
    class CoinsChangeLimited
    {
        static void Main()
        {
            var s = ReadSum();
            var coins = ReadCoins();

            Array.Sort(coins);

            var solutions = GenerateSolutions(s, coins);

            Console.WriteLine(solutions);
        }

        private static int GenerateSolutions(int s, int[] coins)
        {
            var matrix = new int[coins.Length, s + 1];
            var solutions = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i >= coins[0])
                {
                    matrix[0, i] = coins[0];
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                    var coinValue = coins[i];

                    if (coinValue <= j)
                    {
                        matrix[i, j] = coins[i] + matrix[i - 1, j - coinValue];
                    }

                    if (matrix[i, j] == s)
                    {
                        solutions++;
                    }
                }
            }

            return solutions;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[] ReadCoins()
        {
            var line = Console.ReadLine();
            var startIndex = line.IndexOf('{');
            var numbers = line.Substring(startIndex);
            var coins = numbers.Substring(1, numbers.Length - 2).Trim();
            var result = coins.Split(',').Select(x => int.Parse(x)).ToArray();
            return result;
        }

        private static int ReadSum()
        {
            var line = Console.ReadLine();
            var startIndex = line.IndexOf('=');
            var num = line.Substring(startIndex + 1).Trim();
            var result = int.Parse(num);
            return result;
        }
    }
}
