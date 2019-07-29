using System;

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

        private static double GetSide(double x1, double y1, double x2, double y2)
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

        public override string ToString()
        {
            return "Triangle x1=" + x1 + " y1=" + y1 + " x2=" + x2 + " y2=" + y2 + " x3=" + x3 + " y3=" + y3 +
                "s=" + GetArea() + ", p=" + GetPerimeter();
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle p = (Triangle)obj;
            return x1 == p.x1 && y1 == p.y1 && x2 == p.x2 && y2 == p.y2 && x3 == p.x3 && y3 == p.y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y3.GetHashCode();
            return hash;
        }
    }
}
