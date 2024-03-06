using System.Runtime.ConstrainedExecution;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape newRectnangleShape = new Rectangle(2,2);
            
            Console.WriteLine(newRectnangleShape.CalculateArea());
            Console.WriteLine(newRectnangleShape.CalculatePerimeter());
            
            Shape newCircleShape = new Circle(2.3D);
            Console.WriteLine(newCircleShape.CalculateArea());
            Console.WriteLine(newCircleShape.CalculatePerimeter());
        }
    }
}