using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.BiDictionary
{
    public class Program
    {
        public static void Main()
        {
            var distances = new BiDictionary<string, string, int>();
            distances.Add("Sofia", "Varna", 443);
            distances.Add("Sofia", "Varna", 468);
            distances.Add("Sofia", "Varna", 490);
            distances.Add("Sofia", "Plovdiv", 145);
            distances.Add("Sofia", "Bourgas", 383);
            distances.Add("Plovdiv", "Bourgas", 253);
            distances.Add("Plovdiv", "Bourgas", 292);
            Console.WriteLine("[{0}]", string.Join(", ", distances.FindByKey1("Sofia"))); // [443, 468, 490, 145, 383]
            Console.WriteLine("[{0}]", string.Join(", ", distances.FindByKey2("Bourgas"))); // [383, 253, 292]
            Console.WriteLine("[{0}]", string.Join(", ", distances.Find("Plovdiv", "Bourgas"))); // [253, 292]
            Console.WriteLine("[{0}]", string.Join(", ", distances.Find("Rousse", "Varna"))); // []
            Console.WriteLine("[{0}]", string.Join(", ", distances.Find("Sofia", "Varna"))); // [443, 468, 490]
            bool b = distances.Remove("Sofia", "Varna"); // true
            Console.WriteLine("[{0}]", string.Join(", ", distances.FindByKey1("Sofia"))); // [145, 383]
            Console.WriteLine("[{0}]", string.Join(", ", distances.FindByKey2("Varna"))); // []
            Console.WriteLine("[{0}]", string.Join(", ", distances.Find("Sofia", "Varna"))); // []
        }
    }
}
