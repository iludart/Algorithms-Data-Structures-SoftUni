using System;
using System.Collections.Generic;

namespace P01.ShortestPathInMatrix
{
    public class Cell
    {
        public Cell (int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public List<Cell> AdjacentCells { get; set; }

        public override string ToString()
        {
            return this.Row + " " + this.Col; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new int[rows, cols];
            var graph = new Dictionary<Cell, List<Cell>>();
            var edges

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var currentCell = new Cell(r, c);
                    if (IsInsideMatrix(r, c + 1, rows, cols))
                    {

                    }
                }
            }
        }

        private static bool IsInsideMatrix(int r, int c, int rows, int cols)
        {
            return r >= 0
                && r < rows
                && c >= 0
                && c < cols;
        }
    }
}
