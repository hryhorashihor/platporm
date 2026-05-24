using System;
using System.Collections;
using System.Collections.Generic;

public class ResearchTeam : Team
{
    private string topic = "";
    private TimeFrame timeFrame;

    private ArrayList members = new();
    private ArrayList papers = new();

    public string Topic
    {
        get => topic;
        set => topic = value;
    }

    public ArrayList Members => members;
    public ArrayList Publications => papers;

    public Paper? LatestPaper
    {
        get
        {
            if (papers.Count == 0) return null;
            return (Paper)papers[^1];
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
        foreach (var item in p)
            papers.Add(item);
    }

    public void AddMembers(params Person[] p)
    {
        foreach (var item in p)
            members.Add(item);
    }

    public override string ToString()
    {
        string res = base.ToString() + $"\nTopic: {topic}\n";

        res += "Members:\n";
        foreach (Person p in members)
            res += p + "\n";

        res += "Papers:\n";
        foreach (Paper p in papers)
            res += p + "\n";

        return res;
    }

    public string ToShortString()
    {
        return $"{base.ToString()}, Topic: {topic}, TimeFrame: {timeFrame}";
    }

    public override object DeepCopy()
    {
        ResearchTeam copy = new ResearchTeam(topic, Name, RegistrationNumber, timeFrame);

        foreach (Person p in members)
            copy.members.Add((Person)p.DeepCopy());

        foreach (Paper p in papers)
            copy.papers.Add((Paper)p.DeepCopy());

        return copy;
    }

    // 👤 без публікацій
    public IEnumerable PersonsWithoutPublications()
    {
        foreach (Person p in members)
        {
            bool has = false;

            foreach (Paper paper in papers)
            {
                if (paper.Author == p)
                {
                    has = true;
                    break;
                }
            }

            if (!has)
                yield return p;
        }
    }

    // 📄 за N років
    public IEnumerable PapersLastYears(int n)
    {
        int year = DateTime.Now.Year;

        foreach (Paper p in papers)
        {
            if (year - p.PublishDate.Year <= n)
                yield return p;
        }
    }

    // 👥 з публікаціями
    public IEnumerable PersonsWithPublications()
    {
        foreach (Person p in members)
        {
            foreach (Paper paper in papers)
            {
                if (paper.Author == p)
                {
                    yield return p;
                    break;
                }
            }
        }
    }
}