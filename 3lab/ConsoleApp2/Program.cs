using System;

class Program
{
    static void Main()
    {
        ResearchTeamCollection col =
            new ResearchTeamCollection();

        col.AddDefaults();

        Console.WriteLine("START");
        Console.WriteLine(col);

        Console.WriteLine("\nSORT REG");
        col.SortByRegistration();
        Console.WriteLine(col);

        Console.WriteLine("\nSORT TOPIC");
        col.SortByTopic();
        Console.WriteLine(col);

        Console.WriteLine("\nSORT PAPERS");
        col.SortByPublications();
        Console.WriteLine(col);

        Console.WriteLine(
            "\nMin reg: " +
            col.MinRegistrationNumber);

        Console.WriteLine("\nTwoYears");

        foreach (var t in col.TwoYearsTeams)
            Console.WriteLine(t.ToShortString());

        Console.WriteLine("\nEnter collection size:");

        int count;

        while (!int.TryParse(
            Console.ReadLine(),
            out count))
        {
            Console.WriteLine(
                "Wrong input. Try again:");
        }

        TestCollections tc =
            new TestCollections(count);

        Console.WriteLine("\nFIRST");
        tc.Search(0);

        Console.WriteLine("\nMIDDLE");
        tc.Search(count / 2);

        Console.WriteLine("\nLAST");
        tc.Search(count - 1);

        Console.WriteLine("\nNOT FOUND");
        tc.Search(count + 100);
    }
}