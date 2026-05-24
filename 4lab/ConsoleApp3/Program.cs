using System;

class Program
{
    static void Main()
    {
        Console.Write("Count: ");

        string? input = Console.ReadLine();

        int count = int.Parse(input ?? "100");

        TestCollections4 test =
            new TestCollections4(count);

        test.MeasureSearch();
    }
}