if (Prompt("Is the car silent when you turn the key"))
{
    if (Prompt("Are the battery terminals corroded"))
        Console.WriteLine("Clean terminals and try starting again.");
    else
        Console.WriteLine("Replace cables and try again.");
}
else
{
    if(Prompt("Does the car make a clicking noise"))
        Console.WriteLine("Replace the battery.");
    else
    {
        if(Prompt("Does the car crank up but fail to start"))
            Console.WriteLine("Check spark plug connections.");
        else
        {
            if (Prompt("Does the engine start and then die"))
            {
                if(Prompt("Does your car have fuel injection"))
                    Console.WriteLine("Get it in for service.");
                else
                    Console.WriteLine("Check to ensure the choke is opening and closing.");
            }
        }
    }
}

bool Prompt(string promptText)
{
    Console.Write($"{promptText}? ");
    var answer = Console.ReadLine()?.ToLowerInvariant();
    return answer == null || !answer.StartsWith("n");
}