using System.Collections.Generic;
using System.Linq;

public class ResearchTeamCollection
{
    private List<ResearchTeam> teams = new();

    public void AddDefaults()
    {
        AddResearchTeams(
            new ResearchTeam("AI", "OpenAI", 10, TimeFrame.TwoYears),
            new ResearchTeam("Math", "Uni", 5, TimeFrame.Year)
        );
    }

    public void AddResearchTeams(
        params ResearchTeam[] items)
    {
        teams.AddRange(items);
    }

    public void SortByRegistration()
    {
        teams.Sort();
    }

    public void SortByTopic()
    {
        teams.Sort(new ResearchTeam());
    }

    public void SortByPublications()
    {
        teams.Sort(
            new ResearchTeamComparerByPublications());
    }

    public int MinRegistrationNumber
    {
        get
        {
            if (teams.Count == 0)
                return 0;

            return teams.Min(t => t.RegistrationNumber);
        }
    }

    public IEnumerable<ResearchTeam> TwoYearsTeams
    {
        get
        {
            return teams.Where(
                t => t.TimeFrame == TimeFrame.TwoYears);
        }
    }

    public List<ResearchTeam> NGroup(int value)
    {
        return teams
            .Where(t => t.Members.Count == value)
            .ToList();
    }

    public override string ToString()
    {
        return string.Join("\n", teams);
    }

    public string ToShortString()
    {
        return string.Join(
            "\n",
            teams.Select(t => t.ToShortString()));
    }
}