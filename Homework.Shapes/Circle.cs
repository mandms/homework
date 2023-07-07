namespace Homework.Shapes;

public class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException("Radius cannot be negative");
        }
        else
        {
            _radius = radius;
        }
    }

    public double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}