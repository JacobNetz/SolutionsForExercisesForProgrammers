using static System.Console;

namespace CountingTheNumberOfCharacters.Challenges;

internal class NoBlankInput
{
    public static void Execute()
    {
        WriteLine("What is the input string? ");
        var input = ReadLine();
        while (input is not { Length: > 0 })
        {
            WriteLine("Your input must contain at least one character, please try again: ");
            input = ReadLine();
        }
        WriteLine($"Your input \"{input}\" contains {input?.Length} characters");
    }
}