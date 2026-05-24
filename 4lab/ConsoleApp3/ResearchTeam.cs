using System;
using System.Collections.Generic;
using System.Linq;

public class ResearchTeam : Team, IComparer<ResearchTeam>
{
    private string topic = "";
    private TimeFrame timeFrame;

    private List<Person> members = new();
    private List<Paper> papers = new();

    public string Topic
    {
        get => topic;
        set => topic = value;
    }

    public TimeFrame TimeFrame
    {
        get => timeFrame;
        set => timeFrame = value;
    }

    public List<Person> Members => members;
    public List<Paper> Publications => papers;

    public Team BaseTeam => new Team(Name, RegistrationNumber);

    public Paper? LatestPaper
    {
        get
        {
            if (papers.Count == 0)
                return null;

            return papers.MaxBy(p => p.PublishDate);
        }
    }

    public ResearchTeam() { }

    public ResearchTeam(string topic, string org, int reg, TimeFrame tf)
        : base(org, reg)
    {
        this.topic = topic;
        timeFrame = tf;
    }

    public void AddPapers(params Paper[] p)
    {
        papers.AddRange(p);
    }

    public void AddMembers(params Person[] p)
    {
        members.AddRange(p);
    }

    public override object DeepCopy()
    {
        ResearchTeam copy =
            new ResearchTeam(topic, Name, RegistrationNumber, timeFrame);

        foreach (var m in members)
            copy.members.Add((Person)m.DeepCopy());

        foreach (var p in papers)
            copy.papers.Add((Paper)p.DeepCopy());

        return copy;
    }

    public int Compare(ResearchTeam? x, ResearchTeam? y)
    {
        return string.Compare(x?.Topic, y?.Topic);
    }

    public override string ToString()
    {
        string result =
            $"{base.ToString()}\nTopic: {Topic}\nTimeFrame: {TimeFrame}\n";

        result += "Members:\n";

        foreach (var m in members)
            result += m + "\n";

        result += "Papers:\n";

        foreach (var p in papers)
            result += p + "\n";

        return result;
    }

    public string ToShortString()
    {
        return
            $"{base.ToString()}, Topic: {Topic}, TimeFrame: {TimeFrame}, Members: {members.Count}, Papers: {papers.Count}";
    }
}