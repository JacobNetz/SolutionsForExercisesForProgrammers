using System.ComponentModel;
using System.Runtime.CompilerServices;
using InterestCalculator;

namespace GUIAppChallenge;
public class MainWindowViewModel: INotifyPropertyChanged
{
    private readonly CompoundInterestCalculator _calculator = new();
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        if (propertyName != nameof(Total))
            Total = _calculator.CalculateTotalValue(Principal, InterestRate, Years, CompoundsPerYear);
    }

    private double _principal;
    public double Principal
    {
        get => _principal;
        set
        {
            if (value.Equals(_principal)) return;
            _principal = value;
            OnPropertyChanged();
        }
    }

    private double _interestRate;
    public double InterestRate
    {
        get => _interestRate;
        set
        {
            if (value.Equals(_interestRate)) return;
            _interestRate = value;
            OnPropertyChanged();
        }
    }

    private double _years;
    public double Years
    {
        get => _years;
        set
        {
            if (value.Equals(_years)) return;
            _years = value;
            OnPropertyChanged();
        }
    }

    private double _compoundsPerYear;
    public double CompoundsPerYear
    {
        get => _compoundsPerYear;
        set
        {
            if (value.Equals(_compoundsPerYear)) return;
            _compoundsPerYear = value;
            OnPropertyChanged();
        }
    }

    private double _total;
    public double Total
    {
        get => _total;
        private set
        {
            if (value.Equals(_total)) return;
            _total = value;
            OnPropertyChanged();
        }
    }
}