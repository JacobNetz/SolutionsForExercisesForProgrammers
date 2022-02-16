using InterestCalculator;
using static System.Console;
    
Write("What is the principal amount? ");
var principal = Convert.ToDouble(ReadLine());
Write("What is the rate? ");
var rate = Convert.ToDouble(ReadLine());
Write("What is the number of years? ");
var years = Convert.ToDouble(ReadLine());
Write("What is the number of times the interest is compounded per year? ");
var compounds = Convert.ToDouble(ReadLine());

var calculator = new CompoundInterestCalculator();
var total = calculator.CalculateTotalValue(principal, rate, years, compounds);

WriteLine($"{principal:C} invested at {rate / 100:P} for {years} year(s) " +
          $"compounded {compounds} times per year is {total:C}.");