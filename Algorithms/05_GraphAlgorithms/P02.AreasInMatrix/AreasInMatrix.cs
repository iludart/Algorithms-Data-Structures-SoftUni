using System;
using System.Collections.Generic;

namespace P02.AreasInMatrix
{
    class AreasInMatrix
    {
        static char[][] matrix;
        static int areasCount = 0;
        static Dictionary<char, int> areasCountByChar;
        static bool[][] visited;

        static void Main()
        {
            var numberOfRows = 6;
            matrix = new char[numberOfRows][];
            areasCountByChar = new Dictionary<char, int>();
            visited = new bool[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                var line = Console.ReadLine().Trim();
                matrix[i] = line.ToCharArray();
                visited[i] = new bool[line.Length];
            }
            
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row][col])
                    {
                        areasCount++;

                        if (!areasCountByChar.ContainsKey(matrix[row][col]))
                        {
                            areasCountByChar.Add(matrix[row][col], 0);
                        }

                        areasCountByChar[matrix[row][col]] += 1;
                        DFSArea(matrix[row][col], row, col);
                    }
                }
            }

            Console.WriteLine("Areas: {0}", areasCount);
            foreach (var area in areasCountByChar)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }
        }

        private static void DFSArea(char ch, int row, int col)
        {
            if (IsInsideMatrix(row, col))
            {
                var currentChar = matrix[row][col];

                if (currentChar == ch && !visited[row][col])
                {
                    visited[row][col] = true;

                    DFSArea(matrix[row][col], row - 1, col);
                    DFSArea(matrix[row][col], row, col + 1);
                    DFSArea(matrix[row][col], row + 1, col);
                    DFSArea(matrix[row][col], row, col - 1);
                }
            }

            return;
        }

        private static bool IsInsideMatrix(int row, int col)
        {
            bool isValid = 
                (row >= 0 && row < matrix.Length) 
                && (col >= 0 && col < matrix[row].Length);

            return isValid;
        }
    }
}
