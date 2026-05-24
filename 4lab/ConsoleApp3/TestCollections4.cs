using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

public class TestCollections4
{
    private List<Team> list = new();

    private ImmutableList<Team> immutableList =
        ImmutableList<Team>.Empty;

    private SortedList<string, Team> sortedList =
        new();

    private SortedDictionary<string, Team> sortedDictionary =
        new();

    public TestCollections4(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Team team = new Team();
            
            team.Name = $"Team{i}";

            list.Add(team);

            immutableList =
                immutableList.Add(team);

            sortedList.Add(team.Name, team);

            sortedDictionary.Add(team.Name, team);
        }
    }

    public void MeasureSearch()
    {
        Team first = list[0];
        Team middle = list[list.Count / 2];
        Team last = list[list.Count - 1];

        Console.WriteLine("=== LIST ===");
        SearchList(first, "First");
        SearchList(middle, "Middle");
        SearchList(last, "Last");

        Console.WriteLine();

        Console.WriteLine("=== IMMUTABLE LIST ===");
        SearchImmutable(first, "First");
        SearchImmutable(middle, "Middle");
        SearchImmutable(last, "Last");

        Console.WriteLine();

        Console.WriteLine("=== SORTED LIST ===");
        SearchSortedList(first.Name);

        Console.WriteLine();

        Console.WriteLine("=== SORTED DICTIONARY ===");
        SearchSortedDictionary(first.Name);
    }

    private void SearchList(Team team, string label)
    {
        Stopwatch sw = Stopwatch.StartNew();

        list.Contains(team);

        sw.Stop();

        Console.WriteLine(
            $"{label}: {sw.ElapsedTicks} ticks"
        );
    }

    private void SearchImmutable(
        Team team,
        string label
    )
    {
        Stopwatch sw = Stopwatch.StartNew();

        immutableList.Contains(team);

        sw.Stop();

        Console.WriteLine(
            $"{label}: {sw.ElapsedTicks} ticks"
        );
    }

    private void SearchSortedList(string key)
    {
        Stopwatch sw = Stopwatch.StartNew();

        sortedList.ContainsKey(key);

        sw.Stop();

        Console.WriteLine(
            $"Key search: {sw.ElapsedTicks} ticks"
        );
    }

    private void SearchSortedDictionary(
        string key
    )
    {
        Stopwatch sw = Stopwatch.StartNew();

        sortedDictionary.ContainsKey(key);

        sw.Stop();

        Console.WriteLine(
            $"Key search: {sw.ElapsedTicks} ticks"
        );
    }
}