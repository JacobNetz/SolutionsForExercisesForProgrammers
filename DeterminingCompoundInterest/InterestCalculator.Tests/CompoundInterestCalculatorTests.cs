using Xunit;

namespace InterestCalculator.Tests;

public class CompoundInterestCalculatorTests
{
    [Theory]
    [InlineData(1500, 4.3f, 6, 4, 1938.84)]
    [InlineData(1000, 5, 3, 6, 1161.12)]
    [InlineData(0, 5, 3, 6, 0)]
    [InlineData(1000, 0, 3, 6, 1000)]
    public void CalculateTotalValue_WithValidInputs_ShouldCalculateCorrectTotal(
        double principal, double interestRate, double years, double compoundsPerYear, double expected)
    {
        var calculator = new CompoundInterestCalculator();

        var actual = calculator.CalculateTotalValue(principal, interestRate, years, compoundsPerYear);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1938.8394775390625, 1938.84)]
    [InlineData(1938.84, 1938.84)]
    [InlineData(1938.839, 1938.84)]
    [InlineData(1938.831, 1938.84)]
    [InlineData(1938.830, 1938.83)]
    [InlineData(1938, 1938)]
    public void RoundUSDToNearestPenny_WithFractionalPennies_ShouldRoundUpToTheNextPenny(double original, double expected)
    {
        var calculator = new CompoundInterestCalculator();

        var total = calculator.RoundUSDToNearestPenny(original);

        Assert.Equal(expected, total);
    }
}