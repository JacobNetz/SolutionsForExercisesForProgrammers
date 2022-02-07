namespace CurrencyConverter;
public class CurrencyConverter
{
    public double ConvertCurrency(double amountFrom, double exchangeRate)
    {
        var result = (amountFrom * exchangeRate) / 100;
        var shiftedResult = result * 100;
        var ceiling = Math.Ceiling(shiftedResult);
        return Math.Ceiling(ceiling) != shiftedResult ? ceiling / 100 : result;
    }
}
