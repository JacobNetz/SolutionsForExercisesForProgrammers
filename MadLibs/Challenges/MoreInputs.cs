using static System.Console;

internal class MoreInputs
{
    public static void Execute()
    {
        Write("Enter a noun: ");
        var noun = ReadLine();
        Write("Enter a name (noun): ");
        var name = ReadLine();
        Write("Enter a verb: ");
        var verb = ReadLine();
        Write("Enter a verb ending in 'ing': ");
        var verbIng = ReadLine();
        Write("Enter an adjective: ");
        var adjective = ReadLine();
        Write("Enter an adverb: ");
        var adverb = ReadLine();
        WriteLine($"Do you {verb} your {adjective} {noun} {adverb}? That's hilarious!");
        WriteLine($"You should try {verbIng} with {name}.");
    }
}