using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    class Program
    {
        static void Main(string[] args)
        {
            var skipList = new SkipList<int>();
            skipList.Add(2);
            skipList.Add(3);
            skipList.Add(4);
            skipList.Add(5);
            skipList.Add(6);

            skipList.Remove(2);
            Console.WriteLine(skipList.Count);
            Console.WriteLine(skipList.ElementAt(0));
        }
    }
}
