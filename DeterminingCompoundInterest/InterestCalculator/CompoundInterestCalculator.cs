namespace InterestCalculator;
public class CompoundInterestCalculator
{
    /// <summary>
    /// Calculates total value of investment, using formula A = P(1 + r/n)^nt
    /// </summary>
    /// <param name="principal"></param>
    /// <param name="interestRate">as a percentage, i.e. 15 (not .15)</param>
    /// <param name="years"></param>
    /// <param name="compoundsPerYear">number of times the interest is compounded per year</param>
    /// <returns></returns>
    public double CalculateTotalValue(double principal, double interestRate, double years, double compoundsPerYear)
    {
        var i = 1 + interestRate / 100 / compoundsPerYear;
        var j = Math.Pow(i, compoundsPerYear * years);
        var total = principal * j;
        var roundedTotal = RoundUSDToNearestPenny(total);
        return roundedTotal;
    }

    public double RoundUSDToNearestPenny(double total)
    {
        var shiftedValue = total * 100;
        var roundedValue = Math.Ceiling(shiftedValue);
        return roundedValue / 100;
    }
}
