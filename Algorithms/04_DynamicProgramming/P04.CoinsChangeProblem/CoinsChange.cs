using System;
using System.Linq;

namespace P04.CoinsChangeProblem
{
    class CoinsChange
    {
        static void Main()
        {
            var s = ReadSum();
            var coins = ReadCoins();

            int[,] matrix = FindCoinsChangeSolutions(s, coins);
            
            Console.WriteLine(matrix[coins.Length, s]);
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

        private static int[,] FindCoinsChangeSolutions(int n, int[] coins)
        {
            int[,] matrix = new int[coins.Length + 1, n + 1];

            for (int i = 0; i <= coins.Length; i++)
            {
                matrix[i, 0] = 1;
            }

            for (int i = 1; i <= n; i++)
            {
                matrix[0, i] = 0;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        var currentCoin = coins[i - 1];
                        matrix[i, j] = matrix[i, j - currentCoin] + matrix[i - 1, j];
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }

            return matrix;
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
