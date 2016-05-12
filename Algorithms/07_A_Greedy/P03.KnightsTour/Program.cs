using System;
using System.Collections.Generic;

class KnightsTour
{
    private static readonly int[] Directions = { 1, 2, -1, 2, 2, 1, 1, -2, -1, -2, -2, 1, 2, -1, -2, -1 };

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] board = new int[size, size];
        int boardArea = size * size;
        int startRow = 0;
        int startCol = 0;
        int movesCount = 1;

        while (boardArea > 0)
        {
            var posiblePositions = CalcAllPosiblePositions(startRow, startCol, board);
            Tuple<int, int> bestPosition = new Tuple<int, int>(0, 0);
            int minMovesCount = int.MaxValue;

            foreach (var position in posiblePositions)
            {
                int posibleMovesCount =
                CalcAllPosiblePositions(position.Item1, position.Item2, board).Count;
                if (posibleMovesCount < minMovesCount)
                {
                    minMovesCount = posibleMovesCount;
                    bestPosition = new Tuple<int, int>(position.Item1, position.Item2);
                }
            }

            board[startRow, startCol] = movesCount++;
            boardArea--;
            startRow = bestPosition.Item1;
            startCol = bestPosition.Item2;
        }

        PrintBoard(board);
    }

    private static List<Tuple<int, int>> CalcAllPosiblePositions(int row, int col, int[,] board)
    {
        var result = new List<Tuple<int, int>>();
        for (int i = 0; i < Directions.Length; i += 2)
        {
            int currRow = row + Directions[i];
            int currCol = col + Directions[i + 1];
            if (IsInBounds(currRow, currCol, board.GetLength(0)) && board[currRow, currCol] == 0)
            {
                result.Add(new Tuple<int, int>(currRow, currCol));
            }
        }

        return result;
    }

    private static bool IsInBounds(int row, int col, int size)
    {
        return !(row >= size || col >= size || row < 0 || col < 0);
    }

    private static void PrintBoard(int[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}