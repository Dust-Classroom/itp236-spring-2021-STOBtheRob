using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shapes
{
    public abstract class Shape
    {
        public string UoM { get; set; }
        // Unit of Measure property
        public abstract double Area { get; }
        // Area property
        public abstract double Perimeter { get; }
        // Perimeter property
        public Shape() // Default constructor (has no parameters)
        {
            UoM = "inches";
        }
    }
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public override double Area
        {
            get
            {
                return Length * Width;
            }
        }
        public override double Perimeter
        {
            get
            {
                return (Length + Width) * 2;
            }
        }
        public Rectangle() : this(1, 1)
        {
        }
        public Rectangle(double length, double width) : base()
        {
            Length = length;
            Width = width;
        }
    }
    public class Square : Shape
    {
        public double Length { get; set; }
        public override double Area
        {
            get
            {
                return Length * Length;
            }
        }
        public override double Perimeter
        {
            get
            {
                return Length * 4;
            }
        }
        public Square() : this(1)
        {
        }
        public Square(double length) : base()
        {
            Length = length;
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }
        public Circle() : this(1)
        {
        }
        public Circle(double radius) : base()
        {
            Radius = radius;
        }
    }
}
