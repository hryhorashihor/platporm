using System;

class Paper
{
    public string Title { get; set; }
    public Person Author { get; set; }
    public DateTime PublishDate { get; set; }

    public Paper(string title, Person author, DateTime publishDate)
    {
        Title = title;
        Author = author;
        PublishDate = publishDate;
    }

    public Paper()
    {
        Title = "Unknown";
        Author = new Person();
        PublishDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nAuthor: {Author}\nDate: {PublishDate.ToShortDateString()}";
    }
}