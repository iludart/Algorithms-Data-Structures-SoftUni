using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ReverseArray
{
    class ReverseArray
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ');

            arr = Reverse(arr, 0);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static string[] Reverse(string[] arr, int index)
        {
            if (index >= arr.Length / 2)
            {
                return arr;
            }

            var temp = arr[index];
            arr[index] = arr[arr.Length - index - 1];
            arr[arr.Length - index - 1] = temp;

            return Reverse(arr, index + 1);
        }
    }
}
