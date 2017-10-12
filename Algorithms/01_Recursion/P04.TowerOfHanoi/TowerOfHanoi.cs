using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.TowerOfHanoi
{
    class TowerOfHanoi
    {
        static Stack<int> source = new Stack<int>(Enumerable.Range(1, 3).Reverse());
        static Stack<int> spare = new Stack<int>();
        static Stack<int> destination = new Stack<int>();

        static void Main()
        {
            PrintRods();
            MoveDisks(source.Count, source, spare, destination);
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: " + string.Join(", ", source.Reverse()));
            Console.WriteLine("Spare: " + string.Join(", ", spare.Reverse()));
            Console.WriteLine("Destination: " + string.Join(", ", destination.Reverse()));
            Console.WriteLine();
        }

        static void MoveDisks(int bottomDisk, Stack<int> sourceRod, Stack<int> spareRod, Stack<int> destinationRod)
        {
            if (bottomDisk == 1)
            {
                destinationRod.Push(sourceRod.Pop());
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, sourceRod, destinationRod, spareRod);
                destinationRod.Push(sourceRod.Pop());
                PrintRods();
                MoveDisks(bottomDisk - 1, spareRod, sourceRod, destinationRod);
            }
        }
    }
}
