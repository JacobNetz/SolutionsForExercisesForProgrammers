using static System.Console;

namespace MadLibs.Challenges;

internal class BranchingStory
{
    public static void Execute()
    {
        Write("Enter a noun: ");
        var noun = ReadLine();
        Write("Enter a verb: ");
        var verb = ReadLine();
        Write("Enter an adjective: ");
        var adjective = ReadLine();
        Write("Enter an adverb: ");
        var adverb = ReadLine();
        WriteLine($"Do you {verb} your {adjective} {noun} {adverb}? That's hilarious!");
        WriteLine(noun?.ToLowerInvariant() == "dog" ? "Everybody loves dogs!" : "Who doesn't love cats!");
    }
}