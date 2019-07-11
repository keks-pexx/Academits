using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RangeTask;

namespace RangeTask
{
    class RangeTask
    {
        static void Main(string[] args)
        {
            int from1 = 1;
            int to1 = 15;
            int from2 = 7;
            int to2 = 11;
            int number = 10;

            Range range1 = new Range(from1, to1);
            Range range2 = new Range(from2, to2);
            Range rangeI = range1.GetInterseсtion(range2);

            Console.WriteLine("Длина диапазона №1 равна: " + range1.GetLength());

            if (range1.IsInside(number))
            {
                Console.WriteLine("Число попадает в диапазон №1");
            }
            else
            {
                Console.WriteLine("Число не попадает в диапазон №1");
            }

            if (rangeI == null)
            {
                Console.WriteLine("Диапазоны не пересекаются");
            }
            else
            {
                Console.WriteLine("Пересечение: " + rangeI.From + " " + rangeI.To);
            }

            foreach (Range e in range1.GetUnion(range2))
            {
                Console.WriteLine("Объединение: " + e.From + " " + e.To);
            }

            foreach (Range e in range1.GetDifference(range2))
            {
                Console.WriteLine("Разность: " + e.From + " " + e.To);
            }
            Console.ReadKey();
        }
    }
}