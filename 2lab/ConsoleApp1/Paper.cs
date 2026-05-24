using System;

public class Paper : INameAndCopy
{
    public string Title { get; set; } = "";
    public Person Author { get; set; } = new Person();
    public DateTime PublishDate { get; set; }

    public string Name
    {
        get => Title;
        set => Title = value;
    }

    public Paper()
    {
        PublishDate = DateTime.Now;
    }

    public Paper(string title, Person author, DateTime publishDate)
    {
        Title = title;
        Author = author;
        PublishDate = publishDate;
    }

    public virtual object DeepCopy()
    {
        return new Paper(Title, (Person)Author.DeepCopy(), PublishDate);
    }

    public override string ToString()
    {
        return $"{Title} - {Author} ({PublishDate.ToShortDateString()})";
    }
}