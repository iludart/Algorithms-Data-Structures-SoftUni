using System;
using System.Linq;

namespace P02.Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var start = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());
            var currentMax = start;

            var matrix = InitializeMatrix(songs.Length + 1, max  + 1);

            matrix[0, start] = start;

            for (int row = 0; row < songs.Length; row++)
            {
                var currentValue = songs[row];
                for (int col = 0; col <= max; col++)
                {
                    if (matrix[row, col] != - 1)
                    {
                        var newIncrement = matrix[row, col] + currentValue;
                        var newDecrement = matrix[row, col] - currentValue;

                        if (newIncrement <= max)
                        {
                            matrix[row + 1, newIncrement] = newIncrement;
                        }

                        if (newDecrement >= 0)
                        {
                            matrix[row + 1, newDecrement] = newDecrement;
                        }
                    }
                }
            }

            var result = GetMax(matrix);
            Console.WriteLine(result);
        }

        private static int GetMax(int[,] matrix)
        {
            var lastRow = matrix.GetLength(0) - 1;
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                if (matrix[lastRow, col] != -1)
                {
                    return matrix[lastRow, col];
                }
            }

            return -1;
        }

        static int[,] InitializeMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = -1;
                }
            }

            return matrix;
        }
    }
}
