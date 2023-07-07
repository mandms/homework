namespace Homework.Shapes;

public class Triangle : IShape
{
    private readonly double _a, _b, _c;

    public Triangle(double a, double b, double c)
    {
        if ((a < 0) || (b < 0) || (c < 0))
        {
            throw new ArgumentOutOfRangeException("Sides cannot be negative");
        } 
        else if ((a + b < c) || (a + c < b) || (c + b < a))
        {
            throw new ArgumentException(
                "No such triangle exists (A triangle exists only when " +
                "the sum of its two sides is greater than the third.)"
                );
        }
        else
        {
            _a = a;
            _b = b;
            _c = c;
        }
    }

    private double GetSemiperimeter()
    {
        return (_a + _b + _c) / 2;
    }

    public double CalculateArea()
    {
        double p = GetSemiperimeter();
        double area = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        return area;
    }

    public double CalculatePerimeter()
    {
        return _a + _b + _c;
    }
}