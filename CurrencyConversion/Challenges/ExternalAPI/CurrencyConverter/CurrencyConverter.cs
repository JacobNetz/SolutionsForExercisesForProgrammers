using System.Net.Http.Json;

namespace CurrencyConverter;
public class CurrencyConverter
{
    private const string BaseURL = "https://openexchangerates.org/api";
    private const string ExchangeRateLatestURL = $"{BaseURL}/latest.json";

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
    
    public record Rates(double USD, double EUR);
    public record ExchangeRateInfo(Rates Rates);

    public double RoundUpToNearestPenny(double originalAmount)
    {
        var shiftedResult = originalAmount * 100;
        var ceiling = Math.Ceiling(shiftedResult);
        return Math.Ceiling(ceiling) != shiftedResult ? ceiling / 100 : originalAmount;
    }

    public async Task<(double exchangeRate, double dollars)> ConvertCurrency(double amount)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {AppId}");
        var jsonTask = httpClient.GetFromJsonAsync(ExchangeRateLatestURL, typeof(ExchangeRateInfo));
        if(await jsonTask is not ExchangeRateInfo eri)
            return (0, 0);
        var total = (1 / eri.Rates.EUR) * amount;
        return (eri.Rates.EUR, RoundUpToNearestPenny(total));
    }
}
