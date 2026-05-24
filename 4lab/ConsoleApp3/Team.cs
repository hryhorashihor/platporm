using System;

public class Team : INameAndCopy, IComparable<Team>
{
    protected string organizationName = "";
    protected int registrationNumber;

    public string Name
    {
        get => organizationName;
        set => organizationName = value;
    }

    public int RegistrationNumber
    {
        get => registrationNumber;
        set
        {
            if (value <= 0)
                throw new Exception("Registration number must be > 0");

            registrationNumber = value;
        }
    }

    public Team() { }

    public Team(string name, int reg)
    {
        Name = name;
        RegistrationNumber = reg;
    }

    public virtual object DeepCopy()
    {
        return new Team(Name, RegistrationNumber);
    }

    public int CompareTo(Team? other)
    {
        if (other == null) return 1;
        return RegistrationNumber.CompareTo(other.RegistrationNumber);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Team t) return false;

        return Name == t.Name &&
               RegistrationNumber == t.RegistrationNumber;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, RegistrationNumber);
    }

    public override string ToString()
    {
        return $"{Name}, Reg#: {RegistrationNumber}";
    }
}