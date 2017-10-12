namespace P03.CalculateArithmeticExpression
{
    public class Token
    {
        public Token(string value, TokenType type)
        {
            this.Value = value;
            this.Type = type;
        }

        public string Value { get; set; }

        public TokenType Type { get; set; }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
