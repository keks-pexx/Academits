using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Range
    {
        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public double GetLong()
        {
            return To - From;
        }

        public bool IsInside(double x)
        {
            return x >= From && x <= To;
        }

    }

    class RangeTask
    {
        public static int PrintAndRead(string invite)
        {
            Console.Write(invite);
            return Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int from = PrintAndRead( "Введите начало диапазона: ");
            int to = PrintAndRead("Введите конец диапазона: ");
            int number = PrintAndRead("Введите число: ");

            Range range = new Range(from, to);
            Console.WriteLine("Длина диапазона равна: " + range.GetLong());

            if (range.IsInside(number))
            {
                Console.WriteLine("Число попадает в диапазон");
            }
            else
            {
                Console.WriteLine("Число не попадает в диапазон");
            }

            Console.ReadKey();
        }
    }
}