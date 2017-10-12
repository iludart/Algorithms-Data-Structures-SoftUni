using System;

namespace P03.Phonebook
{
    using P01.Dictionary;

    public class Phonebook
    {
        static void Main()
        {
            var phonebook = new CustomDictionary<string, string>();
            var command = Console.ReadLine();

            while (true)
            {
                if (command == "search")
                {
                    command = ExecuteSearchLoop(phonebook);
                }

                if (string.IsNullOrEmpty(command))
                {
                    break;
                }
                else
                {
                    AddEntry(command, phonebook);
                }

                command = Console.ReadLine();
            }

            
        }

        private static string ExecuteSearchLoop(CustomDictionary<string, string> phonebook)
        {
            var command = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(command))
                {
                    return command;
                }

                if (phonebook.ContainsKey(command))
                {
                    var contactNumber = phonebook[command];
                    Console.WriteLine("{0} -> {1}", command, contactNumber);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", command);
                }

                command = Console.ReadLine();
            }
        }

        private static void AddEntry(string command, CustomDictionary<string, string> phonebook)
        {
            var entry = command.Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);

            var contactName = entry[0];
            var contactNumber = entry[1];
            phonebook[contactName] = contactNumber;
        }
    }
}
