using System;

public class Person : IComparable<Person>
{
    public Person(string email, string name, int age, string town)
    {
        this.Email = email;
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }
    public string Domain
    {
        get
        {
            var index = this.Email.IndexOf('@');
            return this.Email.Substring(index + 1).Trim();
        }
    }

    public int CompareTo(Person other)
    {
        return this.Email.CompareTo(other.Email);
    }
}
