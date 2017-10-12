namespace P02.StringEditor
{
    using System.Linq;
    using System.Text;

    public class CommandHandler
    {
        private Data data;

        public CommandHandler(Data data)
        {
            this.data = data;    
        }

        public string Execute(Command command)
        {
            var index = 0;
            var count = 0;
            string[] parameters;
            string text;
            var output = false;
            switch (command.Name)
            {
                case "APPEND":
                    output = Append(command.Params);
                    return output ? "OK" : "ERROR";
                case "INSERT":
                    parameters = command.Params.Split(' ');
                    index = int.Parse(parameters[0]);
                    text = string.Join(" ", parameters.Skip(1));
                    output = this.Insert(index, text);
                    return output ? "OK" : "ERROR";
                case "DELETE":
                    parameters = command.Params.Split(' ');
                    index = int.Parse(parameters[0]);
                    count = int.Parse(parameters[1]);
                    output = this.Delete(index, count);
                    return output ? "OK" : "ERROR";
                case "REPLACE":
                    parameters = command.Params.Split(' ');
                    index = int.Parse(parameters[0]);
                    count = int.Parse(parameters[1]);
                    text = string.Join(" ", parameters.Skip(2));
                    output = this.Replace(index, count, text);
                    return output ? "OK" : "ERROR";
                case "PRINT":
                    return this.Print();
                case "END":
                    return string.Empty;
                default:
                    return "Unknown command";
            }
        }

        private string Print()
        {
            var sb = new StringBuilder();
            foreach (var ch in this.data.Text)
            {
                sb.Append(ch);
            }

            return sb.ToString();
        }

        private bool Replace(int index, int count, string replacementString)
        {
            var output = this.Delete(index, count);
            if (output)
            {
                this.Insert(index, replacementString);
            }

            return output;
        }

        private bool Append(string text)
        {
            foreach (var ch in text)
            {
                this.data.Text.Add(ch);
            }

            return true;
        }

        private bool Insert(int index, string text)
        {
            if (index < 0 || index >= this.data.Text.Count)
            {
                return false;
            }

            this.data.Text.InsertRange(index, text.ToCharArray());
            return true;
        }

        private bool Delete(int index, int count)
        {
            if (index < 0 || index >= this.data.Text.Count)
            {
                return false;
            }

            if (index + count > this.data.Text.Count)
            {
                count = this.data.Text.Count - index;
            }

            this.data.Text.RemoveRange(index, count);
            return true;
        }
    }
}
