using InterestCalculator;
using Spectre.Console;

namespace InputValidationChallenge;
internal class ChallengeSolutionAlternative
{
    private const string ErrorMessage = "[red]That is not a valid number, please try again[/]";

    public void CalculateInterest()
    {
        var principal = AnsiConsole.Prompt(
            new TextPrompt<double>("What is the principal amount?")
                .PromptStyle("blue")
                .ValidationErrorMessage(ErrorMessage)
        );
        var rate = AnsiConsole.Prompt(
            new TextPrompt<double>("What is the rate?")
                .PromptStyle("olive")
                .ValidationErrorMessage(ErrorMessage)
        );
        var years = AnsiConsole.Prompt(
            new TextPrompt<double>("What is the number of years?")
                .PromptStyle("fuchsia")
                .ValidationErrorMessage(ErrorMessage)
        );
        var compounds = AnsiConsole.Prompt(
            new TextPrompt<double>("What is the number of times the interest is compounded per year?")
                .PromptStyle("teal")
                .ValidationErrorMessage(ErrorMessage)
        );

        var calculator = new CompoundInterestCalculator();
        var total = calculator.CalculateTotalValue(principal, rate, years, compounds);

        AnsiConsole.MarkupLine($"\n[blue]{principal:C}[/] invested at [olive]{rate / 100:P}[/] for [fuchsia]{years}[/] year(s) " +
                               $"compounded [teal]{compounds}[/] times per year is [lime underline]{total:C}[/].");
    }
}