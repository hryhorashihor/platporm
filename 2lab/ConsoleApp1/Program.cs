using System;

class Program
{
    static void Main()
    {
        Team t1 = new Team("OpenAI", 1);
        Team t2 = new Team("OpenAI", 1);

        Console.WriteLine(t1 == t2);
        Console.WriteLine(t1.GetHashCode());
        Console.WriteLine(t2.GetHashCode());

        try
        {
            t1.RegistrationNumber = -5;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        ResearchTeam rt = new ResearchTeam("AI", "OpenAI", 10, TimeFrame.TwoYears);

        Person p1 = new Person("John", "Smith", new DateTime(1990, 1, 1));
        Person p2 = new Person("Anna", "Brown", new DateTime(1995, 1, 1));

        rt.AddMembers(p1, p2);

        rt.AddPapers(
            new Paper("ML", p1, DateTime.Now),
            new Paper("DL", p1, DateTime.Now)
        );

        Console.WriteLine(rt);

        var copy = (ResearchTeam)rt.DeepCopy();

        rt.Topic = "CHANGED";

        Console.WriteLine(copy.Topic);

        foreach (Person p in rt.PersonsWithoutPublications())
            Console.WriteLine(p);

        foreach (Paper p in rt.PapersLastYears(2))
            Console.WriteLine(p);
    }
}