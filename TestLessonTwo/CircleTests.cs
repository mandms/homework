using Homework.Shapes;

namespace Homework.Tests;

public class CircleTests
{
    [TestCase(25, 157.07963267948966)]
    [TestCase(1, 6.283185307179586)]
    [TestCase(0, 0)]
    public void GIVEN_Circle_WHEN_CalculatePerimiter_method_is_id_invoked_THEN_correct_value_is_returned(
        double a,
        double expected
        )
    {
        var actual = new Circle(a).CalculatePerimeter();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(25, 1963.4954084936207)]
    [TestCase(1, 3.141592653589793)]
    [TestCase(0, 0)]
    public void GIVEN_Circle_WHEN_CalculateArea_method_is_id_invoked_THEN_correct_value_is_returned(
        double a,
        double expected
        )
    {
        var actual = new Circle(a).CalculateArea();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-1)]
    public void GIVEN_Circle_WHEN_CalculateArea_method_is_id_invoked_THEN_exception(
        double a
        )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Circle(a).CalculateArea(); });
    }

    [TestCase(-1)]
    public void GIVEN_Circle_WHEN_CalculatePerimeter_method_is_id_invoked_THEN_exception(
        double a
        )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Circle(a).CalculatePerimeter(); });
    }
}