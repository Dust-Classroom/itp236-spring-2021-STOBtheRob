using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using static System.Console;

namespace TestConsole
{
    class TestShapes
    {
        public static void Test()
        {
            var circle = new Circle(3);
            ShowShape(circle);
            var rectangle = new Rectangle(20, 25);
            ShowShape(rectangle);
            var square = new Square(18);
            ShowShape(square);
            square.Length = 55;
            ShowShape(square);
        }
        static void ShowShape(Shapes.Shape shape)
        {
            WriteLine($"Area = {shape.Area}\t\tPerimeter = {shape.Perimeter}\t\tUom = {shape.UoM}");
        }
    }
}
