using static Spectre.Console.AnsiConsole;

if (Confirm("Is the car silent when you turn the key"))
{
    WriteLine(Confirm("Are the battery terminals corroded")
        ? "Clean terminals and try starting again."
        : "Replace cables and try again.");
}
else
{
    if(Confirm("Does the car make a clicking noise"))
        WriteLine("Replace the battery.");
    else
    {
        if(Confirm("Does the car crank up but fail to start"))
            WriteLine("Check spark plug connections.");
        else
        {
            if (Confirm("Does the engine start and then die"))
            {
                WriteLine(Confirm("Does your car have fuel injection")
                    ? "Get it in for service."
                    : "Check to ensure the choke is opening and closing.");
            }
        }
    }
}