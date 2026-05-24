using System;

class ResearchTeam
{
    private string researchTopic = "";
    private string organizationName = "";
    private int registrationNumber;
    private TimeFrame researchDuration;
    private Paper[] publications = Array.Empty<Paper>();

    public string ResearchTopic
    {
        get { return researchTopic; }
        init { researchTopic = value; }
    }

    public string OrganizationName
    {
        get { return organizationName; }
        init { organizationName = value; }
    }

    public int RegistrationNumber
    {
        get { return registrationNumber; }
        init { registrationNumber = value; }
    }

    public TimeFrame ResearchDuration
    {
        get { return researchDuration; }
        init { researchDuration = value; }
    }

    public Paper[] Publications
    {
        get { return publications; }
        init { publications = value; }
    }

    public ResearchTeam(string topic, string org, int regNum, TimeFrame duration)
    {
        ResearchTopic = topic;
        OrganizationName = org;
        RegistrationNumber = regNum;
        ResearchDuration = duration;
        Publications = Array.Empty<Paper>();
    }

    public ResearchTeam()
    {
        ResearchTopic = "Unknown";
        OrganizationName = "Unknown";
        RegistrationNumber = 0;
        ResearchDuration = TimeFrame.Year;
        Publications = Array.Empty<Paper>();
    }

    public Paper? LatestPaper
    {
        get
        {
            if (publications.Length == 0)
                return null;

            return publications[^1];
        }
    }

    public bool this[TimeFrame timeFrame]
    {
        get
        {
            return researchDuration == timeFrame;
        }
    }

    public void AddPapers(params Paper[] papers)
    {
        int oldLength = publications.Length;

        Array.Resize(ref publications, oldLength + papers.Length);

        for (int i = 0; i < papers.Length; i++)
        {
            publications[oldLength + i] = papers[i];
        }
    }

    public override string ToString()
    {
        string result =
            $"Topic: {ResearchTopic}\n" +
            $"Organization: {OrganizationName}\n" +
            $"Registration Number: {RegistrationNumber}\n" +
            $"Duration: {ResearchDuration}\n";

        foreach (Paper paper in publications)
        {
            result += paper + "\n";
        }

        return result;
    }

    public virtual string ToShortString()
    {
        return
            $"Topic: {ResearchTopic}, " +
            $"Organization: {OrganizationName}, " +
            $"Registration Number: {RegistrationNumber}, " +
            $"Duration: {ResearchDuration}";
    }
}