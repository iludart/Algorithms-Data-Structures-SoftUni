namespace P02.StringEditor
{
    using Wintellect.PowerCollections;

    public class Data
    {
        private BigList<char> text;

        public Data()
        {
            this.text = new BigList<char>();
        }

        public BigList<char> Text { get { return this.text; } }
    }
}
