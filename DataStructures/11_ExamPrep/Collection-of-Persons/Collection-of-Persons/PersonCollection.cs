using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = 
        new Dictionary<string, Person>();

    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = 
        new Dictionary<string, SortedSet<Person>>();

    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = 
        new Dictionary<string, SortedSet<Person>>();

    private OrderedDictionary<int, SortedSet<Person>> personsByAge = 
        new OrderedDictionary<int, SortedSet<Person>>();

    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public PersonCollection()
    {
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person(email, name, age, town);

        // add by email
        this.personsByEmail.Add(email, person);

        // add by domain
        var domain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(domain, person);

        // add by name and town
        var nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        // add by age
        this.personsByAge.AppendValueToKey(age, person);

        // add by age and town
        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        Person person;
        this.personsByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if (person == null)
        {
            return false;
        }

        // delete by email
        var personDeleted = this.personsByEmail.Remove(email);

        // delete by domain
        var domain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[domain].Remove(person);

        // delete by name and town
        var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        // delete by age
        this.personsByAge[person.Age].Remove(person);

        // delete by age and town
        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var personsByDomain = this.personsByEmailDomain.GetValuesForKey(emailDomain);
        return personsByDomain;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        var persons = this.personsByNameAndTown.GetValuesForKey(nameAndTown);
        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var ageRange in personsInRange)
        {
            foreach (var person in ageRange.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var personsInTown = this.personsByTownAndAge[town];
        var personsInAgeRange = personsInTown.Range(startAge, true, endAge, true);
        foreach (var certainAge in personsInAgeRange)
        {
            foreach (var person in certainAge.Value)
            {
                yield return person;
            }
        }
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];
        return domain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        return name + "|!|" +town;
    }
}
