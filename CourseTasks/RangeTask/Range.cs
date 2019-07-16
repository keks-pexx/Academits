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

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double x)
        {
            return x >= From && x <= To;
        }

        public Range GetIntersection(Range range)
        {
            if (From >= range.To || To <= range.From)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (From >= range.To || To < range.From)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (From < range.From && To > range.To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (From < range.From && To <= range.To)
            {
                return new Range[] { new Range(From, range.From) };
            }

            if (From > range.From && To >= range.To)
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { new Range(From, To) };
        }
    }
}