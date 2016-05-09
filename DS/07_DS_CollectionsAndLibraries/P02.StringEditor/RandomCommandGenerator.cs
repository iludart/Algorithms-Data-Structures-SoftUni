using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.StringEditor
{
    public class RandomCommandGenerator
    {
        private readonly Random rnd;

        private readonly string[] commands = new string[]
        {
            "APPEND pesho",
            "APPEND gosho",
            "APPEND 123",
            "APPEND 345",
            "APPEND ;@#$",
            "APPEND ,,. 12  3534",
            "INSERT 0 456",
            "INSERT 100 3123",
            "INSERT 10 dfhg 34 5g",
            "INSERT 0 SDFDS#$@#",
            "INSERT 5 456",
            "INSERT 0 435231",
            "DELETE 1 10",
            "DELETE 1 200",
            "DELETE 1 300",
            "DELETE 1 400",
            "DELETE 1 500",
            "REPLACE 1 5 kiro",
            "REPLACE 10 50 fasdfasd",
            "REPLACE 20 100 asdf",
            "PRINT"
        };

        public RandomCommandGenerator()
        {
            this.rnd = new Random();
        }

        public string GetCommand()
        {
            return (commands[rnd.Next(commands.Length)]);
        }
    }
}
