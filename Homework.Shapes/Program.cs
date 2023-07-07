//Lesson 2
using Homework.Shapes;

Circle circle = new(25);
Triangle triangle = new(1, 1, 1);
Square square = new(4);

List<IShape> shapes = new List<IShape>()
{
    circle,
    triangle,
    square
};

foreach (IShape shape in shapes)
{
    Console.WriteLine(shape.CalculatePerimeter());
    Console.WriteLine(shape.CalculateArea());
}