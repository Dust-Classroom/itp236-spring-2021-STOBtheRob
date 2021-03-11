using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public interface IShape
    {
        double Perimeter { get; set; }
        double Shape { get; set; }
    }

    public class Square : IShape
    {
        public double Length { get; set; }
        public double Shape { get; set; }

        public double Perimeter
        {
            get
            {
                return Length * 4;
            }
            set
            {
                Length = value;
            }
        }

        public double Area
        {
            get
            {
                return Length * Length;
            }
            set
            {
                Length = value;
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

    
}
