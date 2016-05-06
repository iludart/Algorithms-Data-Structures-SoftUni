using System;
using System.Collections.Generic;

namespace P07.ConnectedAreasInMatrix
{
    class ConnectedAreasInMatrix
    {
        static char[,] matrix = new char[,]
        {
            {'*', ' ', ' ',  '*', ' ', ' ', ' ', '*', ' ', ' ',},
            {'*', ' ', ' ',  '*', ' ', ' ', ' ', '*', ' ', ' ',},
            {'*', ' ', ' ',  '*', '*', '*', '*', '*', ' ', ' ',},
            {'*', ' ', ' ',  '*', ' ', ' ', ' ', '*', ' ', ' ',},
            {'*', ' ', ' ',  '*', ' ', ' ', ' ', '*', ' ', ' ',},
        };

        static SortedSet<Area> areas = new SortedSet<Area>();

        static void Main()
        {
            var startRow = 0;
            var startCol = 0;
            var hasFreeCell = false;

            do
            {
                hasFreeCell = false;
                
                // get area starting cell
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == ' ')
                        {
                            hasFreeCell = true;
                            startRow = row;
                            startCol = col;
                            break;
                        }
                    }

                    if (hasFreeCell)
                    {
                        break;
                    }
                }

                // get area size
                if (hasFreeCell)
                {
                    var newArea = new Area() { StartRow = startRow, StartCol = startCol };

                    GetAreaSize(startRow, startCol, newArea);

                    areas.Add(newArea);
                }
            }
            while (hasFreeCell);

            PrintResult();
        }

        private static void PrintResult()
        {
            var count = 1;

            Console.WriteLine("Total areas found: {0}", areas.Count);
            foreach (var area in areas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", count, area.StartRow, area.StartCol, area.Size);
                count++;
            }
        }

        private static void GetAreaSize(int row, int col, Area area)
        {
            if (!IsInsideMatrix(row, col))
            {
                return;
            }

            if (!IsFreeCell(row, col))
            {
                return;
            }

            matrix[row, col] = '.';
            area.Size++;

            GetAreaSize(row, col + 1, area);
            GetAreaSize(row + 1, col, area);
            GetAreaSize(row, col - 1, area);
            GetAreaSize(row - 1, col, area);
        }

        private static bool IsFreeCell(int row, int col)
        {
            return matrix[row, col] == ' ';
        }

        private static bool IsInsideMatrix(int row, int col)
        {
            return !(row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1));
        }
    }

    class Area : IComparable<Area>
    {
        public Area()
        { }

        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            var result = -this.Size.CompareTo(other.Size);

            if (result == 0)
            {
                result = this.StartRow.CompareTo(other.StartRow);
            }

            if (result == 0)
            {
                result = this.StartCol.CompareTo(other.StartCol);
            }

            return result;
        }
    }
}
