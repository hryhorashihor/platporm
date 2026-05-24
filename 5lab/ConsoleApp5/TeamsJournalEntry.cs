public class TeamsJournalEntry
{
    public string CollectionName
    {
        get;
        set;
    }

    public string ChangeType
    {
        get;
        set;
    }

    public int Index
    {
        get;
        set;
    }

    public TeamsJournalEntry(
        string collectionName,
        string changeType,
        int index
    )
    {
        CollectionName =
            collectionName;

        ChangeType =
            changeType;

        Index = index;
    }

    public override string ToString()
    {
        return
            $"Collection: {CollectionName}, " +
            $"Event: {ChangeType}, " +
            $"Index: {Index}";
    }
}