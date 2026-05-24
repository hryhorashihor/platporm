using System;

class Person
{
    private string name = "";
    private string surname = "";
    private DateTime birthDate;

    public string Name
    {
        get { return name; }
        init { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        init { surname = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        init { birthDate = value; }
    }

    public int BirthYear
    {
        get { return birthDate.Year; }
        set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
    }

    public Person(string name, string surname, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
    }

    public Person()
    {
        Name = "Unknown";
        Surname = "Unknown";
        BirthDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}, Birth date: {BirthDate.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"{Surname} {Name}";
    }
}