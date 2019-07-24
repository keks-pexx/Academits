using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    public class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;
        private double sideA;
        private double sideB;
        private double sideC;
        
        private double GetSide(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            sideA = GetSide(x1, y1, x2, y2);
            sideB = GetSide(x2, y2, x3, y3);
            sideC = GetSide(x3, y3, x1, y1);
        }

        public double GetWidth()
        {
            return Math.Max(x1, Math.Max(x2, x3)) - Math.Min(x1, Math.Min(x2, x3));
        }

        public double GetHeight()
        {
            return Math.Max(y1, Math.Max(y2, y2)) - Math.Min(y1, Math.Min(y2, y3)); ;
        }

        public double GetPerimeter()
        {
            return sideA + sideB + sideC;
        }

        public double GetArea()
        {
            double perimeter = GetPerimeter();
            return Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
        }


    }
}
