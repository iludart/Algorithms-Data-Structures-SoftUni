using System;
using System.Collections.Generic;
using System.Text;

namespace P06.Snakes
{
    class Program
    {
        static List<char> snake = new List<char>();
        static HashSet<string> variations = new HashSet<string>();
        static int maxLength = 2;
        static bool[,] shape = new bool[2 * maxLength + 1, 2 * maxLength + 1];

        static int row = maxLength;
        static int col = maxLength;

        static void Main(string[] args)
        {
            GenSnakes('S', 0);
        }

        private static void GenSnakes(char direction, int index)
        {
            if (index >= maxLength)
            {
                var newSnake = new string(snake.ToArray());
                if (!variations.Contains(newSnake))
                {
                    AddSnakes(snake);
                    Console.WriteLine(newSnake);
                }

                return;
            }

            shape[row, col] = true;
            snake.Add(direction);

            if (direction != 'L' && !shape[row, col + 1])
            {
                col++;
                GenSnakes('R', index + 1);
                col--;
            }

            if (direction != 'U' && !shape[row - 1, col])
            {
                row--;
                GenSnakes('D', index + 1);
                row++;
            }

            if (direction != 'R' && !shape[row, col - 1])
            {
                col--;
                GenSnakes('L', index + 1);
                col++;
            }

            if (direction != 'D' && !shape[row + 1, col])
            {
                row++;
                GenSnakes('U', index + 1);
                row--;
            }

            shape[row, col] = false;
            snake.RemoveAt(snake.Count - 1);
        }

        private static void AddSnakes(List<char> directions)
        {
            FlipSnake(directions);
            variations.Add(new string(directions.ToArray()));

            //SwitchSnakeHeadAndTail(directions);
            //directions.Reverse();
            while (directions[1] != 'R')
            {
                RotateSnakeClockwise(directions);
                variations.Add(new string(directions.ToArray()));
            }

            variations.Add(new string(directions.ToArray()));

            FlipSnake(directions);
            variations.Add(new string(directions.ToArray()));
        }

        private static void RotateSnakeClockwise(List<char> directions)
        {
            for (int index = 0; index < directions.Count; index++)
            {
                switch (directions[index])
                {
                    case 'U':
                        directions[index] = 'R';
                        break;
                    case 'D':
                        directions[index] = 'L';
                        break;
                    case 'R':
                        directions[index] = 'D';
                        break;
                    case 'L':
                        directions[index] = 'U';
                        break;
                }
            }
        }

        private static void FlipSnake(List<char> directions)
        {
            for (int index = 0; index < directions.Count; index++)
            {
                switch (directions[index])
                {
                    case 'U':
                        directions[index] = 'D';
                        break;
                    case 'D':
                        directions[index] = 'U';
                        break;
                }
            }
        }

        private static void SwitchSnakeHeadAndTail(List<char> directions)
        {
            char tmp = directions[0];
            directions.RemoveAt(0);
            directions.Add(tmp);

            for (int index = 0; index < directions.Count; index++)
            {
                switch (directions[index])
                {
                    case 'U':
                        directions[index] = 'D';
                        break;
                    case 'D':
                        directions[index] = 'U';
                        break;
                    case 'R':
                        directions[index] = 'L';
                        break;
                    case 'L':
                        directions[index] = 'R';
                        break;
                }
            }
        }
    }
}
