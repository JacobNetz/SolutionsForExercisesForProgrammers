using CommunityToolkit.Mvvm.ComponentModel;
using InterestCalculator;
using System.ComponentModel;

namespace GUIAppChallenge;
public class MainWindowViewModel: ObservableObject
{
    private readonly CompoundInterestCalculator _calculator = new();

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName != nameof(Total))
            Total = _calculator.CalculateTotalValue(Principal, InterestRate, Years, CompoundsPerYear);
    }

    private double _principal;
    public double Principal
    {
        get => _principal;
        set => SetProperty(ref _principal, value);
    }

    private double _interestRate;
    public double InterestRate
    {
        get => _interestRate;
        set => SetProperty(ref _interestRate, value);
    }

    private double _years;
    public double Years
    {
        get => _years;
        set => SetProperty(ref _years, value);
    }

    private double _compoundsPerYear;
    public double CompoundsPerYear
    {
        get => _compoundsPerYear;
        set => SetProperty(ref _compoundsPerYear, value);
    }

    private double _total;
    public double Total
    {
        get => _total;
        private set => SetProperty(ref _total, value);
    }
}