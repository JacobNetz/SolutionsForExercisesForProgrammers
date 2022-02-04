dotnet commands to set up this solution with support for testing

```PowerShell
dotnet new sln -n CurrencyConversion -o CurrencyConversion
Set-Location CurrencyConversion
dotnet new classlib -n CurrencyConverter
dotnet new xunit -o CurrencyConverter.Tests
dotnet sln add CurrencyConverter CurrencyConverter.Tests
dotnet add CurrencyConverter.Tests reference CurrencyConverter

# Opens solution in default program set for solutions (Visual Studio, Visual Studio Code, Rider, etc.)
.\CurrencyConversion.sln
```