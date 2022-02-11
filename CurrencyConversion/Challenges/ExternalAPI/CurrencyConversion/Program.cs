using static System.Console;

Write("How many euros are you exchanging? ");
var euros = ReadLine();

var converter = new CurrencyConverter.CurrencyConverter();
var (exchangeRate, dollars) = await converter.ConvertCurrency(Convert.ToDouble(euros));

WriteLine($"{euros} euros at an exchange rate of {exchangeRate} is {dollars:C} U.S. dollars.");