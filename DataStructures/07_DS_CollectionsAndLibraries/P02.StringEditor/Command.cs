namespace P02.StringEditor
{
    public class Command
    {
        public Command(string input)
        {
            this.Name = this.GetName(input);
            this.Params = this.GetParameters(input);
        }

        public string Name { get; set; }

        public string Params { get; set; }

        private string GetName(string input)
        {
            var separatorIndex = input.IndexOf(' ');
            if (separatorIndex < 0)
            {
                return input.Substring(0);
            }

            return input.Substring(0, separatorIndex);
        }

        private string GetParameters(string input)
        {
            var separatorIndex = input.IndexOf(' ');
            if (separatorIndex == -1)
            {
                return string.Empty;
            }

            return input.Substring(separatorIndex + 1);
        }
    }
}
