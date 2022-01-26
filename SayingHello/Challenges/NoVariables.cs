using static System.Console;

namespace SayingHello.Challenges;
internal class NoVariables
{
    public static void Execute()
    {
        Write("What is your name? ");
        WriteLine($"Hello {ReadLine()}, nice to meet you!");
    }
}