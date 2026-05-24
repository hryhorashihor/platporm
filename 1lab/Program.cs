using System;

class Program
{
    static void Main()
    {
        ResearchTeam team = new ResearchTeam(
            "AI Research",
            "OpenAI",
            101,
            TimeFrame.TwoYears
        );

        Console.WriteLine("SHORT INFO:");
        Console.WriteLine(team.ToShortString());

        Console.WriteLine("\nINDEXER TEST:");
        Console.WriteLine(team[TimeFrame.Year]);
        Console.WriteLine(team[TimeFrame.TwoYears]);
        Console.WriteLine(team[TimeFrame.Long]);

        Paper p1 = new Paper(
            "Machine Learning",
            new Person("John", "Smith", new DateTime(1990, 5, 10)),
            new DateTime(2024, 1, 15)
        );

        Paper p2 = new Paper(
            "Neural Networks",
            new Person("Anna", "Brown", new DateTime(1988, 3, 20)),
            new DateTime(2023, 6, 5)
        );

        team.AddPapers(p1, p2);

        Console.WriteLine("\nFULL INFO:");
        Console.WriteLine(team);

        Console.WriteLine("\nLATEST PAPER:");
        Console.WriteLine(team.LatestPaper);

        CompareArrays();
    }

    static void CompareArrays()
    {
        int nRows = 100;
        int nColumns = 100;

        int total = nRows * nColumns;

        Paper[] oneDim = new Paper[total];

        Paper[,] twoDim = new Paper[nRows, nColumns];

        Paper[][] jagged = new Paper[nRows][];

        for (int i = 0; i < nRows; i++)
        {
            jagged[i] = new Paper[nColumns];
        }

        Paper sample = new Paper();

        int start, end;

        start = Environment.TickCount;

        for (int i = 0; i < total; i++)
        {
            oneDim[i] = sample;
        }

        end = Environment.TickCount;

        Console.WriteLine($"\nOne-dimensional array: {end - start} ms");

        start = Environment.TickCount;

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                twoDim[i, j] = sample;
            }
        }

        end = Environment.TickCount;

        Console.WriteLine($"Two-dimensional array: {end - start} ms");

        start = Environment.TickCount;

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                jagged[i][j] = sample;
            }
        }

        end = Environment.TickCount;

        Console.WriteLine($"Jagged array: {end - start} ms");
    }
}