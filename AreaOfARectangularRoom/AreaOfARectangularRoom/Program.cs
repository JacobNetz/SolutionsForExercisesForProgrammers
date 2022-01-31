using AreaOfARectangularRoom;
using static System.Console;

Write("What is the length of the room in feet? ");
var length = Convert.ToDouble(ReadLine());
Write("What is the width of the room in feet? ");
var width = Convert.ToDouble(ReadLine());
WriteLine($"You entered dimensions of {length} feet by {width} feet.");

var (feet, meters) = new AreaCalculator().CalculateArea(length, width);
WriteLine("The area is");
WriteLine($"{feet} square feet");
WriteLine($"{meters} square meters");