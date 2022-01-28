namespace AreaOfARectangularRoom;

public record Area(double Feet, double Meters);

public class AreaCalculator
{
    // m^2 = f^2 * .09290304
    public const double ConversionFactor = .09290304;

    public double CalculateAreaInFeet(double height, double width) => height * width;

    public Area CalculateArea(double height, double width)
    {
        var feet = CalculateAreaInFeet(height, width);
        var meters = feet * ConversionFactor;
        return new Area(feet, meters);
    }
}