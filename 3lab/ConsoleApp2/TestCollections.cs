using System;
using System.Collections.Generic;
using System.Diagnostics;

public class TestCollections
{
    private List<Team> listTeam = new();
    private List<string> listString = new();

    private Dictionary<Team, ResearchTeam> dictTeam =
        new();

    private Dictionary<string, ResearchTeam> dictString =
        new();

    public static ResearchTeam Generate(int i)
    {
        return new ResearchTeam(
            $"Topic {i}",
            $"Org {i}",
            i + 1,
            TimeFrame.TwoYears);
    }

    public TestCollections(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ResearchTeam rt = Generate(i);

            Team t = rt.BaseTeam;

            listTeam.Add(t);

            listString.Add(t.ToString());

            dictTeam.Add(t, rt);

            dictString.Add(t.ToString(), rt);
        }
    }

    public void Search(int i)
    {
        ResearchTeam rt = Generate(i);

        Team t = rt.BaseTeam;

        Stopwatch sw = new();

        sw.Start();
        listTeam.Contains(t);
        sw.Stop();

        Console.WriteLine(
            $"List<Team>: {sw.ElapsedTicks}");

        sw.Restart();
        listString.Contains(t.ToString());
        sw.Stop();

        Console.WriteLine(
            $"List<string>: {sw.ElapsedTicks}");

        sw.Restart();
        dictTeam.ContainsKey(t);
        sw.Stop();

        Console.WriteLine(
            $"Dict key: {sw.ElapsedTicks}");

        sw.Restart();
        dictString.ContainsKey(t.ToString());
        sw.Stop();

        Console.WriteLine(
            $"Dict string key: {sw.ElapsedTicks}");

        sw.Restart();
        dictTeam.ContainsValue(rt);
        sw.Stop();

        Console.WriteLine(
            $"Dict value: {sw.ElapsedTicks}");
    }
}