namespace Homework.Shapes;

public class Square : IShape
{
    private readonly double _length;

    public Square(double length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("Lenth cannot be negative");
        }
        else
        {
            _length = length;
        }
    }

    public double CalculateArea()
    {
        return _length * _length;
    }

    public double CalculatePerimeter()
    {
        return _length * 4;
    }
}