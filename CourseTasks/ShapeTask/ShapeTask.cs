using System;
using ShapeTask.Shapes;

namespace ShapeTask
{
    class ShapeTask
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Rectangle(8, 5), new Square(7), new Circle(10), new Triangle(1, 2, 6, 8, 2, 11),
                                new Rectangle(4, 7), new Square(9), new Circle(5) };

            Console.WriteLine("Печатаем для проверки");
            foreach (IShape e in shapes)
            {
                Console.WriteLine(e);
            }

            Array.Sort(shapes, new AreaComparer());
            Console.  WriteLine("Максимальная площадь у фигуры: " + shapes[shapes.Length - 1]);

            Array.Sort(shapes, new PerimeterComparer());
            Console.WriteLine("Второй по величине периметр у  фигуры: " + shapes[shapes.Length - 2]);

            Console.ReadKey();
        }
    }
}