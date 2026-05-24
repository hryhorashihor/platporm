using System;

class Program
{
    static void Main()
    {
        ResearchTeamCollection c1 =
            new("First");

        ResearchTeamCollection c2 =
            new("Second");

        TeamsJournal j1 =
            new();

        TeamsJournal j2 =
            new();

        c1.ResearchTeamAdded +=
            j1.Handler;

        c1.ResearchTeamInserted +=
            j1.Handler;

        c1.ResearchTeamAdded +=
            j2.Handler;

        c1.ResearchTeamInserted +=
            j2.Handler;

        c2.ResearchTeamAdded +=
            j2.Handler;

        c2.ResearchTeamInserted +=
            j2.Handler;

        c1.AddDefaults();

        c1.AddResearchTeams(
            new ResearchTeam()
        );

        c2.AddDefaults();

        c1.InsertAt(
            0,
            new ResearchTeam()
        );

        c1.InsertAt(
            20,
            new ResearchTeam()
        );

        c2.InsertAt(
            5,
            new ResearchTeam()
        );

        Console.WriteLine(
            "Journal 1"
        );

        Console.WriteLine(j1);

        Console.WriteLine(
            "Journal 2"
        );

        Console.WriteLine(j2);
    }
}