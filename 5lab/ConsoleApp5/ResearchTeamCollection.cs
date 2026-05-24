using System.Collections.Generic;

public class ResearchTeamCollection
{
    public string CollectionName
    {
        get;
        set;
    }

    private List<ResearchTeam>
        researchTeams =
            new();

    public event TeamListHandler?
        ResearchTeamAdded;

    public event TeamListHandler?
        ResearchTeamInserted;

    public ResearchTeamCollection(
        string name
    )
    {
        CollectionName = name;
    }

    public void AddDefaults()
    {
        researchTeams.Add(
            new ResearchTeam()
        );

        ResearchTeamAdded?.Invoke(
            this,
            new TeamListHandlerEventArgs(
                CollectionName,
                "Added",
                researchTeams.Count - 1
            )
        );
    }

    public void AddResearchTeams(
        params ResearchTeam[] teams
    )
    {
        foreach (var team in teams)
        {
            researchTeams.Add(team);

            ResearchTeamAdded?.Invoke(
                this,
                new TeamListHandlerEventArgs(
                    CollectionName,
                    "Added",
                    researchTeams.Count - 1
                )
            );
        }
    }

    public void InsertAt(
        int j,
        ResearchTeam team
    )
    {
        if (
            j >= 0 &&
            j < researchTeams.Count
        )
        {
            researchTeams.Insert(
                j,
                team
            );

            ResearchTeamInserted
                ?.Invoke(
                    this,
                    new TeamListHandlerEventArgs(
                        CollectionName,
                        "Inserted",
                        j
                    )
                );
        }
        else
        {
            researchTeams.Add(team);

            ResearchTeamAdded
                ?.Invoke(
                    this,
                    new TeamListHandlerEventArgs(
                        CollectionName,
                        "Added",
                        researchTeams.Count - 1
                    )
                );
        }
    }
}   