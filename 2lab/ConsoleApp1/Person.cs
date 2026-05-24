using System;

public class Person : INameAndCopy
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public DateTime BirthDate { get; set; }

    public Person()
    {
        BirthDate = DateTime.Now;
    }

    public Person(string name, string surname, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Person p) return false;

        return Name == p.Name &&
               Surname == p.Surname &&
               BirthDate == p.BirthDate;
    }

    public static bool operator ==(Person a, Person b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Person a, Person b) => !(a == b);

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Surname, BirthDate);
    }

    public object DeepCopy()
    {
        return new Person(Name, Surname, BirthDate);
    }

    public override string ToString()
    {
        return $"{Name} {Surname}, {BirthDate.ToShortDateString()}";
    }
}