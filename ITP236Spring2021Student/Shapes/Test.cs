#define stub
//#undef  stub
using static System.Console;

namespace Shapes
{
    public static class TestShapes
    {
        public static void Test()
        {
#if stub
            var circle = new Circle(3);
            ShowShape(circle);
            var rectangle = new Rectangle(20, 25);
            ShowShape(rectangle);
            var square = new Square(18);
            ShowShape(square);
            square.Length = 55;
            ShowShape(square);
#endif
        }
        static void ShowShape(Shapes.Shape shape)
        {
#if stub
            WriteLine($"Area = {shape.Area}\t\tPerimeter = {shape.Perimeter}\t\tUom = {shape.UoM}");
#endif
        }
    }
}