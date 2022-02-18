using System.Diagnostics.CodeAnalysis;
using InterestCalculator;
using Spectre.Console;
using Spectre.Console.Cli;

namespace InputValidationChallenge;
public class InterestCommand : Command<InterestCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<Principal>")]
        public double Principal { get; init; }
        [CommandArgument(1, "<InterestRate>")]
        public double InterestRate { get; init; }
        [CommandArgument(2, "<Years>")]
        public double Years { get; init; }
        [CommandArgument(3, "<CompoundsPerYear>")]
        public double CompoundsPerYear { get; init; }
    }

    public override int Execute([NotNull]CommandContext context, [NotNull] Settings settings)
    {
        var calculator = new CompoundInterestCalculator();
        var total = calculator.CalculateTotalValue(settings.Principal, settings.InterestRate, settings.Years, settings.CompoundsPerYear);
        AnsiConsole.MarkupLine($"{settings.Principal:C} invested at {settings.InterestRate / 100:P} for {settings.Years} year(s) " +
                               $"compounded {settings.CompoundsPerYear} times per year is [underline green]{total:C}[/].");
        return 0;
    }
}