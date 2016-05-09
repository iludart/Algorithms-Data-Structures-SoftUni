using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P01.Dictionary
{
    public class DictionaryProgram
    {
        public static void Main()
        {
            var dict = new Dictionary<int, int>();
            dict.Add(1, 1);
            var r = dict.Remove(1);
            Console.WriteLine(r);
        }
    }
}
