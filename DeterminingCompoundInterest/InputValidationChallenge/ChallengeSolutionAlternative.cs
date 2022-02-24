using InterestCalculator;
using Spectre.Console;

namespace InputValidationChallenge;
internal class ChallengeSolutionAlternative
{
    public void CalculateInterest()
    {
        var principal = AnsiConsole.Ask<double>("What is the principal amount?");
        var rate = AnsiConsole.Ask<double>("What is the rate?");
        var years = AnsiConsole.Ask<double>("What is the number of years?");
        var compounds = AnsiConsole.Ask<double>("What is the number of times the interest is compounded per year?");

        var calculator = new CompoundInterestCalculator();
        var total = calculator.CalculateTotalValue(principal, rate, years, compounds);

        AnsiConsole.WriteLine($"{principal:C} invested at {rate / 100:P} for {years} year(s) " +
                              $"compounded {compounds} times per year is {total:C}.");
    }
}