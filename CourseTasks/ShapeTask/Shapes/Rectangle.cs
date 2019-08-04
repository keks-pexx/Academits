namespace ShapeTask.Shapes
{
    public class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return (width + height) * 2;
        }

        public override string ToString()
        {
            return "Rectangle w=" + width + " h=" + height + " s=" + GetArea() + " p=" + GetPerimeter();
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

            Rectangle p = (Rectangle)obj;
            return width == p.width && height == p.height;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + width.GetHashCode();
            hash = prime * hash + height.GetHashCode();
            return hash;
        }
    }
}
