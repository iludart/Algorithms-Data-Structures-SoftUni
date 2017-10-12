using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.PathsBetweenCellsInMatrix
{
    class PathsBetweenCells
    {
        static char[,] matrix = new char[,]
        {
            { 's', ' ', ' ', ' ', ' ', ' ', },
            { ' ', '*', '*', ' ', '*', ' ', },
            { ' ', '*', '*', ' ', '*', ' ', },
            { ' ', '*', 'e', ' ', ' ', ' ', },
            { ' ', ' ', ' ', '*', ' ', ' ', },
        };

        static Stack<char> path = new Stack<char>();
        static int count = 0;

        static void Main(string[] args)
        {
            FindPath(0, 0, 'S');
            Console.WriteLine("Total paths found: " + count);
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (!IsValidCell(row, col))
            {
                return;
            }
            
            if (matrix[row, col] == '*' || matrix[row, col] == '.')
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                path.Push(direction);
                PrintPath();
                path.Pop();
                count++;
                return;
            }

            matrix[row, col] = '.';
            path.Push(direction);

            FindPath(row, col - 1, 'L');
            FindPath(row - 1, col, 'U');
            FindPath(row, col + 1, 'R');
            FindPath(row + 1, col, 'D');

            matrix[row, col] = ' ';
            path.Pop();
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Reverse().Skip(1)));
        }

        private static bool IsValidCell(int row, int col)
        {
            return
                !(row < 0 ||
                row >= matrix.GetLength(0) ||
                col < 0 ||
                col >= matrix.GetLength(1));
        }
    }
}
