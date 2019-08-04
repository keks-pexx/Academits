using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class Vector
    {
        double[] Values { get; set; }

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
            for (int i = 0; i < vector.GetSize(); i++)
            {
                Values[i] = vector.Values[i];
            }
            //Array.Copy(vector.Values, Values, vector.Values.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("длинна массива должна быть > 0", nameof(array.Length));
            }

            Values = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Values[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }

            Values = new double[n];
            if (n < array.Length)
            {
                for (int i = 0; i < n; i++)
                {
                    Values[i] = array[i];
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Values[i] = array[i];
                }
            }
        }

        public int GetSize()
        {
            return Values.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Values.Length; i++)
            {
                sb.Append(Values[i]).Append(", ");
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

            const double epsilon = 1.0e-10;
            for (int i = 0; i < a1.Length; i++)
            {
                if (Math.Abs(a1[i] - a2[i]) > epsilon)
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
            return GetSize() == p.GetSize() && ArrayEquals(Values, p.Values);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + GetSize();
            for (int i = 0; i < GetSize(); i++)
            {
                hash = prime * hash + Values[i].GetHashCode();
            }

            return hash;
        }

        public Vector AddVector(Vector vector)
        {
            if (vector.Values.Length == 0)
            {
                throw new ArgumentException("длинна вектора должна быть > 0", nameof(vector.Values.Length));
            }

            if (GetSize() >= vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    Values[i] = Values[i] + vector.Values[i];
                }
                return this;
            }

            double[] ValuesResult = new double[vector.GetSize()];

            for (int i = 0; i < vector.GetSize(); i++)
            {
                ValuesResult[i] = vector.Values[i];
            }

            for (int i = 0; i < GetSize(); i++)
            {
                ValuesResult[i] = ValuesResult[i] + Values[i];
            }
            Values = ValuesResult;
            return this;
        }

        public Vector SubtractVector(Vector vector)
        {
            if (vector.Values.Length == 0)
            {
                throw new ArgumentException("длинна вектора должна быть > 0", nameof(vector.Values.Length));
            }

            if (GetSize() >= vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    Values[i] = Values[i] - vector.Values[i];
                }
                return this;
            }

            double[] ValuesResult = new double[vector.GetSize()];

            for (int i = 0; i < vector.GetSize(); i++)
            {
                ValuesResult[i] = vector.Values[i];
            }

            for (int i = 0; i < GetSize(); i++)
            {
                ValuesResult[i] = ValuesResult[i] - Values[i];
            }
            Values = ValuesResult;
            return this;
        }

        public Vector ScalarMultiplication(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Values[i] = Values[i] * scalar;
            }
            return this;
        }

        public Vector Reverse()
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Values[i] = Values[i] * (-1);
            }
            return this;
        }

        public double GetVectorLength()
        {
            double squareLength = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                squareLength = squareLength + Math.Pow(Values[i], 2);
            }
            return Math.Abs(Math.Sqrt(squareLength));
        }

        public double GetValue(int index)
        {
            return Values[index];
        }

        public Vector SetValue(double value, int index)
        {
            Values[index] = value;
            return this;
        }

        public static Vector GetVectorSumm(Vector vector1, Vector vector2)
        {
            Vector vectorResult = new Vector(vector1);
            return vectorResult.AddVector(vector2);
        }

        public static Vector GetVectorDifference(Vector vector1, Vector vector2)
        {
            Vector vectorResult = new Vector(vector1);
            return vectorResult.SubtractVector(vector2);
        }

        public static Vector GetVectorMultiplication(Vector vector1, Vector vector2)
        {
            int vectorMaxSize = Math.Max(vector1.GetSize(), vector2.GetSize());
            int vectorMinSize = Math.Min(vector1.GetSize(), vector2.GetSize());
            Vector vectorResult = new Vector(vectorMaxSize);
            for (int i = 0; i < vectorMinSize; i++)
            {
                vectorResult.Values[i] = vector1.Values[i] * vector2.Values[i];
            }

            return vectorResult;
        }
    }
}