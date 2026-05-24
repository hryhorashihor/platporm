using System;

public class Person
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime BirthDate { get; set; }

    public Person()
    {
        Name = "";
        Surname = "";
        BirthDate = DateTime.MinValue;
    }

    public Person(
        string name,
        string surname,
        DateTime birthDate
    )
    {
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
    }

    public object DeepCopy()
    {
        return new Person(
            Name,
            Surname,
            BirthDate
        );
    }

    public override string ToString()
    {
        return
            $"{Name} {Surname}, " +
            $"{BirthDate.ToShortDateString()}";
    }
}