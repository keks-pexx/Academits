using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    public class Square : IShape
    {
        private double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetPerimeter()
        {
            return sideLength * 4;
        }
    }
}
