using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetArea() > shape2.GetArea())
            {
                return 1;
            }
            else if (shape1.GetArea() < shape2.GetArea())
            {
                return -1;
            }
            else return 0;
        }
    }

    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter() > shape2.GetPerimeter())
            {
                return 1;
            }
            else if (shape1.GetPerimeter() < shape2.GetPerimeter())
            {
                return -1;
            }
            else return 0;
        }
    }
    class ShapeTask
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Rectangle(8, 5), new Square(7), new Circle(10), new Triangle(1, 2, 6, 8, 2, 11), new Rectangle(4, 7), new Square(9), new Circle(5) };

            Console.WriteLine("Печатаем для проверки");
            foreach (IShape e in shapes)
            {
                Console.WriteLine(e.ToString());
            }

            Array.Sort(shapes, new AreaComparer());
            Console.WriteLine("Максимальная площадь у фигуры: " + shapes[shapes.Length - 1].ToString());

            Array.Sort(shapes, new PerimeterComparer());
            Console.WriteLine("Второй по величине периметр у  фигуры: " + shapes[shapes.Length - 2].ToString());

            Console.ReadKey();
        }
    }
}