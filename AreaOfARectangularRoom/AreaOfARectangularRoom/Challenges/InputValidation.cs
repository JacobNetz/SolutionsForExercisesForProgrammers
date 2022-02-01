using static System.Console;

namespace AreaOfARectangularRoom.Challenges;

internal class InputValidation
{
    public static void Execute()
    {
        Write("What is the length of the room in feet? ");
        double length;
        while (!double.TryParse(ReadLine(), out length))
            Write("Length must be entered as a number, please try again: ");

        Write("What is the width of the room in feet? ");
        double width;
        while (!double.TryParse(ReadLine(), out width))
            Write("Width must be entered as a number, please try again: ");

        WriteLine($"You entered dimensions of {length} feet by {width} feet.");

        var (feet, meters) = new AreaCalculator().CalculateArea(length, width);
        WriteLine("The area is");
        WriteLine($"{feet} square feet");
        WriteLine($"{meters} square meters");
    }
}