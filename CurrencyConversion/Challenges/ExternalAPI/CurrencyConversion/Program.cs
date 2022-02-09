using static System.Console;

Write("How many euros are you exchanging? ");
var euros = ReadLine();
Write("What is the exchange rate? ");
var exchangeRate = ReadLine();

var converter = new CurrencyConverter.CurrencyConverter();
var dollars = converter.ConvertCurrency(Convert.ToDouble(euros), Convert.ToDouble(exchangeRate));

WriteLine($"{euros} euros at an exchange rate of {exchangeRate} is {dollars} U.S. dollars.");