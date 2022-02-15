using Xunit;

namespace InterestCalculator.Tests;

public class CompoundInterestCalculatorTests
{
    [Fact]
    public void CalculateTotalValue_WithValidInputs_ShouldCalculateCorrectTotal()
    {
        var calculator = new CompoundInterestCalculator();

        var total = calculator.CalculateTotalValue(1500, 4.3f, 6, 4);

        Assert.Equal(1938.84, total);
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