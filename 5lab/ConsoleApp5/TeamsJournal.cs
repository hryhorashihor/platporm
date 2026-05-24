using System.Collections.Generic;
using System.Text;

public class TeamsJournal
{
    private List<TeamsJournalEntry>
        entries = new();

    public void Handler(
        object source,
        TeamListHandlerEventArgs args
    )
    {
        entries.Add(
            new TeamsJournalEntry(
                args.CollectionName,
                args.ChangeType,
                args.Index
            )
        );
    }

    public override string ToString()
    {
        StringBuilder sb =
            new();

        foreach (var item in entries)
        {
            sb.AppendLine(
                item.ToString()
            );
        }

        return sb.ToString();
    }
}