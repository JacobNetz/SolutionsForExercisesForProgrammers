using System.Net.Http.Json;

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

    /// <summary>
    /// Gets https://openexchangerates.org App ID from environment variables -
    /// required to make API calls to the website
    /// </summary>
    /// <remarks>
    /// It tries to pull the env var from platform agnostic location first.
    /// If null, it tries Windows specific locations - Machine first, then User.
    /// </remarks>
    private string? AppId => Environment.GetEnvironmentVariable("OpenExchangeAppID", EnvironmentVariableTarget.Process)
                             ?? Environment.GetEnvironmentVariable("OpenExchangeAppID", EnvironmentVariableTarget.Machine)
                             ?? Environment.GetEnvironmentVariable("OpenExchangeAppID", EnvironmentVariableTarget.User);
    private string Url => $"https://openexchangerates.org/api/latest.json?app_id={AppId}";
    public record USDRate(double USD);
    public record ExchangeRateInfo(USDRate rates);

    public async Task<double> ConvertCurrency(double amount)
    {
        using var httpClient = new HttpClient();
        var jsonTask = httpClient.GetFromJsonAsync(Url, typeof(ExchangeRateInfo));
        var eri = await jsonTask as ExchangeRateInfo;
        return eri.rates.USD;
    }
}
