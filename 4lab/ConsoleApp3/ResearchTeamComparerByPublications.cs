using System.Collections.Generic;

public class ResearchTeamComparerByPublications :
    IComparer<ResearchTeam>
{
    public int Compare(
        ResearchTeam? x,
        ResearchTeam? y)
    {
        return x!.Publications.Count
            .CompareTo(y!.Publications.Count);
    }
}
