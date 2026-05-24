using System;

public class Paper
{
    public string Title { get; set; }

    public Person Author { get; set; }

    public DateTime PublishDate { get; set; }

    public Paper()
    {
        Title = "";
        Author = new Person();
        PublishDate = DateTime.MinValue;
    }

    public Paper(string title, Person author, DateTime publishDate)
    {
        Title = title;
        Author = author;
        PublishDate = publishDate;
    }

    public object DeepCopy()
    {
        return new Paper(
            Title,
            (Person)Author.DeepCopy(),
            PublishDate
        );
    }

    public override string ToString()
    {
        return $"{Title}, {Author}, {PublishDate.ToShortDateString()}";
    }
}