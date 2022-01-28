using Xunit;

namespace AreaOfARectangularRoom.Tests;

public class AreaCalculatorTests
{
    [Fact]
    public void CalculateAreaInFeet_WithValidHeightAndWidth_ShouldCorrectlyCalculateArea()
    {
        var calculator = new AreaCalculator();

        var area = calculator.CalculateAreaInFeet(2.5, 3.5);

        Assert.Equal(8.75, area);
    }

    [Fact]
    public void CalculateArea_WithValidHeightAndWidth_ShouldCalculateAreaInFeetAndMeters()
    {
        var calculator = new AreaCalculator();

        var (feet, meters) = calculator.CalculateArea(2.5, 3.5);

        Assert.Equal(8.75, feet);
        Assert.Equal(0.8129016, meters);
    }
}