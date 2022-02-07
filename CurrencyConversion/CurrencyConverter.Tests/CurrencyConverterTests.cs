using Xunit;

namespace CurrencyConverter.Tests;

public class CurrencyConverterTests
{
    [Fact]
    public void ConvertCurrency_WithValidAmountAndExchangeRate_ShouldReturnCorrectAmount()
    {
        var converter = new CurrencyConverter();

        var result = converter.ConvertCurrency(50, 150);

        Assert.Equal(75, result);
    }

    [Fact]
    public void ConvertCurrency_WithFractionalResult_ShouldRoundUpToTheNearestPenny()
    {
        var converter = new CurrencyConverter();

        var result = converter.ConvertCurrency(81, 137.51);

        Assert.Equal(111.39, result);
    }

    [Fact]
    public void ConvertCurrency_WithWholeDollarResult_ShouldNotRound()
    {
        var converter = new CurrencyConverter();

        var result = converter.ConvertCurrency(50, 2);

        Assert.Equal(1, result);
    }
}