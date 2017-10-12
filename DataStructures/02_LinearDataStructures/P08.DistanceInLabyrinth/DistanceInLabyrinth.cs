namespace P08.DistanceInLabyrinth
{
    using System;

    public class DistanceInLabyrinth
    {
        private const string MatrixEnterCellToken = "*";
        private const string UnstepableCellToken = "x";
        private const string UnreachableCellToken = "u";

        private static int count = 0;
        private static string[,] matrix = new string[6, 6]
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"},
        };

        public static void Main()
        {
            //ReadLabyrinth();

            int[] startCoordinates = FindStartCoordinates();

            if (startCoordinates[0] == 0)
            {
                Console.WriteLine("Enter cell not found.");
            }
            else
            {
                int row = startCoordinates[1];
                int col = startCoordinates[2];

                RecursiveCall(row, col);
                MarkUnreachableCells();
                PrintMatrix();
            }
        }

        private static void ReadLabyrinth()
        {
            matrix = null;

            int row = 0;
            int matrixSize = 0;

            string commandLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(commandLine))
            {
                string[] cmdParams = commandLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                
                if (matrix == null)
                {
                    matrixSize = cmdParams.Length;
                    matrix = new string[matrixSize, matrixSize];
                }

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = cmdParams[col];
                }

                commandLine = Console.ReadLine();
                row++;
            }
        }

        private static int[] FindStartCoordinates()
        {
            int[] startCoordinates = new int[3];
            bool foundStart = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(MatrixEnterCellToken))
                    {
                        foundStart = true;
                        startCoordinates[1] = row;
                        startCoordinates[2] = col;
                        break;
                    }
                }
            }

            if (foundStart)
            {
                startCoordinates[0] = 1;
            }

            return startCoordinates;
        }

        private static void RecursiveCall(int row, int col)
        {
            MarkNeighboringCells(row, col);

            if (ValidateCell(row, col + 1))
            {
                count++;
                RecursiveCall(row, col + 1);
                count--;
            }

            if (ValidateCell(row + 1, col))
            {
                count++;
                RecursiveCall(row + 1, col);
                count--;
            }

            if (ValidateCell(row, col - 1))
            {
                count++;
                RecursiveCall(row, col - 1);
                count--;
            }

            if (ValidateCell(row - 1, col))
            {
                count++;
                RecursiveCall(row - 1, col);
                count--;
            }
        }

        private static void MarkUnreachableCells()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals("0"))
                    {
                        matrix[row, col] = UnreachableCellToken;
                    }
                }
            }
        }
        
        private static void MarkNeighboringCells(int row, int col)
        {
            bool isRightFree = ValidateCell(row, col + 1);
            bool isDownFree = ValidateCell(row + 1, col);
            bool isLeftFree = ValidateCell(row, col - 1);
            bool isUpFree = ValidateCell(row - 1, col);

            if (isRightFree)
            {
                int rightCellValue = int.Parse(matrix[row, col + 1]);
                bool toMarkRightCell = rightCellValue == 0 || rightCellValue > count + 1;
                if (toMarkRightCell)
                {
                    matrix[row, col + 1] = (count + 1).ToString();
                }
            }

            if (isDownFree)
            {
                int downCellValue = int.Parse(matrix[row + 1, col]);
                bool toMarkDownCell = downCellValue == 0 || downCellValue > count + 1;
                if (toMarkDownCell)
                {
                    matrix[row + 1, col] = (count + 1).ToString();
                }
            }

            if (isLeftFree)
            {
                int leftCellValue = int.Parse(matrix[row, col - 1]);
                bool toMarkDownCell = leftCellValue == 0 || leftCellValue > count + 1;
                if (toMarkDownCell)
                {
                    matrix[row, col - 1] = (count + 1).ToString();
                }
            }

            if (isUpFree)
            {
                int upCellValue = int.Parse(matrix[row - 1, col]);
                bool toMarkUoCell = upCellValue == 0 || upCellValue > count + 1;
                if (toMarkUoCell)
                {
                    matrix[row - 1, col] = (count + 1).ToString();
                }
            }
        }

        private static bool ValidateCell(int row, int col)
        {
            bool isValidRow = row >= 0 && row < matrix.GetLength(0);
            bool isValidCol = col >= 0 && col < matrix.GetLength(1);
            bool isValidCount = false;

            if (isValidRow && isValidCol)
            {
                if (!matrix[row, col].Equals(UnstepableCellToken) && !matrix[row, col].Equals(MatrixEnterCellToken))
                {
                    int cellValue = int.Parse(matrix[row, col]);
                    isValidCount = (cellValue == 0 || cellValue >= count + 1);
                }
            }

            return isValidRow && isValidCol && isValidCount;
        }

        private static void PrintMatrix()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c].PadLeft(3));
                }

                Console.WriteLine();
            }
        }
    }
}
