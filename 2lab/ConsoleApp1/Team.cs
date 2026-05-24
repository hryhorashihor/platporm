using System;

public class Team : INameAndCopy
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

    public override bool Equals(object? obj)
    {
        if (obj is not Team t) return false;

        return Name == t.Name &&
               RegistrationNumber == t.RegistrationNumber;
    }

    public static bool operator ==(Team a, Team b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Team a, Team b) => !(a == b);

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, RegistrationNumber);
    }

    public override string ToString()
    {
        return $"{Name}, Reg#: {RegistrationNumber}";
    }
}