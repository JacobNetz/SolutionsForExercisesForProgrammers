using InterestCalculator;
using Spectre.Console;

namespace InputValidationChallenge;
internal class ChallengeSolutionAlternative
{
    private const string ErrorMessage = "[red]That is not a valid number, please try again[/]";

    public void CalculateInterest()
    {
        var principal = Prompt("What is the principal amount?", "blue");
        var rate = Prompt("What is the rate?", "olive"); 
        var years = Prompt("What is the number of years?", "fuchsia"); 
        var compounds = Prompt("What is the number of times the interest is compounded per year?", "teal"); 

        var calculator = new CompoundInterestCalculator();
        var total = calculator.CalculateTotalValue(principal, rate, years, compounds);

        AnsiConsole.MarkupLine($"\n[blue]{principal:C}[/] invested at [olive]{rate / 100:P}[/] for [fuchsia]{years}[/] year(s) " +
                               $"compounded [teal]{compounds}[/] times per year is [lime underline]{total:C}[/].");
    }

    private double Prompt(string question, string color, string errorMessage = ErrorMessage)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<double>(question)
                .PromptStyle(color)
                .ValidationErrorMessage(errorMessage)
        );
    }
}