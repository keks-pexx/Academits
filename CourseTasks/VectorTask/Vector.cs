using System;
using System.Text;

namespace VectorTask
{
    class Vector
    {
        private double[] Values { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("размерность должна быть > 0", nameof(n));
            }

            Values = new double[n];
        }

        public Vector(Vector vector)
        {
            if (vector.Values.Length == 0)
            {
                throw new ArgumentException("длинна вектора должна быть > 0", nameof(vector.Values.Length));
            }

            Values = new double[vector.GetSize()];
            Array.Copy(vector.Values, 0, Values, 0, vector.GetSize());
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("длинна массива должна быть > 0", nameof(array.Length));
            }

            Values = new double[array.Length];
            Array.Copy(array, 0, Values, 0, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }

            Values = new double[n];
            Array.Copy(array, 0, Values, 0, Math.Min(n, array.Length));
        }

        public int GetSize()
        {
            return Values.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (double e in Values)
            {
                sb.Append(e);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        private bool ArrayEquals(double[] a1, double[] a2)
        {
            if (a1.Length != a2.Length)
            {
                return false;
            }

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }

            return true;
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

            Vector p = (Vector)obj;
            return ArrayEquals(Values, p.Values);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + GetSize();

            foreach (double e in Values)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public Vector AddVector(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                double[] valuesResult = new double[vector.GetSize()];
                Array.Copy(Values, 0, valuesResult, 0, GetSize());
                Values = valuesResult;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                Values[i] += vector.Values[i];
            }
                   
            return this;
        }

        public Vector SubtractVector(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                double[] valuesResult = new double[vector.GetSize()];
                Array.Copy(Values, 0, valuesResult, 0, GetSize());
                Values = valuesResult;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                Values[i] -= vector.Values[i];
            }

            return this;
        }

        public Vector Multiply(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Values[i] = Values[i] * scalar;
            }

            return this;
        }

        public Vector Reverse()
        {
            return Multiply(-1);
        }

        public double GetVectorLength()
        {
            double squareLength = 0;

            foreach (double e in Values)
            {
                squareLength += Math.Pow(e, 2);
            }

            return Math.Sqrt(squareLength);
        }

        public double GetValue(int index)
        {
            return Values[index];
        }

        public Vector SetValue(int index, double value)
        {
            Values[index] = value;
            return this;
        }

        public static Vector GetVectorSum(Vector vector1, Vector vector2)
        {
            Vector vectorResult = new Vector(vector1);
            return vectorResult.AddVector(vector2);
        }

        public static Vector GetVectorDifference(Vector vector1, Vector vector2)
        {
            Vector vectorResult = new Vector(vector1);
            return vectorResult.SubtractVector(vector2);
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int vectorMinSize = Math.Min(vector1.GetSize(), vector2.GetSize());
            double sum = 0;

            for (int i = 0; i < vectorMinSize; i++)
            {
                sum += vector1.Values[i] * vector2.Values[i];
            }

            return sum;
        }
    }
}