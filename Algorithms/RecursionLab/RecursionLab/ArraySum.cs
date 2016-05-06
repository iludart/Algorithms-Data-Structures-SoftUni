using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionLab
{
    public class ArraySum
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {-1, -3};
            Console.WriteLine(FindSum(array, 0));
        }

        static int FindSum(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            return array[index] + FindSum(array, index + 1);
        }
    }
}
