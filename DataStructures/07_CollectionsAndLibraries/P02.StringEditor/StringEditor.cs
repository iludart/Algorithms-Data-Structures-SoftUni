using System;

namespace P02.StringEditor
{
    public class StringEditor
    {
        private Data data;
        private Command command;
        private CommandHandler commandHandler;

        public StringEditor()
        {
            this.data = new Data();
            this.commandHandler = new CommandHandler(data);
        }

        public void Run()
        {
            while (true)
            {
                var commandLine = Console.ReadLine();
                command = new Command(commandLine);

                var output = commandHandler.Execute(command);

                Console.WriteLine(output);

                if (command.Name.Equals("END"))
                {
                    break;
                }
            }
        }
    }
}
