using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask2
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

        public static Range GetInterseption(Range range1, Range range2)
        {
            if (range1.From >= range2.To || range1.To <= range2.From)
            {
                return null;
            }

            double fromResult = (range1.From > range2.From) ? range1.From : range2.From;
            double toResult = (range1.To < range2.To) ? range1.To : range2.To;

            Range rangeResult = new Range(fromResult, toResult);
            return rangeResult;
        }

        public static Range[] GetUnion(Range range1, Range range2)
        {

            if (range1.From >= range2.To || range1.To <= range2.From)
            {
                Range[] rangeTemp1 = { range1, range2 };
                return rangeTemp1;
            }

            double fromResult = (range1.From < range2.From) ? range1.From : range2.From;
            double toResult = (range1.To > range2.To) ? range1.To : range2.To;
            Range[] rangeTemp2 = { new Range(fromResult, toResult) };
            return rangeTemp2;
        }

        public static Range[] GetDifference(Range range1, Range range2)
        {
            if (range1.From < range2.From && range1.To <= range2.To)
            {
                Range[] rangeResult = { new Range(range1.From, range2.From) };
                return rangeResult;
            }

            if (range1.From > range2.From && range1.To >= range2.To)
            {
                Range[] rangeResult = { new Range(range2.To, range1.To) };
                return rangeResult;
            }

            if (range1.From < range2.From && range1.To > range2.To)
            {
                Range[] rangeResult = { new Range(range1.From, range2.From), new Range(range2.To, range1.To) };
                return rangeResult;
            }

            return null;
        }
    }

    class RangeTask2
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
            Range rangeI = Range.GetInterseption(range1, range2);

            Console.WriteLine("Длина диапазона №1 равна: " + range1.GetLong());

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

            foreach (Range e in Range.GetUnion(range1, range2))
            {
                Console.WriteLine("Объединение: " + e.From + " " + e.To);
            }

            foreach (Range e in Range.GetDifference(range1, range2))
            {
                Console.WriteLine("Разность: " + e.From + " " + e.To);
            }
            Console.ReadKey();
        }
    }
}
