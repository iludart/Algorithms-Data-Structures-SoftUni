namespace UsersSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordAttribute : ValidationAttribute
    {
        private readonly int minLength;
        private readonly int maxLength;

        public PasswordAttribute(int minLength = 0, int maxLength = 30)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public bool ShouldContainLowercase { get; set; }

        public bool ShouldContainUppercase { get; set; }

        public bool ShouldContainDigit { get; set; }

        public bool ShouldContainSpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            if (value.ToString().Length <= 0)
            {
                return false;
            }

            if (value.ToString().Length < this.minLength && value.ToString().Length > this.maxLength)
            {
                return false;
            }

            if (this.ShouldContainLowercase && !this.ContainsLowercase(value.ToString()))
            {
                return false;
            }

            if (this.ShouldContainUppercase && !this.ContainsUppercase(value.ToString()))
            {
                return false;
            }

            if (this.ShouldContainDigit && !this.ContainsDigit(value.ToString()))
            {
                return false;
            }

            if (this.ShouldContainSpecialSymbol && !this.ContainsSpecialSymbol(value.ToString()))
            {
                return false;
            }

            return true;
        }

        private bool ContainsSpecialSymbol(string value)
        {
            char[] specialSymbols = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };
            foreach (var c in value)
            {
                if (specialSymbols.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsDigit(string value)
        {
            if (value.Count(char.IsDigit) == 0)
            {
                return false;
            }

            return true;
        }

        private bool ContainsUppercase(string value)
        {
            if (value.Count(char.IsUpper) == 0)
            {
                return false;
            }

            return true;
        }

        private bool ContainsLowercase(string value)
        {
            if (value.Count(char.IsLower) == 0)
            {
                return false;
            }

            return true;
        }
    }
}
