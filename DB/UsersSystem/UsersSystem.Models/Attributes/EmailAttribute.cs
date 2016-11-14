namespace UsersSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property)]
    class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pattern = @"^[a-zA-Z0-9]+[a-zA-Z0-9-_.]*[a-zA-Z0-9]+@[\w]+(\.[\w]+)+$";

            if (value == null)
            {
                return false;
            }

            Match match = Regex.Match(value.ToString(), pattern);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }
    }
}
