using Xunit;

namespace CurrencyConverter.Tests;

public class CurrencyConverterTests
{
    [Theory]
    [InlineData(92.569, 92.57)]
    [InlineData(92.57, 92.57)]
    [InlineData(92.571, 92.58)]
    [InlineData(.999, 1)]
    [InlineData(.9909, 1)]
    [InlineData(1.01, 1.01)]
    [InlineData(0.1, .1)]
    [InlineData(0.000001, .01)]
    public void RoundUpToNearestPenny_WithFractionalPenny_ShouldRoundUp(double originalValue, double expectedValue)
    {
        var converter = new CurrencyConverter();

        var value = converter.RoundUpToNearestPenny(originalValue);

        Assert.Equal(expectedValue, value);
    }

    // This is actually an integration test (and should ideally be moved into an integration test project for clarity) -
    // this calls the actual API and gets up to date data. Because of this, the correct value to assert will change
    // every few minutes, so this cannot be asserted reliably.
    // With a paid license for the API, a historical route can be called to get the same data every call
    [Fact]
    public async void Convert()
    {
        var converter = new CurrencyConverter();
        
        var (_, dollars) = await converter.ConvertCurrency(81);

        Assert.Equal(92.57, dollars);
    }
}