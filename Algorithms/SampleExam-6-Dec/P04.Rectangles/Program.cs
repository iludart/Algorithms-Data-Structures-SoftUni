using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Rectangles
{
    class Rectangle : IComparable<Rectangle>
    {
        public Rectangle(string name, int x1, int y1, int x2, int y2)
        {
            this.Name = name;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public string Name { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int MaxDepth { get; set; }
        public Rectangle BestNested { get; set; }

        public int CompareTo(Rectangle other)
        {
            int result = this.MaxDepth.CompareTo(other.MaxDepth);
            if (result == 0)
            {
                result = -this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Program
    {
        static List<Rectangle> rectangles;

        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            rectangles = new List<Rectangle>();

            while (!command.Equals("End"))
            {
                var tokens = command.Split();
                var name = tokens[0].Substring(0, tokens[0].Length - 1);
                var x1 = int.Parse(tokens[1].Trim());
                var y1 = int.Parse(tokens[2].Trim());
                var x2 = int.Parse(tokens[3].Trim());
                var y2 = int.Parse(tokens[4].Trim());

                var rectangle = new Rectangle(name, x1, y1, x2, y2);
                rectangles.Add(rectangle);
                command = Console.ReadLine();
            }

            foreach (var rect in rectangles)
            {
                if (rect.MaxDepth == 0)
                {
                    GetDepth(rect);
                }
            }

            var maxRect = rectangles.Max();
            var output = new List<Rectangle>();
            while (maxRect != null)
            {
                output.Add(maxRect);
                maxRect = maxRect.BestNested;
            }

            Console.WriteLine(string.Join(" < ", output));
        }

        private static void GetDepth(Rectangle rect)
        {
            var innerRectangles = new List<Rectangle>();

            foreach (var innerCandidate in rectangles)
            {
                if (IsInside(innerCandidate, rect) && innerCandidate != rect)
                {
                    if (innerCandidate.MaxDepth == 0)
                    {
                        GetDepth(innerCandidate);
                    }
                    
                    innerRectangles.Add(innerCandidate);
                }
            }

            if (innerRectangles.Count == 0)
            {
                rect.MaxDepth = 1;
            }
            else
            {
                var bestNested = innerRectangles.Max();
                rect.BestNested = bestNested;
                rect.MaxDepth = bestNested.MaxDepth + 1;
            }
        }

        private static bool IsInside(Rectangle innerRect, Rectangle rect)
        {
            return innerRect.X1 >= rect.X1
                && innerRect.X2 <= rect.X2
                && innerRect.Y1 <= rect.Y1
                && innerRect.Y2 >= rect.Y2;
        }
    }
}
