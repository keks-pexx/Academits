using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    class ShapeTask
    {
        public static void PrintShape(IShape shape)
        {
            Console.WriteLine("Ширина фигуры: " + shape.GetWidth());
            Console.WriteLine("Высота фигуры: " + shape.GetHeight());
            Console.WriteLine("Площадь фигуры: " + shape.GetArea());
            Console.WriteLine("Периметр фигуры: " + shape.GetPerimeter());
        }

        public static IShape GetMaxArea(IShape[] shape)
        {
            int iMaxArea = 0;
            for (int i = 1; i < shape.Length; i++)
            {
                if (shape[i].GetArea() > shape[iMaxArea].GetArea())
                {
                    iMaxArea = i;
                }
            }

            return shape[iMaxArea];
        }

        static void Main(string[] args)
        {
            IShape[] shapes = { new Rectangle(8, 5), new Square(7), new Circle(10), new Triangle(1, 2, 6, 8, 2, 11), new Rectangle(4, 7), new Square(9), new Circle(5) };
            PrintShape(GetMaxArea(shapes));
            Console.ReadKey();
        }
    }
}
