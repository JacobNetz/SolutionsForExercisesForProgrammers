public record QuoteInfo(string Quote, string Author);

internal class QuoteList
{
    public static void Execute()
    {
        var quotes = new List<QuoteInfo>
        {
            new("Keep your stick on the ice", "Red Green"),
            new("Here's looking at you, kid.","Rick Blaine"),
            new("Rosebud","Charles Foster Kane"),
            new("May the Force be with you.","Han Solo")
        };
        foreach (var (quote, author) in quotes)
            Console.WriteLine($"{author} says, \"{quote}\"");
    }
}