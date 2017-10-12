namespace P03.RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public class RideTheHorse
    {
        private static int[,] matrix = new int[6, 7];

        static void Main()
        {
            ReadMatrix();
            var initCell = ReadInitialCell();

            FillMatrixBFS(initCell);
            WriteOutput();
        }

        private static void WriteOutput()
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            for (int row = 0; row < height; row++)
            {
                Console.WriteLine(matrix[row, width / 2]);
            }
        }

        private static Cell ReadInitialCell()
        {
            var rowStartPos = int.Parse(Console.ReadLine());
            var colStartPos = int.Parse(Console.ReadLine());

            return new Cell {Row = rowStartPos, Col = colStartPos, MoveCount = 1};
        }

        private static void FillMatrixBFS(Cell initCell)
        {
            var queue = new Queue<Cell>();
            queue.Enqueue(initCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                if (IsValidCell(cell))
                {
                    matrix[cell.Row, cell.Col] = cell.MoveCount;

                    queue.Enqueue(new Cell { Row = cell.Row - 1, Col = cell.Col - 2, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row - 2, Col = cell.Col - 1, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row - 2, Col = cell.Col + 1, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row - 1, Col = cell.Col + 2, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row + 1, Col = cell.Col + 2, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row + 2, Col = cell.Col + 1, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row + 2, Col = cell.Col - 1, MoveCount = cell.MoveCount + 1 });
                    queue.Enqueue(new Cell { Row = cell.Row + 1, Col = cell.Col - 2, MoveCount = cell.MoveCount + 1 });
                }
            }
        }

        private static bool IsValidCell(Cell cell)
        {
            bool isRowValid = cell.Row >= 0 && cell.Row < matrix.GetLength(0);
            bool isColValid = cell.Col >= 0 && cell.Col < matrix.GetLength(1);
            return isRowValid && isColValid && matrix[cell.Row, cell.Col] == 0;
        }

        private static void ReadMatrix()
        {
            var rowCount = int.Parse(Console.ReadLine());
            var colCount = int.Parse(Console.ReadLine());

            matrix = new int[rowCount, colCount];
        }

        private static void WriteMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(2));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public class Cell
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int MoveCount { get; set; }
        }
    }
}
