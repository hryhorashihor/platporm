public class Team : INameAndCopy
{
    public string Name { get; set; }

    public string Organization { get; set; }

    public int RegistrationNumber
    {
        get;
        set;
    }

    public Team()
    {
        Name = "";
        Organization = "";
        RegistrationNumber = 0;
    }

    public Team(
        string name,
        string organization,
        int reg
    )
    {
        Name = name;
        Organization = organization;
        RegistrationNumber = reg;
    }

    public object DeepCopy()
    {
        return new Team(
            Name,
            Organization,
            RegistrationNumber
        );
    }
}