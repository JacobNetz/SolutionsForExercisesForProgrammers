using static System.Console;

namespace SayingHello.Challenges;
internal class RandomGreetings
{
    public static void RandomGreeting()
    {
        Write("What is your name? ");
        var input = ReadLine();
        var random = new Random();
        var greeting = random.Next(0, 4) switch
        {
            0 => $"Hello {input}",
            1 => $"Good day {input}",
            2 => $"What's up {input}",
            3 => $"Hey {input}, how are you?",
            _ => $"Goodbye {input}"
        };
        WriteLine(greeting);
    }
}