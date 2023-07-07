using Homework.Shapes;

namespace Homework.Tests;

public class SquareTests
{
    [TestCase(25, 100)]
    [TestCase(1, 4)]
    [TestCase(0, 0)]
    public void GIVEN_Square_WHEN_CalculatePerimiter_method_is_id_invoked_THEN_correct_value_is_returned(
        double a,
        double expected
        )
    {
        var actual = new Square(a).CalculatePerimeter();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(25, 625)]
    [TestCase(1, 1)]
    [TestCase(0, 0)]
    public void GIVEN_Square_WHEN_CalculateArea_method_is_id_invoked_THEN_correct_value_is_returned(
        double a,
        double expected
        )
    {
        var actual = new Square(a).CalculateArea();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-1)]
    public void GIVEN_Square_WHEN_CalculateArea_method_is_id_invoked_THEN_exception(
        double a
        )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Square(a).CalculateArea(); });
    }

    [TestCase(-1)]
    public void GIVEN_Square_WHEN_CalculatePerimeter_method_is_id_invoked_THEN_exception(
        double a
        )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Square(a).CalculatePerimeter(); });
    }
}