using static System.Console;

if (Prompt("Is the car silent when you turn the key"))
{
    WriteLine(Prompt("Are the battery terminals corroded")
        ? "Clean terminals and try starting again."
        : "Replace cables and try again.");
}
else
{
    if(Prompt("Does the car make a clicking noise"))
        WriteLine("Replace the battery.");
    else
    {
        if(Prompt("Does the car crank up but fail to start"))
            WriteLine("Check spark plug connections.");
        else
        {
            if (Prompt("Does the engine start and then die"))
            {
                WriteLine(Prompt("Does your car have fuel injection")
                    ? "Get it in for service."
                    : "Check to ensure the choke is opening and closing.");
            }
        }
    }
}

bool Prompt(string promptText)
{
    Write($"{promptText}? ");
    var answer = ReadLine()?.ToLowerInvariant();
    return answer == null || !answer.StartsWith("n");
}