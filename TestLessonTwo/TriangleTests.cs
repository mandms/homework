using Homework.Shapes;

namespace Homework.Tests;

public class TriangleTests
{
    
    [TestCase(6, 5, 5, 16)]
    [TestCase(1, 1, 1, 3)]
    [TestCase(0, 0, 0, 0)]
    public void GIVEN_Triangle_WHEN_CalculatePerimeter_method_is_id_invoked_THEN_correct_value_is_returned(
        double a,
        double b,
        double c,
        double expected
        )
    {
        var actual = new Triangle(a, b, c).CalculatePerimeter();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1, 1, 1, 0.4330127018922193)]
    [TestCase(5, 4, 3, 6)]
    [TestCase(0, 0, 0, 0)]
    public void GIVEN_Triangle_WHEN_CalculateArea_method_is_id_invoked_THEN_correct_value_is_returned(
        double a,
        double b,
        double c,
        double expected
        )
    {
        var actual = new Triangle(a, b, c).CalculateArea();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-1, -1, -1)]
    [TestCase(1, -1, 0)]
    public void GIVEN_Triangle_WHEN_CalculateArea_method_is_id_invoked_THEN_exception(
        double a,
        double b,
        double c
        )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Triangle(a, b, c).CalculateArea(); });
    }

    [TestCase(-1, -1, -1)]
    [TestCase(1, -1, 0)]
    public void GIVEN_Triangle_WHEN_CalculatePerimeter_method_is_id_invoked_THEN_exception(
        double a,
        double b,
        double c
        )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Triangle(a, b, c).CalculatePerimeter(); });
    }
}