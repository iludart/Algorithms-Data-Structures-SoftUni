using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueenProblem
{
    public class ChessMaster2000
    {
        const int Size = 8;
        static bool[,] board = new bool[Size, Size];
        static int solutionsFound = 0;
        
        static bool[] attackedCols = new bool[Size];
        static bool[] attackedLeftDiagonals = new bool[(Size * 2) - 1];
        static bool[] attackedRightDiagonals = new bool[(Size * 2) - 1];

        static void Main(string[] args)
        {
            PutQueen(0);
            Console.WriteLine(solutionsFound);
        }

        static void PutQueen(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPutQueen(row, col))
                    {
                        MarkAttackedPositions(row, col);
                        PutQueen(row + 1);
                        UnmarkAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    char ch = board[row, col] == true ? '*' : '-';
                    Console.Write(ch);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            solutionsFound++;
        }

        private static void UnmarkAttackedPositions(int row, int col)
        {
            attackedCols[col] = false;
            attackedLeftDiagonals[Size + (col - row) - 1] = false;
            attackedRightDiagonals[col + row] = false;
            board[row, col] = false;
        }

        private static void MarkAttackedPositions(int row, int col)
        {
            attackedCols[col] = true;
            attackedLeftDiagonals[Size + (col - row) - 1] = true;
            attackedRightDiagonals[col + row] = true;
            board[row, col] = true;
        }

        private static bool CanPutQueen(int row, int col)
        {
            var positionOccupied =
                attackedCols[col] ||
                attackedLeftDiagonals[Size + (col - row) - 1] ||
                attackedRightDiagonals[col + row];

            return !positionOccupied;
        }
    }
}
