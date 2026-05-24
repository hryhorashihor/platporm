using System.Collections.Generic;

public class ResearchTeam : Team
{
    public string Topic { get; set; }

    public TimeFrame Duration
    {
        get;
        set;
    }

    private List<Person> members =
        new();

    private List<Paper> papers =
        new();

    public ResearchTeam()
    {
        Topic = "Default";
        Duration = TimeFrame.Year;
    }

    public override string ToString()
    {
        return
            $"{Topic}, " +
            $"{Duration}";
    }
}